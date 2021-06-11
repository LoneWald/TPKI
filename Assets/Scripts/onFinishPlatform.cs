using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onFinishPlatform : MonoBehaviour
{
    private int thisLevel;
    void Start()
    {
        thisLevel = int.Parse(this.name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            if (PlayerPrefs.HasKey("SavedPassedLevels"))
            {
                if (thisLevel > PlayerPrefs.GetInt("SavedPassedLevels"))
                {
                    SaveLevel();
                }
            }
            else
            {
                SaveLevel();
            }
            SceneManager.LoadScene("Finish");
        }
    }

    private void SaveLevel()
    {
        PlayerPrefs.SetInt("SavedPassedLevels", thisLevel);
        PlayerPrefs.SetString("SavedMenuWord", "Продолжить");
        PlayerPrefs.Save();
    }
}
