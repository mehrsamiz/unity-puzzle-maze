using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum SelectionDirection
{
    None,
    Horizontal,
    Vertical,
    Diagonal
}

public class Manager : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;

    private List<WordSearchCell> selectedCells = new();

    private SelectionDirection currentDirection = SelectionDirection.None;

    private readonly HashSet<string> correctWords = new()
    {
        "دانشگاه",
        "فوتبال",
        "خورشید",
        "کتاب",
        "ماشین",
        "درخت",
        "ستاره",
        "مدرسه",
        "دریا",
        "کوه"
    };

    public void AddCell(WordSearchCell cell)
    {
        if (selectedCells.Contains(cell))
            return;

        if (selectedCells.Count == 0)
        {
            selectedCells.Add(cell);
            return;
        }

        if (selectedCells.Count == 1)
        {
            var first = selectedCells[0];
            currentDirection = DetectDirection(first, cell);
            if (currentDirection == SelectionDirection.None)
                return;

            selectedCells.Add(cell);
            return;
        }

        var last = selectedCells[^1];
        if (IsNextInDirection(last, cell, currentDirection))
        {
            selectedCells.Add(cell);
        }
    }

    public void RemoveCell(WordSearchCell cell)
    {
        selectedCells.Remove(cell);

        if (selectedCells.Count < 2)
            currentDirection = SelectionDirection.None;
    }

    public void Submit()
    {
        if (selectedCells.Count == 0)
        {
            resultText.text = "Select letters";
            resultText.color = Color.red;
            return;
        }

        string word = "";
        foreach (var c in selectedCells)
            word += c.Letter;

        char[] chars = word.ToCharArray();
        System.Array.Reverse(chars);
        string reversedWord = new string(chars);

        if (correctWords.Contains(word) || correctWords.Contains(reversedWord))
        {
            resultText.text = "Correct";
            resultText.color = Color.green;
            PuzzleManager.Instance.OnPuzzleComplete(true);
        }
        else
        {
            resultText.text = "Wrong";
            resultText.color = Color.red;
            PuzzleManager.Instance.OnPuzzleComplete(false);
        }
    }

    private SelectionDirection DetectDirection(WordSearchCell a, WordSearchCell b)
    {
        int dr = b.Row - a.Row;
        int dc = b.Column - a.Column;

        if (dr == 0 && Mathf.Abs(dc) == 1)
            return SelectionDirection.Horizontal;

        if (dc == 0 && Mathf.Abs(dr) == 1)
            return SelectionDirection.Vertical;

        if (Mathf.Abs(dr) == 1 && Mathf.Abs(dc) == 1)
            return SelectionDirection.Diagonal;

        return SelectionDirection.None;
    }

    private bool IsNextInDirection(
        WordSearchCell last,
        WordSearchCell next,
        SelectionDirection dir
    )
    {
        int dr = next.Row - last.Row;
        int dc = next.Column - last.Column;

        return dir switch
        {
            SelectionDirection.Horizontal => dr == 0 && Mathf.Abs(dc) == 1,
            SelectionDirection.Vertical => dc == 0 && Mathf.Abs(dr) == 1,
            SelectionDirection.Diagonal => Mathf.Abs(dr) == 1 && Mathf.Abs(dc) == 1,
            _ => false
        };
    }
}