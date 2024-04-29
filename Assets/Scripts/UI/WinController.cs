using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public Button nextLevelButton;
    public Button mainMenuButton;
    
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        nextLevelButton = root.Q<Button>("NextLevel");
        mainMenuButton = root.Q<Button>("MainMenu");

        nextLevelButton.clicked += NextLevelButtonPressed;
        mainMenuButton.clicked += MainMenuButtonPressed;
    }

    void NextLevelButtonPressed()
    {
        SceneManager.LoadScene("2ndLEVEL");
    }

    void MainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
