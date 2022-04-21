using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogOut : MonoBehaviour
{
    public Button logOutButton;
    // Simple logout
    public void loggingOut()
    {
            //Sets username = null
            DBmanager.LogOut();
            SceneManager.LoadScene("InitialLogin"); 
    }
    public void loggingOutTeach() {
         DBmanagerTeach.LogOut();
         SceneManager.LoadScene("InitialLogin");
    }

    
   
}
