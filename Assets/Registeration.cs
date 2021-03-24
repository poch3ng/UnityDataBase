using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Registeration : MonoBehaviour
{
    // 輸入使用者名稱
    public InputField nameField;

    // 送出按鈕
    public Button submitBtn;

    public void CallRegister(){
        StartCoroutine(Register());
    }

    IEnumerator Register(){
        WWWForm form = new WWWForm();
        // 建立要傳到 Database 裡面的資料
        // username 是 key 值, nameField.text 是 value
        form.AddField("username", nameField.text);

        // 透過 Post 將資料傳到 PHP
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            // Network error
            Debug.Log(www.error);
        }
        else if ( www.downloadHandler.text != "0")
        {
            // Get Error Like: user already existed
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log("User created successfully.");
        }
    }


    // Verify Username has input so we enable submit button
    public void VerifyInput()
    {
        submitBtn.interactable = (nameField.text.Length > 0);
    }
}
