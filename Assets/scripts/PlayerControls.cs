using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase=UnityEngine.InputSystem.TouchPhase;


public class PlayerControls : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 offset;
     void Awake()
    {
        mainCam = Camera.main;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.fingers[0].isActive)
        {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;
            touchPos = mainCam.ScreenToWorldPoint(touchPos);

            if (Touch.activeTouches[0].phase ==TouchPhase.Began)
            {
                offset =touchPos - transform.position;
            }
            if (Touch.activeTouches[0].phase == TouchPhase.Moved)


                transform.position = new Vector3(touchPos.x -offset.x,touchPos.y-offset.y,0);
            }
            if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
             {
                transform.position = new Vector3(touchPos.x -offset.x,touchPos.y-offset.y,0);

        }
    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }
    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
}
