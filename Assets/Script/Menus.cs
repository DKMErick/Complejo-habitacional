using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menus : MonoBehaviour
{
    public string SceneName;
    public bool New_Game;
    public GameObject PanelFadeOut;

    public void NewGame()
    {
        PanelFadeOut.SetActive(true);
    }

    public void Continue()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
