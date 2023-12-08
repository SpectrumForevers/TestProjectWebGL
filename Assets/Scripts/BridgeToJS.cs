using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public static class BridgeToJS 
{

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ShowMessage(string message);


#endif


    public static void SendToJS(string time)
    {
        #if UNITY_WEBGL && !UNITY_EDITOR

            ShowMessage(time);

        #endif
    }

}
