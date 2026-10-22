using UnityEngine;

public class SuspectsPanelController : MonoBehaviour
{
    public void SelectCorrectSuspect()
    {
        Debug.Log("Correct choice! You identified the right suspect.");
    }

    public void SelectWrongSuspect()
    {
        Debug.Log("Wrong choice! This suspect is not the murderer.");
    }
}
