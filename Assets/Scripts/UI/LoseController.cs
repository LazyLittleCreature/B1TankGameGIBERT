using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LoseController : MonoBehaviour
{
    public Button tryAgainButton;
    public Button mainMenuButton;
    
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        tryAgainButton = root.Q<Button>("TryAgain");
        mainMenuButton = root.Q<Button>("MainMenu");

        tryAgainButton.clicked += TryAgainButtonPressed;
        mainMenuButton.clicked += MainMenuButtonPressed;
    }

    void TryAgainButtonPressed()
    {
        SceneManager.LoadScene("1stLEVEL");
    }

    void MainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
