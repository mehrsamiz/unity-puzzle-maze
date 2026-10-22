using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inv = other.GetComponent<PlayerInventory>();
        if (inv != null)
        {
            inv.CollectDiamond();
            Destroy(gameObject);
        }
    }
}
