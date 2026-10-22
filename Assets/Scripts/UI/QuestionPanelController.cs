using UnityEngine;

public class QuestionPanelController : MonoBehaviour
{
    [SerializeField] private GameObject introPage;
    [SerializeField] private GameObject qPage;

    private void Start()
    {
        introPage.SetActive(true);
        qPage.SetActive(false);
    }

    public void ShowQ()
    {
        introPage.SetActive(false);
        qPage.SetActive(true);
    }
}
