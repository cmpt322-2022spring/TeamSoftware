using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherAccessCode : MonoBehaviour
{
    public InputField accessCode;
    public string code = "1234";
    public Button submitButton;

    public void CallTeacher(){
        CheckAccessCode();
    }

    public void CheckAccessCode(){
        if(accessCode.text == code){
            UnityEngine.SceneManagement.SceneManager.LoadScene(6);

        }
        else {
            Debug.Log("Access code failed!");
        }
    }

    public void GoToTeacherRegister(){
        
    }


}
