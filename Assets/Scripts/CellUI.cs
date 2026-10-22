using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CellUI : MonoBehaviour
{
    [Header("Position")]
    public int Row;
    public int Col;

    [Header("UI References")]
    public TextMeshProUGUI Text;   // حرف داخل سلول
    public Image Background;       // پس‌زمینه سلول

    private Button _button;
    private WordSearchGame _game;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    /// <summary>
    /// این متد توسط WordSearchGame بعد از Instantiate صدا زده می‌شود
    /// </summary>
    public void Init(WordSearchGame game, int row, int col, string letter)
    {
        _game = game;
        Row = row;
        Col = col;

        if (Text != null)
            Text.text = letter;

        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(OnClick);

        SetHighlight(false);
    }

    private void OnClick()
    {
        if (_game == null)
        {
            Debug.LogError("WordSearchGame به CellUI وصل نشده!");
            return;
        }

        _game.OnCellClicked(this);
    }

    /// <summary>
    /// روشن / خاموش کردن هایلایت سلول
    /// </summary>
    public void SetHighlight(bool on)
    {
        if (Background == null) return;

        Background.color = on
            ? new Color(0.2f, 0.6f, 0.2f, 1f)   // سبز
            : Color.black;                    // مشکی
    }
}
