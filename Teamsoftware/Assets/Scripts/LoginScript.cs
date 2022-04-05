using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoginScript : MonoBehaviour
{
    public Text playerDisplay;
    //public Text teacherDisplay;
    public Text scoreDisplay;
   
    private void Start() 
    {
        
        if(DBmanager.LoggedIn){
            playerDisplay.text = "Player: " + DBmanager.username;
            scoreDisplay.text = "Score: " + DBmanager.score;
        }
        
       /* if(DBmanagerTeach.LoggedInTeach){
            teacherDisplay.text = "Teacher: " + DBmanagerTeach.usernameTeach;
        }
        */
    }
    
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToRegisterTeach()
    {
        SceneManager.LoadScene(7);
    }
    public void GoToTeacher()
    {
        SceneManager.LoadScene(5);
    }
}
 