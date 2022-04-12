using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DropDown : MonoBehaviour
{
    // Start is called before the first frame update
    //public Dropdown dropdown;
    void Start()
    {
        //Post 
        StartCoroutine(GetRequest("http://localhost/sqlconnect/delete.php"));
    }

    IEnumerator GetRequest(string uri){
        UnityWebRequest www = UnityWebRequest.Get(uri);
        yield return www.SendWebRequest();
        string itemsDataString = www.downloadHandler.text;
        string[] dropdownDelete = itemsDataString.Split(';');
        while(dropdownDelete.Length < 5){
            int i = 0;
            print(dropdownDelete[i]);
            i++;

        }
    }
    // Update is called once per frame
    
}
