using System.Collections.Generic;
using UnityEngine;

public class WordSearchGame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform boardGrid;  
    [SerializeField] private GameObject cellPrefab;     

    [Header("Grid Size")]
    [SerializeField] private int rows = 10;
    [SerializeField] private int cols = 10;

    private readonly string[,] grid =
    {
        {"ف","م","ب","ه","ا","گ","ش","ن","ا","د"},
        {"و","خ","س","ت","خ","د","ر","پ","ز","ی"},
        {"ت","ا","و","ن","ف","ل","ب","ا","ت","ک"},
        {"ب","ل","چ","د","د","پ","ص","ق","م","س"},
        {"ا","ز","ی","ن","ش","و","ج","ه","ا","ا"},
        {"ل","ه","ق","ل","م","ی","ک","س","ش","ب"},
        {"ه","ر","ا","ت","س","پ","ه","و","ی","ت"},
        {"و","ا","ی","د","د","ق","ض","ف","ن","ن"},
        {"پ","ت","ش","ه","س","د","ه","م","ف","د"},
        {"ه","و","ک","ا","ن","ب","ت","س","ل","گ"},
    };


    private readonly HashSet<string> validWords = new HashSet<string> { "دانش", "شناد" };

    private readonly List<CellUI> selected = new List<CellUI>();
    private CellUI[,] cells;

    private void Start()
    {
        SpawnGrid();
    }

    private void SpawnGrid()
    {
 
        for (int i = boardGrid.childCount - 1; i >= 0; i--)
            Destroy(boardGrid.GetChild(i).gameObject);

        cells = new CellUI[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                var go = Instantiate(cellPrefab, boardGrid);
                go.name = $"Cell_{r}_{c}";

                var cell = go.GetComponent<CellUI>();
                if (cell == null)
                {
                    Debug.LogError("CellPrefab باید CellUI داشته باشد.");
                    return;
                }

                cell.Init(this, r, c, grid[r, c]);
                cells[r, c] = cell;
            }
        }
    }


    public void OnCellClicked(CellUI cell)
    {

        if (selected.Contains(cell)) return;

        selected.Add(cell);
        cell.SetHighlight(true);


        if (selected.Count == 4)
        {
            ValidateFour();
        }
    }

    private void ValidateFour()
    {
        if (!IsSequential(selected))
        {
            Debug.Log("❌ Invalid: Must be 4 sequential cells.");
            ResetSelection();
            return;
        }

        string word = selected[0].Text.text + selected[1].Text.text + selected[2].Text.text + selected[3].Text.text;

        if (validWords.Contains(word))
        {
            Debug.Log("✅ Correct: " + word);


            PuzzleManager.Instance.OnPuzzleComplete(true);

            ResetSelection();
        }
        else
        {
            Debug.Log("❌ Wrong Word: " + word);


            PuzzleManager.Instance.OnPuzzleComplete(false);

            ResetSelection();
        }
    }

    private void ResetSelection()
    {
        foreach (var c in selected)
            c.SetHighlight(false);

        selected.Clear();
    }

    private bool IsSequential(List<CellUI> list)
    {
        if (list.Count != 4) return false;

        int dr = list[1].Row - list[0].Row;
        int dc = list[1].Col - list[0].Col;

        if (dr < -1 || dr > 1 || dc < -1 || dc > 1) return false;
        if (dr == 0 && dc == 0) return false;

        for (int i = 2; i < list.Count; i++)
        {
            int ndr = list[i].Row - list[i - 1].Row;
            int ndc = list[i].Col - list[i - 1].Col;

            if (ndr != dr || ndc != dc)
                return false;
        }

        return true;
    }
}
