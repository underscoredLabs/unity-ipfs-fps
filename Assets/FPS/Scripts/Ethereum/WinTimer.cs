using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Timer;

public class WinTimer : MonoBehaviour
{

  public Text timerText;
  public Button submitScoreButton;

  // Start is called before the first frame update
  void Start()
  {
    timerText.text = "Your Score: " + Timer.score.ToString();
    if (Timer.score > -5)
    {
      submitScoreButton.gameObject.SetActive(true);
    }
  }

}
