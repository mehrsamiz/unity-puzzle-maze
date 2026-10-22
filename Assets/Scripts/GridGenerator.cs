using UnityEngine;

[DisallowMultipleComponent]
public class GridGenerator : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject tilePrefab;

    [Header("Walls")]
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private bool liftWallsHalfHeight = true;
    [SerializeField] private bool generateOuterWalls = true;

    [Header("Grid")]
    [Min(1)]
    [SerializeField] private int n = 9;

    [Min(0.01f)]
    [SerializeField] private float spacing = 1.001f;

    [SerializeField] private bool centerGrid = true;

    // Marker so we can clear only generated objects
    private sealed class GeneratedByGridGenerator : MonoBehaviour { }

    [ContextMenu("Generate Grid")]
    public void Generate()
    {
        if (!tilePrefab)
        {
            Debug.LogError("GridGenerator: tilePrefab is not assigned.", this);
            return;
        }

        n = Mathf.Max(1, n);
        spacing = Mathf.Max(0.01f, spacing);

        Clear();

        float half = (n - 1) * spacing * 0.5f;
        Vector3 origin = centerGrid ? new Vector3(-half, 0f, -half) : Vector3.zero;

        // --- Tiles ---
        for (int x = 0; x < n; x++)
        {
            for (int z = 0; z < n; z++)
            {
                Vector3 tilePos = origin + new Vector3(x * spacing, 0f, z * spacing);
                Spawn(tilePrefab, tilePos, Quaternion.identity, $"Tile_{x}_{z}", isWall: false);
            }
        }

        // --- Walls ---
        if (!wallPrefab) return;

        // Internal walls (x direction) -> rotate 90
        for (int x = 0; x < n - 1; x++)
        {
            for (int z = 0; z < n; z++)
            {
                Vector3 wallPos = origin + new Vector3(x * spacing + spacing * 0.5f, 0f, z * spacing);
                Spawn(wallPrefab, wallPos, Quaternion.Euler(0f, 90f, 0f), $"Wall_X_{x}_{z}", isWall: true);
            }
        }

        // Internal walls (z direction) -> no rotation
        for (int x = 0; x < n; x++)
        {
            for (int z = 0; z < n - 1; z++)
            {
                Vector3 wallPos = origin + new Vector3(x * spacing, 0f, z * spacing + spacing * 0.5f);
                Spawn(wallPrefab, wallPos, Quaternion.identity, $"Wall_Z_{x}_{z}", isWall: true);
            }
        }

        if (!generateOuterWalls) return;

        // Outer perimeter
        float leftX = -spacing * 0.5f;
        float rightX = (n - 1) * spacing + spacing * 0.5f;

        for (int z = 0; z < n; z++)
        {
            Spawn(wallPrefab, origin + new Vector3(leftX, 0f, z * spacing), Quaternion.Euler(0f, 90f, 0f), $"Wall_Border_Left_{z}", true);
            Spawn(wallPrefab, origin + new Vector3(rightX, 0f, z * spacing), Quaternion.Euler(0f, 90f, 0f), $"Wall_Border_Right_{z}", true);
        }

        float bottomZ = -spacing * 0.5f;
        float topZ = (n - 1) * spacing + spacing * 0.5f;

        for (int x = 0; x < n; x++)
        {
            Spawn(wallPrefab, origin + new Vector3(x * spacing, 0f, bottomZ), Quaternion.identity, $"Wall_Border_Bottom_{x}", true);
            Spawn(wallPrefab, origin + new Vector3(x * spacing, 0f, topZ), Quaternion.identity, $"Wall_Border_Top_{x}", true);
        }
    }

    private void Spawn(GameObject prefab, Vector3 localPos, Quaternion localRot, string name, bool isWall)
    {
        GameObject go = CreateInstance(prefab, transform);
        go.name = name;

        if (!go.GetComponent<GeneratedByGridGenerator>())
            go.AddComponent<GeneratedByGridGenerator>();

        go.transform.localRotation = localRot;

        if (isWall && liftWallsHalfHeight)
            localPos.y += GetHalfHeightLocal(go, transform);

        go.transform.localPosition = localPos;
    }

    [ContextMenu("Clear Grid")]
    public void Clear()
    {
        // Delete only children created by this generator
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            if (!child.GetComponent<GeneratedByGridGenerator>()) continue;

            if (Application.isPlaying) Destroy(child.gameObject);
            else DestroyImmediate(child.gameObject);
        }
    }

    private static float GetHalfHeightLocal(GameObject go, Transform parent)
    {
        float heightWorld = 0f;

        Renderer r = go.GetComponentInChildren<Renderer>();
        if (r != null) heightWorld = r.bounds.size.y;
        else
        {
            Collider c = go.GetComponentInChildren<Collider>();
            if (c != null) heightWorld = c.bounds.size.y;
        }

        if (heightWorld <= 0f) return 0f;

        float parentScaleY = parent.lossyScale.y;
        if (Mathf.Approximately(parentScaleY, 0f)) return 0f;

        float heightLocal = heightWorld / parentScaleY;
        return heightLocal * 0.5f;
    }

    private static GameObject CreateInstance(GameObject prefab, Transform parent)
    {
#if UNITY_EDITOR
        if (!Application.isPlaying)
            return (GameObject)UnityEditor.PrefabUtility.InstantiatePrefab(prefab, parent);
#endif
        return Instantiate(prefab, parent);
    }
}
