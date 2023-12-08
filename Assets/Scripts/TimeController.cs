using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] private string url = "http://api.timezonedb.com/v2.1/get-time-zone?key=0B4SE0AFL5SX&format=json&by=zone&zone=Europe/Moscow";
    [SerializeField] private string text1;
    private JsonFile jsonFile = new JsonFile();

    public void GetMoscowTime()
    {
        StartCoroutine(GetTime());
    }



    private IEnumerator GetTime()
    {
        UnityWebRequest request = UnityWebRequest.Get(this.url);

        yield return request.SendWebRequest();
        jsonFile = JsonUtility.FromJson<JsonFile>(request.downloadHandler.text);
        text1 = jsonFile.formatted.ToString();
        string text2 = null;
        for(int i = 11; i < text1.Length; i++)
        {
            text2 += text1[i];
        }
        //Debug.Log(request.downloadHandler.text);
        Debug.Log(text2);
    }

}

public class JsonFile
{
    public string formatted;

}