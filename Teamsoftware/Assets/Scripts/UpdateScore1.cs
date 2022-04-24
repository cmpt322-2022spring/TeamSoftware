using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class UpdateScore1 : MonoBehaviour
{
    public Text playerDisplay;
    public Text scoreDisplay;
    private void Awake()
    {
        if(DBmanager.username == null) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("InitialLogin");
        }
        playerDisplay.text = "Player: " + DBmanager.username;
        scoreDisplay.text = "Score: " + DBmanager.score;
    }

    // Update is called once per frame
   public void CallSaveData(){
       StartCoroutine(SavePlayerData());
   }

   IEnumerator SavePlayerData(){
       //Adds form 
        WWWForm form = new WWWForm();
        form.AddField("name", DBmanager.username);
        form.AddField("score", DBmanager.score);
        
        //Post 
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/updateScore.php", form);
        yield return www.SendWebRequest();

        if(www.downloadHandler.text == "0"){
            Debug.Log("Data saved!");
        }

        else {

            Debug.Log("Save failed. Error #" + www.downloadHandler.text);
            Debug.Log("or headed back to mainMenu");
        }
   }    

    public void IncreaseScore() {
        DBmanager.score += 10;
        scoreDisplay.text = "Score: " + DBmanager.score;
   }
}
