using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    // For demonstration, let's keep this simple:
    // It can handle placing objects in the scene.

    public GameObject objectPrefab;

    public void PlaceObject(Vector3 position)
    {
        // Spawns an objectPrefab at the given position
        if (objectPrefab != null)
        {
            Instantiate(objectPrefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No objectPrefab assigned to PlacementManager!");
        }
    }
}
