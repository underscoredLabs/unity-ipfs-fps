/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorKeyUI : MonoBehaviour
{
    [Tooltip("The Prefab for a single UI Key")]
    public Transform keyUISinglePrefab;
    [Tooltip("The Key Holder that will be displayed")]
    public DoorKeyHolder doorKeyHolder;

    void Start() 
    {
        if (doorKeyHolder == null) 
        {
            Debug.LogError("You need to set the DoorKeyHolder field on the DoorKeyUI! Drag the Player Game Object onto it.");
            return;
        }
        doorKeyHolder.OnDoorKeyAdded += DoorKeyHolder_OnDoorKeyAdded;
        doorKeyHolder.OnDoorKeyUsed += DoorKeyHolder_OnDoorKeyUsed;
        
        RefreshKeyVisuals();
    }

    void DoorKeyHolder_OnDoorKeyUsed(object sender, System.EventArgs e) 
    {
        RefreshKeyVisuals();
    }

    void DoorKeyHolder_OnDoorKeyAdded(object sender, System.EventArgs e) 
    {
        RefreshKeyVisuals();
    }

    void RefreshKeyVisuals() 
    {
        // Destroy old Key visuals
        foreach (Transform child in transform) 
        {
            Destroy(child.gameObject);
        }

        // Refresh current Key visuals
        int totalKeyCount = doorKeyHolder.doorKeyHoldingList.Count;
        float keyPositionDistance = 50f;
        float keyPositionOffset = (Mathf.Max(totalKeyCount, 1) - 1) / 2f * keyPositionDistance;
        int index = 0;
        foreach (Key key in doorKeyHolder.doorKeyHoldingList) 
        {
            // Instantiate UI Prefab
            Transform keyUISingleTransform = Instantiate(keyUISinglePrefab, transform);
            // Set UI Key Color
            keyUISingleTransform.GetComponent<Image>().color = key.keyColor;
            // Position UI Key
            RectTransform keyRectTransform = keyUISingleTransform.GetComponent<RectTransform>();
            keyRectTransform.anchoredPosition = new Vector2(index * keyPositionDistance - keyPositionOffset, 0);

            index++;
        }
    }

}
