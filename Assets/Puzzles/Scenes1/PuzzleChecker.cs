using TMPro;
using UnityEngine;
using System.Collections;

public class PuzzleChecker : MonoBehaviour
{
    [SerializeField] private Color correctColor = Color.green;
    [SerializeField] private Color wrongColor = Color.red;
    [SerializeField] private TMP_InputField answerInput;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private float popScale = 1.2f;
    [SerializeField] private float popDuration = 0.2f;

    [SerializeField] private float shakeDuration = 0.3f;
    [SerializeField] private float shakeStrength = 10f;

    private const int CorrectAnswer = 11;

    public void CheckAnswer()
    {
        var raw = answerInput.text.Trim();

        if (!int.TryParse(raw, out var value))
        {
            resultText.text = "Wrong (enter a number)";
            return;
        }

        // resultText.color = (value == CorrectAnswer) ? correctColor : wrongColor;
        // resultText.text  = (value == CorrectAnswer) ? "Correct" : "Wrong";

        // StopAllCoroutines();

        if (value == CorrectAnswer)
        {
            resultText.color = correctColor;
            resultText.text = "Correct";
            StartCoroutine(PopAnimation());
        }
        else
        {
            resultText.color = wrongColor;
            resultText.text = "Wrong";
            StartCoroutine(ShakeAnimation());
        }
    }

    private IEnumerator PopAnimation()
    {
        Vector3 originalScale = resultText.transform.localScale;
        Vector3 targetScale = originalScale * popScale;

        float t = 0f;
        while (t < popDuration)
        {
            t += Time.deltaTime;
            resultText.transform.localScale = Vector3.Lerp(originalScale, targetScale, t / popDuration);
            yield return null;
        }

        t = 0f;
        while (t < popDuration)
        {
            t += Time.deltaTime;
            resultText.transform.localScale = Vector3.Lerp(targetScale, originalScale, t / popDuration);
            yield return null;
        }

        resultText.transform.localScale = originalScale;
    }

    private IEnumerator ShakeAnimation()
    {
        Vector3 originalPos = resultText.transform.localPosition;
        float t = 0f;

        while (t < shakeDuration)
        {
            t += Time.deltaTime;
            float offsetX = Random.Range(-1f, 1f) * shakeStrength;
            resultText.transform.localPosition = originalPos + new Vector3(offsetX, 0, 0);
            yield return null;
        }

        resultText.transform.localPosition = originalPos;
    }
}