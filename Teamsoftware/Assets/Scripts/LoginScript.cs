using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoginScript : MonoBehaviour
{
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
}
 