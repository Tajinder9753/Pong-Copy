using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;
    private InputAction m_moveAction_player1;
    private InputAction m_moveAction_player2;
    private Vector2 moveInput;
    private Vector2 moveInput2;
    private GameObject player;
    Rigidbody2D rb;

    private void Awake()
    {
        m_moveAction_player1 = InputSystem.actions.actionMaps[0].FindAction("Move");
        m_moveAction_player2 = InputSystem.actions.actionMaps[1].FindAction("Move");
        player = this.gameObject;
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnEnable()
    {
        m_moveAction_player1.Enable();
        m_moveAction_player2.Enable();
    }

    private void OnDisable()
    {
        m_moveAction_player1.Disable();
        m_moveAction_player2.Disable();
    }

    private void FixedUpdate()
    {
        //player1
        if(player.tag.Equals("Player1"))
        {
            Debug.Log("tag correct");
            moveInput = m_moveAction_player1.ReadValue<Vector2>();
            rb.linearVelocityY = moveInput.y * moveSpeed;
        }

        //player2
        if (player.tag.Equals("Player2"))
        {
            Debug.Log("tag correct");
            moveInput = m_moveAction_player2.ReadValue<Vector2>();
            rb.linearVelocityY = moveInput.y * moveSpeed;
        }
    }
}
