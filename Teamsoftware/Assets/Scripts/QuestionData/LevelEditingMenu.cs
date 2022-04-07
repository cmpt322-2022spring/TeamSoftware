using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditingMenu : MonoBehaviour
{

    public GameObject levelSelectPanel;
    public GameObject levelEditingPanel;
    private LevelEditQuestions editQuestions;

    // Start is called before the first frame update
    void Start()
    {
        editQuestions = levelEditingPanel.GetComponent<LevelEditQuestions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EditLevel(int levelID)
    {
        levelEditingPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        editQuestions.ChangeLevelToEdit(levelID);
    }

    public void LevelSelectMenu()
    {
        levelEditingPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
    }

}
