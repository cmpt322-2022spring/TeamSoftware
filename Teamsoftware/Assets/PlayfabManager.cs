using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    //Following email as tutorial (change later)
    public InputField usernameInput;
    public InputField passwordInput;
    // Register/login/ResetPassword
    public void RegisterButton() {
        var request = new RegisterPlayFabUserRequest {
        Username = usernameInput.text,
        Password = passwordInput.text,
        RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
        
    }
    
    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered and logged in!";
    }
    
    //Not sure if this is working
    void OnError(PlayFabError error) {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
    

    public void LoginButton(){

    }

    public void ResetPasswordButton() {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
