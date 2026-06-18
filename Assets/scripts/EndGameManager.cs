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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // panelController itaregistiwa na PanelController.Start()
    }

    public void StartResolveSequence()
    {
        StartCoroutine(ResolveSequence());
    }

    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2f);
        ResolveGame();
    }

    public void ResolveGame()
    {
        if (panelController == null)
        {
            Debug.LogError("PanelController haijasajiliwa!");
            return;
        }
        if (gameOver == false)
        {
            winGame();
        }
        else
        {
            loseGame();
        }
    }

    public void winGame()
    {
        panelController.ActivateWin();
    }

    public void loseGame()
    {
        panelController.ActivateLose();
    }

    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }
}