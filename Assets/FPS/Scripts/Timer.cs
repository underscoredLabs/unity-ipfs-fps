using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public Text timerText;
  private float startTime;

  // Start is called before the first frame update
  void Start()
  {
    startTime = Time.time;
  }

  // Update is called once per frame
  void Update()
  {
    float t = Time.time - startTime;
    string currentTime = "Score: " + Mathf.Round(t * 100).ToString();
    PlayerPrefs.SetString("timer", currentTime);
    timerText.text = PlayerPrefs.GetString("timer");
  }
}
