using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeToJS : MonoBehaviour
{
    [SerializeField] TimeController timeController;

    [SerializeField] string moscowTime;

    public void SetMoscowTime(string time)
    {
        moscowTime = time;
    }
}
