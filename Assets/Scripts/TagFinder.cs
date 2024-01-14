using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    void Start()
    {
        // Replace "YourTag" with the specific tag you want to search for
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Player");

        // Now 'gameObjects' array contains all GameObjects with the specified tag

        // Example: Log the names of the found GameObjects
        foreach (GameObject go in gameObjects)
        {
            Debug.Log("Found GameObject with tag 'YourTag': " + go.name);
        }
    }
}
