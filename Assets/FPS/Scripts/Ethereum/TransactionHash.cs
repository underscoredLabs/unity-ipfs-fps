using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AddHighScore;
public class TransactionHash : MonoBehaviour
{
  public void OnClick()
  {
    string url = "https://rinkeby.etherscan.io/tx/" + AddHighScore.txHash;
    Application.OpenURL(url);
  }
}
