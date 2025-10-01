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
        rb = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (m_moveAction.WasPressedThisFrame())
        {
            Debug.Log("Moving");
        }
    }
}
