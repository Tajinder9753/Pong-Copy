using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;
    private InputAction m_moveAction;
    private Vector2 moveInput;
    Rigidbody2D rb;

    private void Awake()
    {
        m_moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnEnable()
    {
        m_moveAction.Enable();
    }

    private void OnDisable()
    {
        m_moveAction.Disable();
    }

    private void FixedUpdate()
    {
        moveInput = m_moveAction.ReadValue<Vector2>();
        rb.linearVelocityY = moveInput.y * moveSpeed;
    }
}
