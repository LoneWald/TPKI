using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Button _menu;
    void Start()
    {
        Cursor.visible = true;
    }
    void Update()
    {
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Manual()
    {
        SceneManager.LoadScene(3);
    }
}
