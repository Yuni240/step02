using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 offset;
    private float maxLeft;
    private float maxRight;
    private float maxUp;
    private float maxDown;

    void Awake()
    {
        mainCam = Camera.main;
    }

    void Start()
    {
        float z = -Camera.main.transform.position.z;
        maxLeft = mainCam.ViewportToWorldPoint(new Vector3(0.15f, 0, z)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector3(0.85f, 0, z)).x;
        maxDown = mainCam.ViewportToWorldPoint(new Vector3(0, 0.05f, z)).y;
        maxUp = mainCam.ViewportToWorldPoint(new Vector3(0, 0.6f, z)).y;

        Debug.Log("Camera Z: " + Camera.main.transform.position.z);
        Debug.Log("maxLeft: " + maxLeft + " maxRight: " + maxRight);
        Debug.Log("maxDown: " + maxDown + " maxUp: " + maxUp);
    }

    void Update()
    {
        if (Touch.activeTouches.Count > 0 && Touch.fingers[0].isActive)
        {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = mainCam.ScreenToWorldPoint(
                new Vector3(myTouch.screenPosition.x, myTouch.screenPosition.y, -Camera.main.transform.position.z)
            );

            if (myTouch.phase == TouchPhase.Began)
            {
                offset = touchPos - transform.position;
            }
            else
            {
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
            }

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, maxLeft, maxRight),
                Mathf.Clamp(transform.position.y, maxDown, maxUp),
                transform.position.z
            );
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