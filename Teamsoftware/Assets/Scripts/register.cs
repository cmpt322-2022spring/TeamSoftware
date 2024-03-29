using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class register : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public Text messageText;
    public Button submitButton;

    public void CallRegister() {
        StartCoroutine(Register());

    }

    //Might have to use WWW instead, but this is the "new" class to connect.
    IEnumerator Register() {
        //Adds form 
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        
        //Post 
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();

        //sends error messages, if not loads logininScene again.
        /*
        if(www.result == UnityWebRequest.Result.Success) {
            Debug.Log("User created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else {
            //Might have to play around with www.error (text or some other stuff)
            Debug.Log("User creation failed. Error #" + www.downloadHandler.text);
        }
        */

        if(www.downloadHandler.text == "0") {
            Debug.Log("User created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else {
            //Might have to play around with www.error (text or some other stuff)
            messageText.text = "User creation failed. Error #" + www.downloadHandler.text;
        }


    }

    public void VerifyInputs(){
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >=4);
    }

}
