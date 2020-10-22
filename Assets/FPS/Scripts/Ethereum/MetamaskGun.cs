using UnityEngine;
using System.Runtime.InteropServices;

public class MetamaskGun: MonoBehaviour
{
  public GameObject metamaskGun;

#if UNITY_WEBGL && !UNITY_EDITOR
  [DllImport("__Internal")] private static extern string GetWalletAddress();
  void Start()
  {
    if (GetWalletAddress() != "null")
    {
      Instantiate(metamaskGun, new Vector3(-20, 1, -1), Quaternion.identity);
    }
  }
#endif

}
