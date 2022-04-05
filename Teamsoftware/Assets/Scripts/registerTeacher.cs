using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class registerTeacher : MonoBehaviour
{
    public InputField nameFieldTeach;
    public InputField passwordFieldTeach;
    public Text messageTextTeach;
    public Button submitButtonTeach;

    public void CallTeacherRegister() {
        StartCoroutine(RegisterTeacher());

    }

    //Might have to use WWW instead, but this is the "new" class to connect.
    IEnumerator RegisterTeacher() {
        //Adds form 
        WWWForm form = new WWWForm();
        form.AddField("name", nameFieldTeach.text);
        form.AddField("password", passwordFieldTeach.text);
        
        //Post 
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/registerTeacher.php", form);
        yield return www.SendWebRequest();

        

        if(www.downloadHandler.text == "0") {
            Debug.Log("User created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(6);
        }
        else {
            messageTextTeach.text = "User creation failed. Error #" + www.downloadHandler.text;
        }
    }

    public void VerifyInputsTeach(){
        submitButtonTeach.interactable = (nameFieldTeach.text.Length >= 4 && passwordFieldTeach.text.Length >=4);
    }
}