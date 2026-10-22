using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform targetPortal;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float exitOffset = 0.1f;
    [SerializeField] private float cooldown = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;
        if (targetPortal == null) return;

        // cooldown stored on the player
        var cd = other.GetComponent<PortalCooldown>();
        if (cd == null) cd = other.gameObject.AddComponent<PortalCooldown>();
        if (Time.time < cd.nextAllowedTime) return;

        cd.nextAllowedTime = Time.time + cooldown;

        Rigidbody rb = other.attachedRigidbody;

        // Y before teleport
        float yBefore = (rb != null) ? rb.position.y : other.transform.position.y;

        // Destination (keep Y)
        Vector3 dest = targetPortal.position + targetPortal.forward * exitOffset;
        dest.y = yBefore;

        if (rb != null)
        {
            rb.position = dest;
            rb.linearVelocity = Vector3.zero;
        }
        else
        {
            other.transform.position = dest;
        }
    }

    private class PortalCooldown : MonoBehaviour
    {
        public float nextAllowedTime;
    }
}