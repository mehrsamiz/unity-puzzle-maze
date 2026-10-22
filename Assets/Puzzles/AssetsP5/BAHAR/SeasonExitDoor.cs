using UnityEngine;

public class SeasonExitDoor : MonoBehaviour
{
    public GameObject doorVisual;
    public Collider doorBlocker;

    bool isOpen = false;

    void Start()
    {
        CloseDoor();
    }

    void CloseDoor()
    {
        isOpen = false;
        doorVisual.SetActive(true);
        doorBlocker.enabled = true;
    }

    void OpenDoor()
    {
        isOpen = true;
        doorVisual.SetActive(false);
        doorBlocker.enabled = false;
        FinishGame();
    }

    void OnTriggerEnter(Collider other)
    {
        if (isOpen) return;
        if (!other.CompareTag("Player")) return;

        PlayerInventory inv = other.GetComponent<PlayerInventory>();
        if (inv != null && inv.HasDiamond)
        {
            OpenDoor();
        }
    }

    void FinishGame()
    {
        Debug.Log("GAME FINISHED");
        Time.timeScale = 0f;
    }
}
