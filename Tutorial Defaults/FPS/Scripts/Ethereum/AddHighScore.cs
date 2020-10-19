using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nethereum.JsonRpc.UnityClient;
using LeaderboardSolidityContract.Contracts.Leaderboard.ContractDefinition;
using static Timer;
using static PrivateKey;

public class AddHighScore : MonoBehaviour
{
  public Button submitButton;
  public InputField playerNameInput;
  private string txHash;
  private bool hasSubmitted = false;
  public void OnClick()
  {
    if (hasSubmitted == true)
    {
      string url = "https://rinkeby.etherscan.io/tx/" + txHash;
      Application.ExternalEval($"window.open(\" {url} \")");
    }
    else
    {
      StartCoroutine(AddScore());
    }
  }

  void Update()
  {
    submitButton.interactable = false;
    if (playerNameInput.text != "") submitButton.interactable = true;
    if (hasSubmitted == true) submitButton.GetComponentInChildren<Text>().text = "View Transaction";
  }

  private IEnumerator AddScore()
  {
    string url = "https://rinkeby.infura.io/v3/fbc0597d7f784931a68acca3eb26f65b";
    string fromAddress = "0xcAdf00cB9a90892e1eE28ef1Ec4b00E8241D6957";
    string contractAddress = "0x1931d2436288c4489a7849a7eebda6dfb47d63d7";

    var transactionTransferRequest = new TransactionSignedUnityRequest(url, PrivateKey.RINKEBY);
    var transactionMessage = new AddScoreFunctionBase
    {
      FromAddress = fromAddress,
      // shorten player name
      User = playerNameInput.text.Length > 10 ? playerNameInput.text.Substring(0, 10) : playerNameInput.text,
      Score = (int)Timer.score,
    };
    yield return transactionTransferRequest.SignAndSendTransaction(transactionMessage, contractAddress);
    txHash = transactionTransferRequest.Result;
    hasSubmitted = true;
  }
}
