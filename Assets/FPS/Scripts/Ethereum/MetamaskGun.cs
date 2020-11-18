using UnityEngine;
using System.Runtime.InteropServices;

public class MetamaskGun: MonoBehaviour
{
  [SerializeField]
  private GameObject MetamaskPickup;
  [SerializeField]
  private GameObject MetamaskLocation;

#if UNITY_WEBGL && !UNITY_EDITOR
  [DllImport("__Internal")] private static extern string GetWalletAddress();
  void Start()
  {
    if (GetWalletAddress() != "null")
    {
      Instantiate(MetamaskPickup, MetamaskLocation.transform.position, MetamaskLocation.transform.rotation);
    }
  }
#endif

}
