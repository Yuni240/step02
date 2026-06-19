using System.Collections;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool gameOver;

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

    // Update is called once per frame
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
        
       panelController.ActivateWin();
    }
    public void LoseGame() { 
    
    panelController.ActivateLose();

    }
    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;

    }
}
