using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoginScript : MonoBehaviour
{
    public Text playerDisplay;
    public Text scoreDisplay;
    public Button logoutButton;
    private void Start() 
    {
        print("pablo");
        if(DBmanager.LoggedIn){
            playerDisplay.text = "Player: " + DBmanager.username;
            scoreDisplay.text = "Score: " + DBmanager.score;
        }
        
    }
    /*private void Awake() {
    if(DBmanager.username == null) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
    */
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
}
 