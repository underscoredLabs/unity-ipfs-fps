using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmitScoreScene : MonoBehaviour
{
  public void OnClick()
  {
    // change scene to HighScoreScene
    SceneManager.LoadScene("HighScoreScene", LoadSceneMode.Additive);
  }
}
