using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadLevelString(string levelName)
    {
        FadeCanvas.fader.FaderLoadString(levelName);
       // SceneManager.LoadScene(levelName);
    }
    public void LoadLevelInt(int levelIndex)
    {
        FadeCanvas.fader.FaderLoadInt(levelIndex);
        // SceneManager.LoadScene(levelIndex);
    }
    public void RestartLevel()
    {
        FadeCanvas.fader.FaderLoadInt(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
