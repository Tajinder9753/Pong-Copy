using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [SerializeField] private float throwForce = 5f;
    GameManager gm;
    Rigidbody2D rb;

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
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.linearVelocity = randomDirection * throwForce;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm.UpdateScore(collision.tag);
        Destroy(gameObject);
    }
}
