using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GetScore : MonoBehaviour
{
    // 要顯示分數的 Text
    public Text messageText;

    public void CallRequestScore()
    {
        StartCoroutine(RequestScore());
    }

    IEnumerator RequestScore()
    {
        // 從 Database 裡面拿東西, 透過 getScore.php
        UnityWebRequest request = UnityWebRequest.Get("http://localhost/sqlconnect/getScore.php");
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            // Network error
            Debug.Log(request.error);
        }
        else
        {
            // request.downloadHandler.text 是PHP回傳的值
            Debug.Log(request.downloadHandler.text);
            // 將回傳值放到 Text 裡面
            messageText.text = "Top Score \n" + request.downloadHandler.text;
            Debug.Log("Get successfully.");
        }
    }

    private void Start()
    {
        CallRequestScore();
    }
}
