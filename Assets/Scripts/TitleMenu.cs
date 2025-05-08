using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _titleText;

    [SerializeField]
    private string _nextSceneName = "GameplayScene";

    private void Awake()
    {
        if (_titleText != null)
        {
            _titleText.text = Application.productName;
        }
    }

    public void StartGameAction()
    {
        SceneManager.LoadScene(_nextSceneName);
    }

}
