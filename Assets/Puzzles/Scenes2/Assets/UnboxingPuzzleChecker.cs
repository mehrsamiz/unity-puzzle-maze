using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine;

public class UnboxingPuzzleChecker : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;

    [Header("Colors")]
    [SerializeField] private Color correctColor = Color.green;
    [SerializeField] private Color wrongColor = Color.red;

    [Header("Animation")]
    [SerializeField] private float popScale = 1.2f;
    [SerializeField] private float popDuration = 0.15f;
    [SerializeField] private float shakeDuration = 0.25f;
    [SerializeField] private float shakeStrength = 10f;

    [SerializeField] private Button[] optionButtons;

    private const string CorrectAnswer = "C";

    public void CheckAnswer(string option)
    {
        StopAllCoroutines();
        SetButtonsInteractable(false);

        if (option == CorrectAnswer)
        {
            resultText.text = "Correct";
            resultText.color = correctColor;
            StartCoroutine(PopAnimation());
        }
        else
        {
            resultText.text = "Wrong";
            resultText.color = wrongColor;
            StartCoroutine(ShakeAnimation());
        }
    }

    private IEnumerator PopAnimation()
    {
        Vector3 original = resultText.transform.localScale;
        Vector3 target = original * popScale;

        float t = 0;
        while (t < popDuration)
        {
            t += Time.deltaTime;
            resultText.transform.localScale = Vector3.Lerp(original, target, t / popDuration);
            yield return null;
        }

        t = 0;
        while (t < popDuration)
        {
            t += Time.deltaTime;
            resultText.transform.localScale = Vector3.Lerp(target, original, t / popDuration);
            yield return null;
        }

        resultText.transform.localScale = original;
    }

    private IEnumerator ShakeAnimation()
    {
        Vector3 original = resultText.transform.localPosition;
        float t = 0;

        while (t < shakeDuration)
        {
            t += Time.deltaTime;
            float x = Random.Range(-1f, 1f) * shakeStrength;
            resultText.transform.localPosition = original + new Vector3(x, 0, 0);
            yield return null;
        }

        resultText.transform.localPosition = original;
    }

    private void SetButtonsInteractable(bool value)
    {
        foreach (var btn in optionButtons)
        {
            btn.interactable = value;
        }
    }
}