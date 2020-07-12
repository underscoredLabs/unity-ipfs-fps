using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTimer : MonoBehaviour
{

    public Text winTimerText;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetString("timer"));
        winTimerText.text = "Time: " + PlayerPrefs.GetString("timer");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
