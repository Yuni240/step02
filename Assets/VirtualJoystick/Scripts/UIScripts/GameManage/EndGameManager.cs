using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool gameOver;

    private TextMeshProUGUI scoreTextComponent;
    private int score;
    public string LvlUnlock = "LevelUnlock";

    [HideInInspector]


    private PanelController panelController;
    void Awake()
    {
        if (endManager == null)
        {
            endManager = this;
            DontDestroyOnLoad(gameObject);


        }        else
        {
            Destroy(gameObject);

        }
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreTextComponent.text="Score: "+score.ToString();
    
    
    }  // Update is called once per frame
    void Update()
    {
        
    }

    public void StartResolveSequence()
    {

        StopCoroutine(nameof(ResolveSequence));

        StartCoroutine(ResolveSequence());
    }

    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2f);
        ResolveGame();
    }

    public void ResolveGame()
    {
        if (gameOver==false)
        {
            winGame();
        }
        else
        {
            LoseGame();
        }
    }
    public void winGame()
    {

        ScoreSet();
       panelController.ActivateWin();

        int nextLevel=SceneManager.GetActiveScene().buildIndex +1;

        if (nextLevel > PlayerPrefs.GetInt(LvlUnlock, 0))
        {
            PlayerPrefs.SetInt(LvlUnlock, nextLevel);
        }
    }
    public void LoseGame() {

        ScoreSet();
    panelController.ActivateLose();

    }

    private void ScoreSet() {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score);
        int highScore=PlayerPrefs.GetInt("HighScore" +SceneManager.GetActiveScene().name,0);

        if (score > highScore)
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score);

        //reset score
        score = 0;
    }
    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;

    }
    
    public void RegisterScoreText(TextMeshProUGUI scoreComp)
    {

        scoreTextComponent = scoreComp;
    }
}
