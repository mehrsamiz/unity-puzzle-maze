using UnityEngine;
using System.Collections;

public class WinterManager : MonoBehaviour
{
    public GameObject fireObject;
    public WinterUI winterUI;

    PlayerInventory inventory;
    bool gameEnded = false;

    public void StartWinter()
    {
        inventory = Object.FindFirstObjectByType<PlayerInventory>();

        if (inventory == null)
        {
            Debug.LogError("PlayerInventory not found!");
            return;
        }

        if (inventory.IsReadyForWinter())
            StartCoroutine(ReadyScenario());
        else
            StartCoroutine(NotReadyScenario());
    }


    IEnumerator ReadyScenario()
    {
        winterUI.ShowMessage("Search for fire", 10f);
        fireObject.SetActive(true);
        yield return null;
    }

    IEnumerator NotReadyScenario()
    {
        winterUI.ShowMessage("Find the diamond or you will die in 5 minutes", 10f);
        fireObject.SetActive(false);

        yield return new WaitForSeconds(200f);

        if (!gameEnded)
            LoseGame();
    }

    public void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;
    
        GameResultManager.Instance.SetWin();
    
        Time.timeScale = 0f;
    }


    public void LoseGame()
    {
        if (gameEnded) return;
        gameEnded = true;
    
        GameResultManager.Instance.SetLose();
    
        Time.timeScale = 0f;
    }

}
