using NUnit.Framework.Interfaces;
using UnityEngine;

public class BossBaseState : MonoBehaviour
{
    protected Camera mainCam;
    
    protected float maxLeft;
    protected float maxRight;
    protected float maxUp;
    protected float maxDown;


    private void Awake()
    {
       mainCam=Camera.main; 
    }
    protected virtual void Start()
    {
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.2f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.8f, 0)).x;
        maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
        maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.9f)).y;

    }
    public virtual  void RunState()
    {

    }

    public virtual void  StopState()
    {

    }

}
