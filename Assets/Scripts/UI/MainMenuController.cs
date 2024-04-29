using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button playButton;
    public Button controlsButton;
    
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        playButton = root.Q<Button>("PlayButton");
        controlsButton = root.Q<Button>("ControlsButton");

        playButton.clicked += PlayButtonPressed;
        controlsButton.clicked += ControlsButtonPressed;
    }

    void PlayButtonPressed()
    {
        SceneManager.LoadScene("1stLEVEL");
    }

    void ControlsButtonPressed()
    {
        SceneManager.LoadScene("ControlsMenu");
    }
}
