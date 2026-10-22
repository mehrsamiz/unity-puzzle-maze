using TMPro;
using UnityEngine;

public class WordSearchGridBuilder : MonoBehaviour
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject cellPrefab;


    private readonly string[] gridData =
    {
        "فمبهاگشناد",
        "وخستخدرپزی",
        "تاونفلباتک",
        "بلچررپصقمس",
        "ازینشوجهاا",
        "لهقلمیکیشب",
        "هراتسپدویث",
        "وایردقضفنن",
        "پتشهسردمفر",
        "هوکانبتسلگ"
    };

    void Start()
    {
        BuildGrid();
    }

    private void BuildGrid()
    {
        for (int r = 0; r < gridData.Length; r++)
        {
            for (int c = 0; c < gridData[r].Length; c++)
            {
                GameObject cell = Instantiate(cellPrefab, gridParent);
                var cellComp = cell.GetComponent<WordSearchCell>();
                cellComp.SetLetter(gridData[r][c]);
                cellComp.SetPosition(r, c);
            }
        }
    }
}