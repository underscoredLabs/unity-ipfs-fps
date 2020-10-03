using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nethereum.JsonRpc.UnityClient;
using LeaderboardSolidityContract.Contracts.Leaderboard.ContractDefinition;
using static Timer;

public class WinTimer : MonoBehaviour
{

  public Text timerText;
  public Button submitScore;

  // Start is called before the first frame update
  void Start()
  {
    submitScore.gameObject.SetActive(false);
    timerText.text = "Score: " + Timer.score.ToString();
    StartCoroutine(FetchHighScore());
  }

  private IEnumerator FetchHighScore()
  {
    string url = "https://rinkeby.infura.io/v3/7238211010344719ad14a89db874158c";
    string contractAddress = "0xfeF8684259C1CBf3F436A57D83A5EB78b0D0bfcC";
    int leaderboardIndex = 9;
    // fetch leaderboard from eth smart contract
    var queryRequest = new QueryUnityRequest<LeaderboardFunctionBase, LeaderboardOutputDTOBase>(url, contractAddress);
    yield return queryRequest.Query(new LeaderboardFunctionBase() { ReturnValue1 = leaderboardIndex }, contractAddress);
    int lowestLeaderboardScore = (int)queryRequest.Result.Score;
    if (Timer.score > lowestLeaderboardScore)
    {
      submitScore.gameObject.SetActive(true);
    }
  }

}
