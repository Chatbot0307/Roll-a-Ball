using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private PlayerInputAction inputAction;
    private Rigidbody rb;

    private void Awake()
    {
        inputAction = new PlayerInputAction();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputAction.Player.Enable();
    }

    private void OnDisable()
    {
        inputAction.Player.Disable();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 inputVector = inputAction.Player.Move.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        rb.AddForce(moveDirection * moveSpeed);
    }

}
