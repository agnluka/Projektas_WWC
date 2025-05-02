using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Fullscreen : MonoBehaviour
{

    public void Change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log( "Fullscreen is now: " + Screen.fullScreen );
    }
    //public Toggle fullScreenToggle;  // Reference to the toggle UI element

    //void Start()
    //{
    //    // Ensure the initial state matches the current screen mode
    //    fullScreenToggle.isOn = Screen.fullScreen;

    //    // Add listener to handle toggle changes
    //    fullScreenToggle.onValueChanged.AddListener(OnToggleValueChanged);
    //}

    //// This method is called when the toggle state changes
    //void OnToggleValueChanged(bool isFullScreen)
    //{
    //    if (isFullScreen)
    //    {
    //        // Set the game to full-screen mode
    //        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    //        Screen.fullScreen = true;
    //    }
    //    else
    //    {
    //        // Set the game to windowed mode
    //        Screen.fullScreen = false;
    //    }
    //}

    //// Optionally, you can handle an in-game button or other events to start in full screen mode:
    //public void StartInFullScreen()
    //{
    //    // Set the game to full screen mode at the beginning
    //    Screen.fullScreen = true;
    //    fullScreenToggle.isOn = true; // Ensure the toggle is marked when fullscreen is enabled
    //}
}
