using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public string endingSceneName; // Nome da cena que você quer carregar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Fase Finalizada!");
            SceneManager.LoadScene(endingSceneName);
        }
    }
}
