using UnityEngine;

[DisallowMultipleComponent]
public class GridLogic : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Color secondEnterColor = Color.yellow;
    [SerializeField] private Color thirdEnterColor = Color.red;
    [SerializeField] private float blockedHeight = 20f;

    [Header("Fog Logic")]
    // CHECK THIS BOX in the Inspector for tiles inside the Fog Zone
    public bool isFogTile = false;

    private int enterCount = 0;
    private bool playerOnTile = false;
    private Renderer rend;
    private Color defaultColor;
    private BoxCollider boxCollider;
    private Vector3 originalColliderSize;
    private bool isBlocked = false;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
            defaultColor = rend.material.color;

        boxCollider = GetComponent<BoxCollider>();
        if (boxCollider != null)
            originalColliderSize = boxCollider.size;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 1. Check if it's the player
        if (!collision.collider.CompareTag(playerTag)) return;
        if (playerOnTile) return;

        playerOnTile = true;
        enterCount++;

        // 2. SCORING: Deduct move cost (-10)
        // We use ?. to prevent error if ScoreManager is missing
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.DeductMoveCost();
        }

        // 3. FOG CHECK: If this is a fog tile, we stop here (no colors, no penalties)
        if (isFogTile) return;

        // 4. NORMAL TILE LOGIC (Colors & Penalties)
        if (enterCount == 2)
        {
            if (rend != null) rend.material.color = secondEnterColor;

            // Apply Yellow Penalty
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.DeductYellowPenalty();
        }
        else if (enterCount == 3)
        {
            if (rend != null) rend.material.color = thirdEnterColor;

            // Apply Red Penalty
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.DeductRedPenalty();
        }
        else if (enterCount >= 4 && !isBlocked)
        {
            BlockCell();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.collider.CompareTag(playerTag)) return;
        playerOnTile = false;
    }

    private void BlockCell()
    {
        if (boxCollider == null) return;

        isBlocked = true;

        Vector3 newSize = originalColliderSize;
        newSize.y = blockedHeight;
        boxCollider.size = newSize;

        boxCollider.center = new Vector3(
            boxCollider.center.x,
            blockedHeight / 2f,
            boxCollider.center.z
        );
    }
}