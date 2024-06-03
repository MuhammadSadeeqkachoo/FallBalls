using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    // Reference to the TextMeshProUGUI component
    public Button Startbutton;
    public Button quitButton;
    void Start()
    {

        // Add a listener to the button to call the StartGame method when clicked
        if (Startbutton != null)
        {
            Startbutton.onClick.AddListener(StartGame);
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
    }

    void StartGame()
    {

        // Load the specified scene
        SceneManager.LoadScene("Gameplay");

        
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
