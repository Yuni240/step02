using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
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
    [SerializeField] private InputActionReference moveActionToUse;
    [SerializeField] private float Speed;

    void Awake()
    {
        mainCam = Camera.main;
    }

    void Start()
    {
        StartCoroutine(SetBoundaries());
    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(0.4f);
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;
        maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
    }

    void Update()
    {
        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        transform.Translate(moveDirection * Speed * Time.deltaTime);

        if (Touch.activeTouches.Count > 0 && Touch.fingers[0].isActive)
        {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = mainCam.ScreenToWorldPoint(
                new Vector3(myTouch.screenPosition.x, myTouch.screenPosition.y, -Camera.main.transform.position.z)
            );
            if (myTouch.phase == TouchPhase.Began)
            {
                offset = Vector3.zero;
            }
            transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
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