using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class BridgeToJS : MonoBehaviour
{
    [SerializeField] TimeController timeController;

    [SerializeField] string moscowTime, moscowTimeLate;
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void ShowMessage(string message);


#endif
    private void Update()
    {
        if (moscowTimeLate != moscowTime)
        {
            SendToJS();

            moscowTimeLate = moscowTime;
        }
    }

    public void SendToJS()
    {
#if UNITY_WEBGL && !UNITY_EDITOR

    ShowMessage(moscowTime);

#endif
    }
    public void SetMoscowTime(string time)
    {
        moscowTime = time;
    }
}
