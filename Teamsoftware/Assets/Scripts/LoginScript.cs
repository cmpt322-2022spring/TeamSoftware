using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoginScript : MonoBehaviour
{
    public Text playerDisplay;

    private void start() 
    {
        if(DBmanager.LoggedIn){
            playerDisplay.text = "Player: " + DBmanager.username;
        }
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
}
 