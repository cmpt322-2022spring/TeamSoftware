using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
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

    [Header("Saving Test")]
    public string playerName;
    public int lives;
    public float health;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }
    // Given:
    // playerName = "Dr Charles"
    // lives = 3
    // health = 0.8f
    // SaveToString returns:
    // {"playerName":"Dr Charles","lives":3,"health":0.8}

    // Start is called before the first frame update
    void Start()
    {
        SaveToString();
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
