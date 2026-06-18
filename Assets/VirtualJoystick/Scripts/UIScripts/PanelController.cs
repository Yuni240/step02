using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup cGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    private PanelController panelCntroller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EndGameManager.endManager.RegisterPanelController(this);
    }

    // Update is called once per frame
    public void ActivateWin()
    {
        cGroup.alpha = 1;
        cGroup.interactable = true;
        winScreen.SetActive(true);
    }

    public void ActivateLose()
    {
        cGroup.alpha = 1;
        cGroup.interactable = true;
        loseScreen.SetActive(true);

    }
    /*public void ActivateLose(string text)
    {
        cGroup.alpha = 1;
        loseScreen.SetActive(true);
    }*/
    
}