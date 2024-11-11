using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Awake()
    {
        // This could contain initialization logic if needed
    }

    // Method to load a scene
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName)); // Call the coroutine instead
    }

    // Coroutine to handle the asynchronous loading with transition
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Trigger animation for transition if animator is set
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
        }

        // Wait for the transition animation to play
        yield return new WaitForSeconds(1f); // Adjust this based on your animation duration

        // Start loading the new scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene load is complete
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
