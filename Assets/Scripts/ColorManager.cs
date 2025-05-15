using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    public enum PlayerColor { Red, Green, Blue }
    public PlayerColor currentColor = PlayerColor.Red;

    private SpriteRenderer sprite;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetColor(PlayerColor.Red);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetColor(PlayerColor.Red);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetColor(PlayerColor.Green);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetColor(PlayerColor.Blue);
    }

    public void SetColor(PlayerColor color)
    {
        currentColor = color;

        switch (color)
        {
            case PlayerColor.Red:
                sprite.color = Color.red;
                break;
            case PlayerColor.Green:
                sprite.color = Color.green;
                break;
            case PlayerColor.Blue:
                sprite.color = Color.blue;
                break;
        }
    }
}
