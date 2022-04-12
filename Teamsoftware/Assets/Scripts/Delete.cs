using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Delete : MonoBehaviour
{
    
    public InputField deleteField;
    public Text messageText;
    public Button temp;
    public Dropdown dropdown;

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
            //stores the data in an array separeted by ";"
            print(www.downloadHandler.text[0]);
            string itemsDataString = www.downloadHandler.text;
            string[] dropdownDelete = itemsDataString.Split(';');
            print(dropdownDelete[0]);
        dropdown.ClearOptions();
        foreach (string str in dropdownDelete) {
            int i = 0;
             dropdown.options.Add (new Dropdown.OptionData (str));
            print(dropdownDelete[i]);
            i++;        
         }
            messageText.text = "Student removed";

        }
    }

   /*
    public void VerifyInputs(){
        submitButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >=4);
    }

    //Logout test
    public void logOut(){
        DBmanager.LogOut();
    }
    */
}
