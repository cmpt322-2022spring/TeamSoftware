using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    
    public InputField nameField;
    public InputField passwordField;
    public Button submitButton;

    public void CallLogin() {
        StartCoroutine(LoginPlayer());

    }
    IEnumerator LoginPlayer() {

        //Adds form 
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        
        //Post 
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form);
        yield return www.SendWebRequest();
        
        //Checks to see if login works, and updates database to show score
        if(www.downloadHandler.text[0] == '0'){
            DBmanager.username = nameField.text;
            DBmanager.score = www.downloadHandler.text[1] - 48;
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
        else {
            Debug.Log("User login failed. Error #" + www.downloadHandler.text);
        }
    }
    public void VerifyInputs(){
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >=4);
    }

    //Logout test
    public void logOut(){
        DBmanager.LogOut();
    }
}
