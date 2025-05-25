using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colidiu com: " + collision.gameObject.tag);

        if (collision.contacts[0].normal.y > 0.5f)
            isGrounded = true;

        CheckColorCollision(collision.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CheckColorCollision(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void CheckColorCollision(GameObject obj)
    {
        if (obj.CompareTag("GoldTilemap") && ColorManager.Instance.currentColor != ColorManager.PlayerColor.Gold)
        {
            Debug.Log("Cor incorreta no GoldTilemap! Respawn.");
            Respawn();
        }

        if (obj.CompareTag("SilverTilemap") && ColorManager.Instance.currentColor != ColorManager.PlayerColor.Silver)
        {
            Debug.Log("Cor incorreta no SilverTilemap! Respawn.");
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;
        Debug.Log("Respawn realizado.");
    }
}
