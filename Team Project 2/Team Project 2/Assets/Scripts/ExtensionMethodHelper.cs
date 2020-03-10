using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///used to call IEnumerators from non monobehaviour classes such as Popups
/// </summary>
public class ExtensionMethodHelper : MonoBehaviour
{
    //the instance method being called
    private static ExtensionMethodHelper _Instance;
    public static ExtensionMethodHelper Instance{
        get{
            //if the _Instance has not been called already
            if (_Instance == null){
                //create a new gameobject to call the method
                _Instance = new GameObject("ExtensionMethodHelper").AddComponent<ExtensionMethodHelper>();
            }
            return _Instance;
        }
    }
}
