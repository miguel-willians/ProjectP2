using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadTitleScene()
    {
                    Debug.Log("Clicou.");

        SceneManager.LoadScene("TitleScene");
    }
}
