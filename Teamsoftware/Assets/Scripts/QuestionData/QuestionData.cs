using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionData : MonoBehaviour
{

    [Header("Game Question Info")]
    public int currentQuestion = 0;
    public List<Question> questions = new List<Question>();

    // Question Editing:
    [Header("Question Editing")]
    public int currentLevel;
    public Text levelText;
    public GameObject questionPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (questionPanel != null)
        {
            questionPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevelToEdit(int levelId)
    {
        currentLevel = levelId;
        levelText.text = "Level: " + currentLevel.ToString();
    }

    public void ChangeQuestionToEdit()
    {
        if (questionPanel != null)
        {
            questionPanel.SetActive(true);
        }
    }



}
