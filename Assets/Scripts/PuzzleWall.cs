using UnityEngine;

public class PuzzleWall : MonoBehaviour
{
    public int puzzleID;

    private bool puzzleInProgress;

    private void OnTriggerEnter(Collider other)
    {
        if  (!other.CompareTag("Player")) return;
        if (puzzleInProgress) return;

        puzzleInProgress = true;
        PuzzleManager.Instance.StartPuzzle(puzzleID, this);
    }

    public void OnPuzzleSolved()
    {
        ScoreManager.Instance.AddPuzzleSuccess();
        Destroy(gameObject);
    }

    public void OnPuzzleFailed()
    {
        puzzleInProgress = false;
        ScoreManager.Instance.DeductPuzzleFail();
    }
}
