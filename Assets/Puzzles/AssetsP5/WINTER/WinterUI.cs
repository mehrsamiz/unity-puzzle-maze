using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinterUI : MonoBehaviour
{
    public Text messageText;

    public void ShowMessage(string msg, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(msg, duration));
    }

    IEnumerator ShowRoutine(string msg, float duration)
    {
        messageText.gameObject.SetActive(true);
        messageText.text = msg;

        yield return new WaitForSeconds(duration);

        messageText.gameObject.SetActive(false);
    }
}
