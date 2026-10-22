using UnityEngine;

public class FireTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Object.FindFirstObjectByType<WinterManager>().WinGame();
        }
    }
}
