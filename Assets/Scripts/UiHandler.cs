using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHandler : MonoBehaviour
{
    public GameObject settingsMenu;
    private bool isSettingsOpen = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isSettingsOpen = !isSettingsOpen;
            if(isSettingsOpen)
            {
                settingsMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                settingsMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
