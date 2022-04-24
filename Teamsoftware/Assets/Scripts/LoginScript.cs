using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoginScript : MonoBehaviour
{
    public Text playerDisplay;
    public Text scoreDisplay;
   
    /*
    private void Start() 
    {
        if(DBmanager.LoggedIn){
            playerDisplay.text = "Player: " + DBmanager.username;
            scoreDisplay.text = "Score: " + DBmanager.score;
        }
    }
    */
    
    public void GoToRegister()
    {
        SceneManager.LoadScene("registrationMenu");
    }
    public void GoToRegisterTeach()
    {
        SceneManager.LoadScene("TeacherRegisterMenu");
    }
    public void GoToTeacher()
    {
        SceneManager.LoadScene("AccessCodeTeacher");
    }
}
 