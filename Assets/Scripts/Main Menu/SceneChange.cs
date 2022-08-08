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
    [Header("Fade Delay")]

    [SerializeField] private float FadeInDelay = 0.0f;
    [SerializeField] private float FadeOutDelay = 0.0f;
    [Header("Fade Image")]
    [SerializeField] private GameObject FadeGameObject;
    private Image FadeImage;

    private float FadeImageOpacity = 0f;

    private float FadeInOpacityChangeStep;
    private float FadeOutOpacityChangeStep;

    private bool FadeInCompleted;
    private bool FadeOutCompleted;
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
    public void FadeToNextScene()
    {
        StartCoroutine(FadeOut());
    } 
    private void Awake()
    {
        CheckForFadeGameObject();

        CheckForFadeImageComponent();

        CheckForFadeImageOpactity();

        CalculateFadeInOpacityChangeStep();
        CalculateFadeOutOpacityChangeStep();

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() 
    {
        StartCoroutine((FadeIn()));
    }

    private void FixedUpdate() 
    {
        
    }
   

    IEnumerator FadeOut()
    {
        yield return FadeOut();
    }
    IEnumerator FadeIn()
    {
        if(FadeInDelay != 0)
        {
            yield return new WaitForSeconds(FadeInDelay);
            FadeInDelay = 0;
        }

        //yield return new WaitForSeconds(FadeInOpacityChangeStep);
        //yield return new WaitForSeconds(FadeInTime/60);
        for (float i = FadeInTime; i >= 0; i -= i/60)
        {
            Debug.Log(FadeInTime);
            FadeInTime = FadeInTime - (FadeInTime/60);
            DecreaseFadeOpacity();
        }
        
        
        
        if(FadeInTime <= 0)
        {
            StopCoroutine((FadeIn()));
            Debug.LogWarning("Остановилось");
        }
        //yield return StartCoroutine(FadeIn());
        
        
    }

    void CheckForFadeImageComponent()
    {
        if (FadeImage == null)
        {
            FadeImage = FadeGameObject.GetComponent<Image>();
        } 
    }
    void CheckForFadeGameObject()
    {
        if (FadeGameObject == null)
        {
            FadeGameObject = GameObject.Find("Fade");
        } 
    }

    void CheckForFadeImageOpactity()
    {
        FadeImageOpacity = FadeGameObject.GetComponent<Image>().color.a;
    }

    void DecreaseFadeOpacity()
    {
        FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, FadeImage.color.a - FadeInOpacityChangeStep);
    }

    void CalculateFadeInOpacityChangeStep()
    {
        FadeInOpacityChangeStep = FadeInTime/60;
    }
    void CalculateFadeOutOpacityChangeStep()
    {
        FadeOutOpacityChangeStep = FadeInTime/60;
    }
}
