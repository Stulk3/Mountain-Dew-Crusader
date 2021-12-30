using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public Animator FadeAnimator;

    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void FadeOnNextScene()
    {
        FadeAnimator.SetTrigger("FadeTrigger");
    } 

}
