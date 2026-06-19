using UnityEngine;
using TMPro;

public class ScoreRegistration : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      TextMeshProUGUI textFoRegistration = GetComponent<TextMeshProUGUI>();  
        EndGameManager.endManager.RegisterScoreText(textFoRegistration);
        textFoRegistration.text = "Score: 0";
    }

    // Update is called once per frame
   
}
