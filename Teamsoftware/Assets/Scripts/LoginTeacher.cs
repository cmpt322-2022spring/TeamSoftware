using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoginTeacher : MonoBehaviour
{
    
    public InputField nameFieldTeach;
    public InputField passwordFieldTeach;
    //public Text messageText;
    public Button submitButtonTeach;

    public void CallLoginTeach() {
        StartCoroutine(LoginTeachers());

    }

    IEnumerator LoginTeachers() {

        //Adds form 
        WWWForm form = new WWWForm();
        form.AddField("name", nameFieldTeach.text);
        form.AddField("password", passwordFieldTeach.text);
        
        //Post 
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/loginTeacher.php", form);
        yield return www.SendWebRequest();
        
        if(www.downloadHandler.text == "0"){
            DBmanagerTeach.usernameTeach = nameFieldTeach.text;
           //Gives index out of bounds error, need to fix
           //DBmanager.score = int.Parse(www.downloadHandler.text.Split('\t')[0]);
           //print(DBmanager.username);
           print(DBmanagerTeach.usernameTeach);
            UnityEngine.SceneManagement.SceneManager.LoadScene(8);
        }

        else {
            Debug.Log("User login failed. Error #" + www.downloadHandler.text);
        }

    }

    public void VerifyInputs(){
        submitButtonTeach.interactable = (nameFieldTeach.text.Length >= 4 && passwordFieldTeach.text.Length >=4);
    }

    //Logout test
    public void logOut(){
        DBmanager.LogOut();
    }
}
