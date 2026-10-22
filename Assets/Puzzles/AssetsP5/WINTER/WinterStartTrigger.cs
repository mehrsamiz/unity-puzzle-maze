using UnityEngine;

public class WinterStartTrigger : MonoBehaviour
{
    bool started = false;

    void OnTriggerEnter(Collider other)
    {
        if (started) return;

        if (other.CompareTag("Player"))
        {
            WinterManager wm = Object.FindFirstObjectByType<WinterManager>();
            if (wm != null)
            {
                wm.StartWinter();
                started = true;
            }
        }
    }
}
