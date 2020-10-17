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
    string fromAddress = "0x06C403f435d63835D027F517C2a231a663a1cF5E";
    string contractAddress = "0xfeF8684259C1CBf3F436A57D83A5EB78b0D0bfcC";

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
