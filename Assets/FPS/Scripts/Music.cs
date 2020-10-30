using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
  public AudioSource BackgroundMusic;
  public static bool isPlaying = true;

  // Update is called once per frame
  public void isOn(bool playing)
  {
    if (playing)
    {
      BackgroundMusic.Play();
    }
    else
    {
      BackgroundMusic.Stop();
    }
  }
}
