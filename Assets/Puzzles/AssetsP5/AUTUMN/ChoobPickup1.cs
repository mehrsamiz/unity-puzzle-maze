using UnityEngine;

public class ChoobPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inv = other.GetComponent<PlayerInventory>();
        if (inv != null)
        {
            inv.CollectChoob();
            Destroy(gameObject);
        }
    }
}
