using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nethereum.JsonRpc.UnityClient;
using LeaderboardSolidityContract.Contracts.Leaderboard.ContractDefinition;

public class AddHighScore : MonoBehaviour
{
  public Button submitButton;
  public Button transactionButton;
  public InputField playerNameInput;
  public static string txHash;
  public bool hasSubmitted = false;
  public void OnClick()
  {
    StartCoroutine(AddScore());
  }

  void Update()
  {
    submitButton.interactable = false;
    transactionButton.interactable = false;
    if (hasSubmitted == false && playerNameInput.text != "") submitButton.interactable = true;
    if (hasSubmitted == true) transactionButton.interactable = true;
  }

  private IEnumerator AddScore()
  {
    string url = "https://rinkeby.infura.io/v3/7238211010344719ad14a89db874158c";
    string privateKey = "07eb6561a3a59a68885d3d3a24f4dc83dfc1842611767cd905c26cf6a7adf61b";
    string fromAddress = "0x06C403f435d63835D027F517C2a231a663a1cF5E";
    string contractAddress = "0xfeF8684259C1CBf3F436A57D83A5EB78b0D0bfcC";

    var transactionTransferRequest = new TransactionSignedUnityRequest(url, privateKey);
    var transactionMessage = new AddScoreFunctionBase
    {
      FromAddress = fromAddress,
      User = playerNameInput.text,
      Score = 1,
    };
    yield return transactionTransferRequest.SignAndSendTransaction(transactionMessage, contractAddress);
    print(transactionTransferRequest.Result);
    txHash = transactionTransferRequest.Result;
    hasSubmitted = true;
  }
}
