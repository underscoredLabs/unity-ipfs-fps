using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nethereum.JsonRpc.UnityClient;
using Opensea.Contracts.ERC721Full.ContractDefinition;

public class NFTSpawn : MonoBehaviour
{
  public GameObject monolith;
  public Transform monolithLocation;

  public void Start()
  {
    StartCoroutine(FetchOwnerOf());
  }

  private IEnumerator FetchOwnerOf()
  {
    // tokenId starts at 1
    GameObject[] NFTItems = { null, monolith };
    Transform[] NFTLocations = {null, monolithLocation};

    string url = "https://rinkeby.infura.io/v3/7238211010344719ad14a89db874158c";
    string contractAddress = "0xcB04BF3E72C5448f1368084Bb312b2F0B2f6529f";
    string userAddress = "0xbC8C6d48aC0D36DE5D4d543b73e49E1Ec512A197";

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
}
