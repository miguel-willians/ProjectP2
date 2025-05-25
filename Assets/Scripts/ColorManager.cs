using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    public enum PlayerColor { Silver, Gold }
    public PlayerColor currentColor = PlayerColor.Silver;

    private SpriteRenderer sprite;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetColor(PlayerColor.Silver);  // Cor inicial prata
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetColor(PlayerColor.Silver);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetColor(PlayerColor.Gold);
    }

    public void SetColor(PlayerColor color)
    {
        currentColor = color;

        switch (color)
        {
            case PlayerColor.Silver:
                sprite.color = new Color(0.75f, 0.75f, 0.75f); // Silver
                break;
            case PlayerColor.Gold:
                sprite.color = new Color(1.0f, 0.84f, 0.0f); // Gold
                break;
        }
    }
}
