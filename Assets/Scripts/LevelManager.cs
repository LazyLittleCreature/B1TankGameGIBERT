using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelManager : MonoBehaviour
{
    public bool gameActive = true;
    private bool win = false;

    //End Level
    public List<GameObject> ennemies;
    public List<GameObject> player;
    
    //UI
    public UIDocument winDocument;
    public UIDocument inGameDocument;

    public VisualElement winBackground;
    public VisualElement inGameBackground;

    public void Start()
    {
        //Reference to UI Document
        var winRoot = winDocument.rootVisualElement;
        var inGameRoot = inGameDocument.rootVisualElement;

        winBackground = winRoot.Q<VisualElement>("Background");
        inGameBackground = inGameRoot.Q<VisualElement>("PlayerInfoBox");

        inGameBackground.style.display = DisplayStyle.Flex;
        winBackground.style.display = DisplayStyle.None;
    }

    void Update()
    {
        if (ennemies.Count <= 0)
        {
            if (win == false)
            {
                Debug.Log("Ennemies Defeated");
                win = true;
            }

        }
        else if (player.Count <= 0)
        {
            gameActive = false;
        }
        
        if (gameActive == false && win)
        { 
            winBackground.style.display = DisplayStyle.Flex;
            inGameBackground.style.display = DisplayStyle.None;
        }
    }
    
    public void EnnemyDead(GameObject ennemy)
    {
        if (ennemies.Contains(ennemy))
        {
            Debug.Log("Item touched");
            ennemies.Remove(ennemy);
        }
    }
}