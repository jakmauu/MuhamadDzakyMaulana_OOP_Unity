using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    // Reference to LevelManager
    public LevelManager LevelManager { get; private set; }

    private void Awake()
    {
        // Implement singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize LevelManager
        LevelManager = GetComponent<LevelManager>();

        // Destroy all objects except Camera and Player
        DestroyUnwantedObjects();
    }

    private void DestroyUnwantedObjects()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name != "Camera" && obj.name != "Player")
            {
                Destroy(obj);
            }
        }
    }
}
