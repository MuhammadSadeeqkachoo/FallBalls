using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    Button RestartButton;
    [SerializeField]
    Button MainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        if (MainMenuButton != null)
        {
            MainMenuButton.onClick.AddListener(MainMenu);
        }

        if (RestartButton != null)
        {
            RestartButton.onClick.AddListener(RestartGame);
        }
    }


    void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");

    }
    void MainMenu()
    {
        SceneManager.LoadScene("Menu");

    }

}