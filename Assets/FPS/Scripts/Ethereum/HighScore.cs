using UnityEngine;
using System.Collections;
using Nethereum.JsonRpc.UnityClient;
using LeaderboardSolidityContract.Contracts.Leaderboard.ContractDefinition;

public class HighScore : MonoBehaviour
{
  public void Start()
  {
    StartCoroutine(FetchHighScore());
  }

  private IEnumerator FetchHighScore()
  {
    string url = "https://rinkeby.infura.io/v3/7238211010344719ad14a89db874158c";
    string contractAddress = "0xfeF8684259C1CBf3F436A57D83A5EB78b0D0bfcC";
    for (int leaderboardIndex = 0; leaderboardIndex < 10; leaderboardIndex++) {
      var queryRequest = new QueryUnityRequest<LeaderboardFunctionBase, LeaderboardOutputDTOBase>(url, contractAddress);
      yield return queryRequest.Query(new LeaderboardFunctionBase() { ReturnValue1 = leaderboardIndex }, contractAddress);
      print(queryRequest.Result.User + queryRequest.Result.Score);
    }
  }

}
