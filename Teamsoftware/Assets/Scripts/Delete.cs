using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Delete : MonoBehaviour
{
    
    public InputField deleteField;
    public Text messageText;
    public Button deleteButton;
    private DropDownMethod dropDownMethod;

    private void Start() {
        dropDownMethod = FindObjectOfType<DropDownMethod>();
    }

    public void CallDelete() {
        StartCoroutine(deletePlayer());

    }

    IEnumerator deletePlayer() {

        //Adds form 
        WWWForm form = new WWWForm();
        form.AddField("name", deleteField.text);

        //Post 
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/delete.php", form);
        yield return www.SendWebRequest();
        
        if(www.downloadHandler.text == "1") {
            Debug.Log("User login failed. Error #" + www.downloadHandler.text);
        }

        
        else {
            Debug.Log(www.downloadHandler.text);
            messageText.text = "User deleted successfully!";  
            StartCoroutine(removeText());              
          }
        
    }
    IEnumerator removeText(){
        yield return new WaitForSeconds(3);
        messageText.text = "";

        dropDownMethod.CallRequest();
    }
}
