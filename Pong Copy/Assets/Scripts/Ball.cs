using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float throwForce = 5f;
    [SerializeField] private float minHorizontalSpeed = 2f;
    [SerializeField] private float minVerticalSpeed = 1f;

    private GameManager gm;
    private Rigidbody2D rb;

    private void Awake()
    {
        gm = FindAnyObjectByType<GameManager>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {
        // Generate a random direction with sufficient horizontal movement
        float x = Random.Range(0.5f, 1f) * (Random.value < 0.5f ? -1 : 1);
        float y = Random.Range(-1f, 1f);

        Vector2 direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction * throwForce;
    }

    private void FixedUpdate()
    {
        MaintainVelocity();
    }

    private void MaintainVelocity()
    {
        Vector2 velocity = rb.linearVelocity;

        // If horizontal speed is too low, boost it slightly
        if (Mathf.Abs(velocity.x) < minHorizontalSpeed)
        {
            float newX = minHorizontalSpeed * Mathf.Sign(velocity.x == 0 ? Random.Range(-1f, 1f) : velocity.x);
            velocity.x = newX;
            rb.linearVelocity = velocity.normalized * throwForce;
        }
        if (Mathf.Abs(velocity.y) < minVerticalSpeed)
        {
            float newY = minVerticalSpeed * Mathf.Sign(velocity.y == 0 ? Random.Range(-1f, 1f) : velocity.y);
            velocity.y = newY;
        }

        rb.linearVelocity = velocity.normalized * throwForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm.UpdateScore(collision.tag);
        Destroy(gameObject);
    }
}
