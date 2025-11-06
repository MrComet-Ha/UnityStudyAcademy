using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class MovementInput : MonoBehaviour
{
    //MMOMove control;
    [SerializeField] float Speed = 2f;
    [SerializeField]Vector2 moveInput;
    private void Awake()
    {
        //control = new MMOMove();
        // Delegate 문법 & 람다식
        //control.GroundPlayer.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }
    public void OnMovement(InputAction.CallbackContext callback)
    {
        moveInput = callback.ReadValue<Vector2>();
    }
    public void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    
    private void OnEnable()
    {
        //control.GroundPlayer.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // 원시적인 Input
        //if (Input.GetKeyDown(KeyCode.Space))
        //    Debug.Log("KeyPressed");
        //if (Input.GetKeyUp(KeyCode.Space))
        //    Debug.Log("KeyReleased");
        //if (Input.GetKey(KeyCode.Space))
        //    Debug.Log("KeyPressing!");
        //Debug.Log($"현재 좌표 : {Input.mousePosition} - 델타 : {Input.mousePositionDelta}");

        // InputManager
        //Debug.Log(Input.GetAxis("Horizontal"));

        // InputSystem
        transform.Translate(moveInput * Speed *  Time.deltaTime);
    }

    private void OnDisable()
    {
        //control.GroundPlayer.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Debug.Log("닿았어");
        }
    }
}
