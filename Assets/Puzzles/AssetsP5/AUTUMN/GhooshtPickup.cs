using UnityEngine;

public class GooshtPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inv = other.GetComponent<PlayerInventory>();
        if (inv != null)
        {
            inv.CollectGoosht();
            Destroy(gameObject);
        }
    }
}
