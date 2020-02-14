using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject option_Options;
    public GameObject menuOptions;
    public void onPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void onExit()
    {
        Application.Quit();

    }

    public void onOptions()
    {
        menuOptions.gameObject.SetActive(false);
        option_Options.gameObject.SetActive(true);
    }

    public void onBack()
    {
        menuOptions.gameObject.SetActive(true);
        option_Options.gameObject.SetActive(false);
    }
}
