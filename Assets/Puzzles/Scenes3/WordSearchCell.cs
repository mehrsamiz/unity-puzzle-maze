using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordSearchCell : MonoBehaviour
{
    public char Letter { get; private set; }
    public int Row { get; private set; }
    public int Column { get; private set; }
    private Image bg;
    private TMP_Text txt;
    private bool isSelected = false;

    public void SetPosition(int row, int col)
    {
        Row = row;
        Column = col;
    }

    private Manager manager;

    void Awake()
    {
        bg = GetComponent<Image>();
        txt = GetComponentInChildren<TMP_Text>();
        manager = FindFirstObjectByType<Manager>();
    }

    public void SetLetter(char c)
    {
        Letter = c;
        txt.text = c.ToString();
    }

    public void Toggle()
    {
        if (isSelected)
        {
            isSelected = false;
            bg.color = Color.white;
            manager.RemoveCell(this);
        }
        else
        {
            isSelected = true;
            bg.color = Color.yellow;
            manager.AddCell(this);
        }
    }
}