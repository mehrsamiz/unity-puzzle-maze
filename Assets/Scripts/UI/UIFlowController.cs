using UnityEngine;

public class UIFlowController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject panelQuestion;
    [SerializeField] private GameObject panelClues;
    [SerializeField] private GameObject panelSuspects;

    private int currentStep = 0;

    private void Start()
    {
        ShowPanel(0); // شروع با Question
    }

    public void Next()
    {
        currentStep++;
        ShowPanel(currentStep);
    }

    private void ShowPanel(int step)
    {
        panelQuestion.SetActive(false);
        panelClues.SetActive(false);
        panelSuspects.SetActive(false);

        switch (step)
        {
            case 0:
                panelQuestion.SetActive(true);
                break;

            case 1:
                panelClues.SetActive(true);
                break;

            case 2:
                panelSuspects.SetActive(true);
                break;
        }
    }
}
