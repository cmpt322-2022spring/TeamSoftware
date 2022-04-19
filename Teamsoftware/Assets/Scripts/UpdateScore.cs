using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UpdateScore : MonoBehaviour
{
    
    public string nameField = DBmanager.username;
    public int score = 10;
    public Text updateText;
    public Button submitButton;

    public void CallUpdate() {
        StartCoroutine(updateScore());

    }
    IEnumerator updateScore() {

        //Adds form 
        WWWForm form = new WWWForm();
        form.AddField("name", nameField);
        form.AddField("score", score);
        
        print(1);
        //Post 
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/updateScore.php", form);
        yield return www.SendWebRequest();
         
        print(2);
        //Checks to see if login works, and updates database to show score
        
        if(www.downloadHandler.text == "0"){
            print("pablo");
        }
        updateText.text = www.downloadHandler.text;
        
        
        if(www.downloadHandler.text[0] == '0'){
            updateText.text = www.downloadHandler.text;
            DBmanager.score = www.downloadHandler.text[1] - 48;
            //UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
        else {
            Debug.Log("User login failed. Error #" + www.downloadHandler.text);
        }
        
    }
}
