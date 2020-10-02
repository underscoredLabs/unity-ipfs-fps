using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public Text timerText;
  private float startTime;
  public static float score;

  // Start is called before the first frame update
  void Start()
  {
    startTime = Time.time;
  }

  // Update is called once per frame
  void Update()
  {
    float t = Time.time - startTime;
    score = 99999 - Mathf.Round(t * 100);
    if (score < 0) score = 0;
    PlayerPrefs.SetString("score", score.ToString());
    timerText.text = "Score: " + score;
  }
}
