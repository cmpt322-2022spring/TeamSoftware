using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherLoginPage : MonoBehaviour
{
    public GameObject teacherSettingPage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTeacherSetting()
    {
        teacherSettingPage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
    public void BackToTeacherMain()
    {
        teacherSettingPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
    }
}
