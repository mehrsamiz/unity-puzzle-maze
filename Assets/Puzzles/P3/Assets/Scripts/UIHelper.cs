using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Helper script to quickly create a basic UI setup if nothing is showing.
/// Attach this to an empty GameObject and press the button in Play mode to create UI.
/// </summary>
public class UIHelper : MonoBehaviour
{
    [ContextMenu("Create Basic UI")]
    public void CreateBasicUI()
    {
        // Find or create Canvas
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObj = new GameObject("Canvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();

            CanvasScaler scaler = canvas.GetComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
        }

        // Create StartPanel
        CreatePanel(canvas.transform, "StartPanel", new Color(0.1f, 0.1f, 0.1f, 1f));

        // Create WitnessPanel
        CreatePanel(canvas.transform, "WitnessPanel", new Color(0.1f, 0.1f, 0.1f, 1f));

        // Create SuspectPanel
        CreatePanel(canvas.transform, "SuspectPanel", new Color(0.1f, 0.1f, 0.1f, 1f));

        // Create ResultPanel
        CreatePanel(canvas.transform, "ResultPanel", new Color(0.1f, 0.1f, 0.1f, 1f));

        Debug.Log("Basic UI created! Now you need to add buttons and text manually, or assign them in UIController.");
    }

    private GameObject CreatePanel(Transform parent, string name, Color color)
    {
        GameObject panel = new GameObject(name);
        panel.transform.SetParent(parent, false);

        RectTransform rect = panel.AddComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.sizeDelta = Vector2.zero;

        Image image = panel.AddComponent<Image>();
        image.color = color;

        // Set initial state
        if (name == "StartPanel")
            panel.SetActive(true);
        else
            panel.SetActive(false);

        return panel;
    }
}

