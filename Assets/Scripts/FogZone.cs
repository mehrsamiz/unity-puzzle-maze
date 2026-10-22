using UnityEngine;
using System.Collections;

public class FogZone : MonoBehaviour
{
    [Header("Fog Settings")]
    public float targetDensity = 0.35f;
    public Color targetColor = new Color(0.5f, 0.5f, 0.5f, 1f);

    [Header("Transition")]
    public float transitionSpeed = 2.0f;

    private static float defaultDensity;
    private static Color defaultColor;
    private static bool hasStoredDefaults = false;

    //shared counter
    private static int playerInsideCount = 0;
    private static Coroutine currentFogRoutine;

    private void Start()
    {
        if (!hasStoredDefaults)
        {
            defaultDensity = RenderSettings.fogDensity;
            defaultColor = RenderSettings.fogColor;
            hasStoredDefaults = true;
        }

        if (RenderSettings.fogMode == FogMode.Linear)
            RenderSettings.fogMode = FogMode.Exponential;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInsideCount++;

        // Only trigger fog ON when entering the FIRST fog cell
        if (playerInsideCount == 1)
        {
            StartFogTransition(targetDensity, targetColor);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        playerInsideCount = Mathf.Max(0, playerInsideCount - 1);

        // Only turn fog OFF when leaving the LAST fog cell
        if (playerInsideCount == 0)
        {
            StartFogTransition(defaultDensity, defaultColor);
        }
    }

    private void StartFogTransition(float density, Color color)
    {
        if (currentFogRoutine != null)
            StopCoroutine(currentFogRoutine);

        currentFogRoutine = StartCoroutine(TransitionFog(density, color));
    }

    IEnumerator TransitionFog(float endDensity, Color endColor)
    {
        RenderSettings.fog = true;

        float startDensity = RenderSettings.fogDensity;
        Color startColor = RenderSettings.fogColor;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * transitionSpeed;
            RenderSettings.fogDensity = Mathf.Lerp(startDensity, endDensity, t);
            RenderSettings.fogColor = Color.Lerp(startColor, endColor, t);
            yield return null;
        }
    }
}
