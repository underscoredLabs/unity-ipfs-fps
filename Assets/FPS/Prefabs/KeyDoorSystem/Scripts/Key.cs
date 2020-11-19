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

[CreateAssetMenu(fileName = "Key", menuName = "Add-Ons/Code Monkey/Key Door System/Create Key", order = 1)]
public class Key : ScriptableObject
{
    [Tooltip("Color of the Key")]
    public Color keyColor;
}
