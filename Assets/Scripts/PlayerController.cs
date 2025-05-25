using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        // Verifica se está no chão
        if (collision.contacts[0].normal.y > 0.5f)
            isGrounded = true;

        // Verifica se a plataforma corresponde à cor atual
        if (collision.gameObject.CompareTag("SilverPlatform") && ColorManager.Instance.currentColor != ColorManager.PlayerColor.Silver)
            ReloadScene();

        if (collision.gameObject.CompareTag("GoldPlatform") && ColorManager.Instance.currentColor != ColorManager.PlayerColor.Gold)
            ReloadScene();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
