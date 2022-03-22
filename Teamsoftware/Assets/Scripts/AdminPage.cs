using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminPage : MonoBehaviour
{
    public GameObject AdminSettingPage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowadminSetting()
    {
        AdminSettingPage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
    public void BackToadminMain()
    {
        AdminSettingPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
    }
}
