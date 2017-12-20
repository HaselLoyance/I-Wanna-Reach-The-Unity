﻿///////////////////////////////////////////////////////////////////////
//
//      GameManager.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public DisplayManager DisplayManager = null;

    void Awake()
    {
        // Make sure there is only one GameManager object
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);

        DisplayManager = new DisplayManager(Screen.resolutions, FindObjectOfType<Camera>());
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        //DEBUG/TEST CODE:

        // Restars game from sInit
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Application.LoadLevel(0);
        }

        // Go to the next available resolution
        if (Input.GetKeyDown(KeyCode.F8))
        {
            DisplayManager.ApplyResolution(DisplayManager.NextResolution());
        }
        
        // Go to the previous available resolution
        if (Input.GetKeyDown(KeyCode.F7))
        {
            DisplayManager.ApplyResolution(DisplayManager.PrevResolution());
        }

        // Switch fullscreen mode
        if (Input.GetKeyDown(KeyCode.F4))
        {
            DisplayManager.fullscreen = !DisplayManager.fullscreen;
        }
    }
}
