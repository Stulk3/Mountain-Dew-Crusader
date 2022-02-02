using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [Header("Fade Duration")]
    [SerializeField] private float FadeInTime = 2.0f; 
    [SerializeField] private float FadeOutTime = 2.0f; 

    [Header("Fade Image")]
    private GameObject FadeGameObject;
    private Image FadeImage;

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
        CheckForFadeGameObject();
        CheckForFadeImageComponent();
        DontDestroyOnLoad(this.gameObject);


    }

    public void FadeToNextScene()
    {
        StartCoroutine(FadeOut());
    } 


    IEnumerator FadeOut()
    {
        FadeInTime = FadeInTime - 0.01f;

        yield return new WaitForFixedUpdate();
        
        yield return StartCoroutine(FadeOut());
    }

    void CheckForFadeImageComponent()
    {
        if (FadeGameObject == null)
        {
            FadeGameObject = GameObject.Find("Fade");
        } 
    }
     void CheckForFadeGameObject()
    {
        if (FadeGameObject == null)
        {
            FadeGameObject = GameObject.Find("Fade");
        } 
    }
}
