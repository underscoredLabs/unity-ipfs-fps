using System.Collections;
using UnityEngine;
using Nethereum.JsonRpc.UnityClient;
using Opensea.Contracts.ERC721Full.ContractDefinition;
using System.Runtime.InteropServices;

public class NFTSpawn : MonoBehaviour
{
  public GameObject[] NFTItems;
  public Transform[] NFTLocations;

#if UNITY_WEBGL && !UNITY_EDITOR
  [DllImport("__Internal")] private static extern string GetWalletAddress();

  public void Start()
  {
    if (GetWalletAddress() != "null")
    {
      StartCoroutine(FetchOwnerOf());
    }
  }

  private IEnumerator FetchOwnerOf()
  {
    string url = "https://rinkeby.infura.io/v3/fbc0597d7f784931a68acca3eb26f65b";
    string contractAddress = "0xcB04BF3E72C5448f1368084Bb312b2F0B2f6529f";
    string userAddress = GetWalletAddress(); // "0xbC8C6d48aC0D36DE5D4d543b73e49E1Ec512A196";

    // loop through user tokens
    var tokenIndex = 0;
    var tokenId = 1;
    while (tokenId != 0)
    {
      var queryRequest = new QueryUnityRequest<TokenOfOwnerByIndexFunction, TokenOfOwnerByIndexOutputDTO>(url, contractAddress);
      yield return queryRequest.Query(new TokenOfOwnerByIndexFunction() { Owner = userAddress, Index = tokenIndex }, contractAddress);
      tokenId = (int)queryRequest.Result.ReturnValue1;
      if (tokenId != 0)
      {
        Instantiate(NFTItems[tokenId], NFTLocations[tokenId].position, NFTLocations[tokenId].rotation);
      }
      tokenIndex++;
    }
  }
#endif
}