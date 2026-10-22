using UnityEngine;

public class UnboxingPuzzle : MonoBehaviour
{
    [Header("Game Data")]
    public int correctOptionIndex = 2; // Option C

    private bool hasAttempted = false;

    // Called by UI buttons
    public void SelectOption(int optionIndex)
    {
        if (hasAttempted) return;
        hasAttempted = true;

 
        bool success = (optionIndex == correctOptionIndex);

      
        PuzzleManager.Instance.OnPuzzleComplete(success);

       
        if (!success) hasAttempted = false;
    }
}
