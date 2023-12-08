using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] private string url = "http://api.timezonedb.com/v2.1/get-time-zone?key=0B4SE0AFL5SX&format=json&by=zone&zone=Europe/Moscow";
    [SerializeField] BridgeToJS bridge;
    private string jsonTextInput, textMoscowTime;
    private JsonFile jsonFile = new JsonFile();

    public void GetMoscowTime()
    {
        StartCoroutine(GetTimeFromSite());
        if (textMoscowTime != null)
        {
            bridge.SetMoscowTime(textMoscowTime);
        }
    }

    private IEnumerator GetTimeFromSite()
    {
        UnityWebRequest request = UnityWebRequest.Get(this.url);

        yield return request.SendWebRequest();

        jsonFile = JsonUtility.FromJson<JsonFile>(request.downloadHandler.text);
        jsonTextInput = jsonFile.formatted.ToString();
        
        for(int i = 11; i < jsonTextInput.Length; i++)
        {
            textMoscowTime += jsonTextInput[i];
        }
        //Debug.Log(request.downloadHandler.text);
        Debug.Log(textMoscowTime);
    }
}

public class JsonFile
{
    public string formatted;

}