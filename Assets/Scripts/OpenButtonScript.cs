using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenButtonScript : MonoBehaviour
{
    public int thisLevel;
    public int passedLevel;
    public GameObject saveObject;
    
    void Start() {
        thisLevel = int.Parse(this.gameObject.GetComponentInChildren<Text>().text);
        saveObject = GameObject.Find("ScriptedObject");
        passedLevel = PlayerPrefs.GetInt("SavedPassedLevels");
        if(thisLevel - 1 > passedLevel)
        {
            this.gameObject.SetActive(false);
        }
    }
}
