using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject panel;
    public Text waterText;
    public Text foodText;
    public Text bargText;
    public Text miveText;
    public Text lebasText;
    public Text choobText;
    public Text gooshtText;
    public Text patoText;

    PlayerInventory inventory;
    bool isOpen = false;

    void Start()
    {
        inventory = Object.FindFirstObjectByType<PlayerInventory>();
        panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        panel.SetActive(isOpen);

        if (isOpen)
            UpdateTexts();
    }

    void UpdateTexts()
    {
        waterText.text = inventory.HasWater ? "Water: YES" : "Water: NO";
        foodText.text = inventory.HasFood ? "Food: YES" : "Food: NO";
        bargText.text = inventory.HasBarg ? "Barg: YES" : "Barg: NO";
        miveText.text = inventory.HasMive ? "Mive: YES" : "Mive: NO";
        lebasText.text = inventory.HasLebas ? "Lebas: YES" : "Lebas: NO";
        choobText.text = inventory.HasChoob ? "Choob: YES" : "Choob: NO";
        gooshtText.text = inventory.HasGoosht ? "Goosht: YES" : "Goosht: NO";
        patoText.text = inventory.HasPato ? "Pato: YES" : "Pato: NO";
        
    }
}
