using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherLoginPage : MonoBehaviour
{
    public GameObject teacherSettingPage;
    public GameObject problemEditingPage;
    public GameObject removeStudentsPage;
    public GameObject TeacherMainMenuPage;
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
    public void ShowProblemPage()
    {
        problemEditingPage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        teacherSettingPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
        removeStudentsPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
        TeacherMainMenuPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);

    }
    public void ShowStudentRemovePage()
    {
        removeStudentsPage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
    public void BackToTeacherMain()
    {
        teacherSettingPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
        TeacherMainMenuPage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
    public void EditingtoSetting()
    {
        problemEditingPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
        teacherSettingPage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
    public void StudentstoSetting()
    {
        removeStudentsPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
    }
}
