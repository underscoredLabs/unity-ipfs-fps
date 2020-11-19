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

/*
 * Added to Door, open with Key
 * */
public class DoorLock : MonoBehaviour 
{
    
    [Header("Door Lock")]
    [Tooltip("The Key that opens this Door")]
    public Key key;
    [Tooltip("Remove the Key from the Holder after using it to open this Door?")]
    public bool removeKeyOnUse;

    Animator m_Animator;

    void Awake() 
    {
        // Cache Animator Component
        m_Animator = GetComponent<Animator>();
    }

    public void OpenDoor() 
    {
        // Play Open Door Animation
        m_Animator.SetTrigger("Open");
    }

    public void CloseDoor() 
    {
        // Play Close Door Animation
        m_Animator.SetTrigger("Close");
    }

}
