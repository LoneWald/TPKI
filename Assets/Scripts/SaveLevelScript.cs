using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveLevelScript : MonoBehaviour
{
    public int passedLevels = 0;
    public string menuWord = "Начать!";

    void Awake() {
        LoadGame();
    }

    void Start() {
        
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("SavedPassedLevels", passedLevels);
        if(passedLevels >= 1)
            PlayerPrefs.SetString("SavedMenuWord", "Продолжить");
        else 
            PlayerPrefs.SetString("SavedMenuWord", "Начать!");
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedPassedLevels"))
        {
            passedLevels = PlayerPrefs.GetInt("SavedPassedLevels");
            menuWord = PlayerPrefs.GetString("SavedMenuWord");
        }
        else
            Debug.LogError("There is no save data!");
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        passedLevels = 0;
        menuWord = "Начать!";
    }

    public void SetLevel(int level)
    {
        passedLevels = level;
        SaveGame();
    }

    public int PassedLevels()
    {
        return passedLevels;
    }
}
