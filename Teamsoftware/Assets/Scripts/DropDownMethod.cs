using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DropDownMethod : MonoBehaviour
{
    public Dropdown _dropDown;
    List<string> m_DropOptions = new List<string> { "Option 1", "Option 2"};
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
        List<string> dropdownOpt = new List<string>(itemsDataString.Split(','));
        print(itemsDataString);
        _dropDown.ClearOptions();   

        _dropDown.AddOptions(dropdownOpt);

    }
    // Update is called once per frame
    
}
