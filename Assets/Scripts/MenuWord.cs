using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWord : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SavedMenuWord"))
        {
            this.GetComponent<Text>().text = PlayerPrefs.GetString("SavedMenuWord");
        }
        this.GetComponent<Text>().text = "Начать!";
    }
}
