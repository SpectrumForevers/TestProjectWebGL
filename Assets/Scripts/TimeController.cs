using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] private string url = "http://api.timezonedb.com/v2.1/get-time-zone?key=0B4SE0AFL5SX&format=json&by=zone&zone=Europe/Moscow";
    private string textMoscowTime;
    private const int startIndex = 0, endIndex = 11;
    private JsonFile jsonFile = new JsonFile();

    public void GetMoscowTime()
    {
        StartCoroutine(GetTimeFromSite());

    }

    private IEnumerator GetTimeFromSite()
    {
        using var request = UnityWebRequest.Get(this.url);

        yield return request.SendWebRequest();

        jsonFile = JsonUtility.FromJson<JsonFile>(request.downloadHandler.text);

        textMoscowTime = jsonFile.formatted.ToString().Remove(startIndex, endIndex);

        Debug.Log(textMoscowTime);

        if (textMoscowTime != null)
        {
            BridgeToJS.SendToJS(textMoscowTime);
        }
        textMoscowTime = null;
    }
}

public class JsonFile
{
    public string formatted;

}