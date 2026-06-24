using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        int score = PlayerPrefs.GetInt("Score" + SceneManager.GetActiveScene().name, 0);

        scoreText.text="Score: "+score.ToString();

        int highScore=PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);

        highScoreText.text="Highscore:"+highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
