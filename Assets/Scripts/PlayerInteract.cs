using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactRange = 4f;
    public LayerMask puzzleLayer; // Optimization: Only check specific layers

    void Update()
    {
        // Check for "E" key press
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformRaycast();
        }
    }

    void PerformRaycast()
    {
        // Create a ray from the center of the camera view
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Visualize the ray in the Scene view for debugging
        Debug.DrawRay(transform.position, transform.forward * interactRange, Color.red, 1f);

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            // Check if the object we hit has the PuzzleWall script
            PuzzleWall wall = hit.collider.GetComponent<PuzzleWall>();

            if (wall != null)
            {
                // We found a puzzle wall! Trigger the logic.
               // wall.AttemptPuzzle();
            }
        }
    }
}