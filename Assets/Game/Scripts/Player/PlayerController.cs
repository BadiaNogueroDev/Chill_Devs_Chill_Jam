using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerStates 
{
    MOVING,
    ROTATING,
}

public class PlayerController : MonoBehaviour
{
    public PlayerStates playerState;

    private Rigidbody rigidbody;
    private bool descending;
    private float angle = 0;

    [SerializeField] private Vector3 StartingPosition;

    [Header("Limitadors")]
    [SerializeField] private float limitHorizontal;
    [SerializeField] private float limitVertical;
    [SerializeField] private float limitForward;
    [SerializeField] private float limitRotation;

    [Header("Velocitats")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float verticalSpeed;

    [Header("Rotacio")]
    [SerializeField] private bool invertRotation;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //transform.position = new Vector3(0,limitVertical,-limitForward);
        transform.position = StartingPosition;
    }

    private void FixedUpdate()
    {
        float verticalForce = descending ? -1 : 1;
        CheckLimit(limitVertical, transform.position.y, ref verticalForce);
        
        rigidbody.AddForce(new Vector3(0, verticalForce, 0) * verticalSpeed);
    }

    public void Descend(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
            descending = true;
        else if (callbackContext.canceled)
            descending = false;
    }

    public void Rotate(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
            playerState = PlayerStates.ROTATING;
        else if (callbackContext.canceled)
            playerState = PlayerStates.MOVING;
    }

    public void MouseMove(InputAction.CallbackContext callbackContext)
    {
        Vector2 mouseDelta = callbackContext.ReadValue<Vector2>() * 0.05f;
        
        switch (playerState)
        {
            case PlayerStates.MOVING:
                CheckLimit(limitHorizontal, transform.position.x, ref mouseDelta.x);
                CheckLimit(limitForward, transform.position.z, ref mouseDelta.y);
                
                rigidbody.AddForce(new Vector3(mouseDelta.x, 0, mouseDelta.y) * moveSpeed);
                break;
            
            case PlayerStates.ROTATING:
                angle += mouseDelta.x * rotationSpeed;
                angle = Mathf.Clamp(angle, -limitRotation, limitRotation);
                
                transform.rotation = Quaternion.Euler(0, 0, angle * (invertRotation ? 1 : -1));
                break;
        }
    }

    private void CheckLimit(float limit, float axisPosition, ref float axisMovement)
    {
        if (axisPosition >= limit && axisMovement >= 0 || axisPosition <= -limit && axisMovement <= 0)
        {
            axisMovement = 0f;
        }
    }
}