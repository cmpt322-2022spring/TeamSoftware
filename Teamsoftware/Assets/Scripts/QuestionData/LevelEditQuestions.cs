using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditQuestions : MonoBehaviour
{
    [Header("Level Selecting")]
    public int currentLevel;
    public Text levelText;
    public GameObject questionPanel;
    [Header("Question Editing")]
    public int currentQuestion;
    public Text questionText;
    public List<Question> questionsLevel1 = new List<Question>();
    public List<Question> questionsLevel2 = new List<Question>();



    // Start is called before the first frame update
    void Start()
    {
        //List<Question> questionsLevel1 = JsonUtility.FromJson<List<Question>>(json1);
        //List<Question> questionsLevel2 = JsonUtility.FromJson<List<Question>>(json2);

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

    public void EditQuestion(int questionId)
    {
        currentQuestion = questionId;
        questionText.text = "Question: " + currentQuestion.ToString();
        questionPanel.SetActive(true);
    }

}
