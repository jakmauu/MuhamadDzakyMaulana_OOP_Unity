using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Singleton
public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Awake()
    {
        animator.enabled = false;
    }

    IEnumerator LoadSceneAsync(string Main)
    {
        animator.enabled = true;

        //animator.SetTrigger("startTransition");

        yield return new WaitForSeconds(0);

        SceneManager.LoadSceneAsync(Main);

        animator.SetTrigger("endTransition");

        Player.Instance.transform.position = new(0, -4.5f);
    }

    public void LoadScene(string Main)
    {
        StartCoroutine(LoadSceneAsync(Main));
    }
}