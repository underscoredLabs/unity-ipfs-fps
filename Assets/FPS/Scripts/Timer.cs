using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  public Text timerText;
  private float startTime;
  public static float score;
  private float maxScore = 99999;
  public bool invincible { get; set; }

  // Start is called before the first frame update
  void Start()
  {
    startTime = Time.time;
  }

  // Update is called once per frame
  void Update()
  {
    float t = Time.time - startTime;

    if (GetComponent<ObjectiveManager>().AreAllObjectivesCompleted() == false)
    {
      score =  maxScore - Mathf.Round(t * 100);
    }

    if (invincible)
    {
      maxScore = 0;
    }

    if (score <= 0)
    {
      score = 0;
    }
    timerText.text = "Score: " + score;
  }
}
