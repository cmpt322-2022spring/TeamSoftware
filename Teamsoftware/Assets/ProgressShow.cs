using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressShow : MonoBehaviour
{

    public GameObject progressPage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowProgress()
    {
        progressPage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    public void BackToMainStudent()
    {
        progressPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
    }
}
