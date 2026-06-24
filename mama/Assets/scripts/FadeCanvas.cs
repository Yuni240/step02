
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
public class FadeCanvas : MonoBehaviour
{
    public static FadeCanvas fader;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private   GameObject loadingScreen;
    [SerializeField] private Image loadingBar;
    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Awake()
    {
        if (fader == null)
        {
            fader = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FaderLoadString(string levelName)
    {
        StartCoroutine(FadeOut(levelName));
    }

    // Update is called once per frame
    IEnumerator FadeIn()
    {
        loadingScreen.SetActive(false);
        fadeStarted = false;
        while (canvasGroup.alpha > 0)
        {
            if(fadeStarted)
            
                yield break;
            
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
           Debug.Log("Fading In");
        }
    }

    public void FaderLoadInt(int levelIndex)
    {
        StartCoroutine(FadeOut(levelIndex));
    }
    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeOut(string levelName)
    {
        if (canvasGroup.alpha != 0)
            yield break;
        if (fadeStarted)
        
            yield break;
        
        fadeStarted = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }
        //SceneManager.LoadScene(levelName);
          //

       // StartCoroutine(FadeIn());   //

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);

       // yield return new WaitForSeconds(0.1f);    //

        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);

        loadingBar.fillAmount = 0f;

        while (ao.isDone == false)
        {
            loadingBar.fillAmount= ao.progress / 0.9f;

            if (ao.progress == 0.9f)
            {
                
                ao.allowSceneActivation = true;
            }
            yield return null;
        }
           

        StartCoroutine(FadeIn());
    }
    IEnumerator FadeOut(int levelIndex)
    {
        if(fadeStarted)
            yield break;

        fadeStarted = true;

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }

        AsyncOperation ao = SceneManager.LoadSceneAsync(levelIndex);
        ao.allowSceneActivation = false;
        loadingScreen.SetActive(true);

        loadingBar.fillAmount = 0f;

        while (ao.isDone == false)
        {
            loadingBar.fillAmount = ao.progress / 0.9f;

            if (ao.progress == 0.9f)
            {

                ao.allowSceneActivation = true;
            }
            yield return null;
        }

       /* if (fadeStarted)
        {
            yield break;
        }
        fadeStarted = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }*/
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(0.1f);    
        StartCoroutine(FadeIn());
    }

}