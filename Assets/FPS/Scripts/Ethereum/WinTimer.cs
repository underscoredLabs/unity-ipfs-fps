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
    winTimerText.text = PlayerPrefs.GetString("timer");
  }

}
