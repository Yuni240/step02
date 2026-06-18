using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool gameOver;

    private PanelController panelCntroller;
    void Awake()
    {
        {
            endManager = this;
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
    public void winGame()
    {
        

    }
    public void CloseGame() { 
    
    
    
    }public void RegisterPanelController(PanelController panel)
    {
        panelCntroller = panel;

    }
}
