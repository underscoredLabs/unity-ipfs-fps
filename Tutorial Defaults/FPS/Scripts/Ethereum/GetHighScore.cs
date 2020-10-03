using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Nethereum.JsonRpc.UnityClient;
using LeaderboardSolidityContract.Contracts.Leaderboard.ContractDefinition;

public class GetHighScore : MonoBehaviour
{
  public Transform highScoreContainer;
  public Transform highScoreRow;
  public Text nameText;
  public Text scoreText;

  public void Start()
  {
    StartCoroutine(FetchHighScore());
  }

  private IEnumerator FetchHighScore()
  {
    string url = "https://rinkeby.infura.io/v3/7238211010344719ad14a89db874158c";
    string contractAddress = "0xfeF8684259C1CBf3F436A57D83A5EB78b0D0bfcC";
    for (int leaderboardIndex = 0; leaderboardIndex < 11; leaderboardIndex++)
    {
      // fetch leaderboard from eth smart contract
      var queryRequest = new QueryUnityRequest<LeaderboardFunctionBase, LeaderboardOutputDTOBase>(url, contractAddress);
      yield return queryRequest.Query(new LeaderboardFunctionBase() { ReturnValue1 = leaderboardIndex }, contractAddress);

      // display on screen
      nameText.text = queryRequest.Result.User.ToString();
      scoreText.text = queryRequest.Result.Score.ToString();
      Transform entryTransform = Instantiate(highScoreRow, highScoreContainer);
      RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
      entryRectTransform.anchoredPosition = new Vector2(0, -25 * leaderboardIndex);
    }
    highScoreRow.gameObject.SetActive(false);
  }

}
