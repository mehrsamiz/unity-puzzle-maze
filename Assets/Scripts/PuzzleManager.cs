using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [Header("Puzzle UI Prefabs")]
    public GameObject[] puzzlePrefabs;

    private GameObject currentActivePuzzle;
    private PuzzleWall currentWall;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void StartPuzzle(int puzzleID, PuzzleWall wall)
    {
        if (currentActivePuzzle != null) return;

        currentWall = wall;
        currentActivePuzzle = Instantiate(puzzlePrefabs[puzzleID]);

        // Optional:
        // PlayerController.Instance.SetMovement(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnPuzzleComplete(bool success)
    {
        if (currentActivePuzzle != null)
            Destroy(currentActivePuzzle);

        if (success)
        {
            
            if (currentWall != null)
            {
                currentWall.OnPuzzleSolved();
            }
        }
        else
        {
            if (currentWall != null)
                currentWall.OnPuzzleFailed();
        }

 
        currentActivePuzzle = null;
        currentWall = null;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
