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
    public InputField emailInput;
    public InputField passwordInput;
    // Register/login/ResetPassword
    public void RegisterButton() {
        var request = new RegisterPlayFabUserRequest {
        Email = emailInput.text,
        Password = passwordInput.text,
        RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
        
    }
    
    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "Registered and logged in!";
    }
    void OnError(PlayFabError error) {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
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
