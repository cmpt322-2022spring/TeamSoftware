using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour
{

    // Value from the question panel
    public int selectedValue = 0;

    // Answering quesions
    private Dropdown ansDropdown;
    private Button submitButton;

    // Question information
    private LevelManager levelManager;
    public Question question;
    public Text questionTitleTxt;
    public Text questionBodyTxt;
    public Text answersTxt;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        ansDropdown = GetComponentInChildren<Dropdown>();
        ansDropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(ansDropdown);
        });

        submitButton = GetComponentInChildren<Button>();
        submitButton.onClick.AddListener(delegate
        {
            SubmitAnswer(submitButton);
        });
    }

    void Update()
    {
        
    }

    void DropdownValueChanged(Dropdown change)
    {
        selectedValue = change.value;
        print(selectedValue);
    }

    void SubmitAnswer(Button btn)
    {
        print("Answer: " + selectedValue.ToString());
        // IF Answer correct...
        levelManager.CorrectAnswer();
        // ElSE...
    }

    void OnEnable()
    {
        if (levelManager == null)
        {
            levelManager = FindObjectOfType<LevelManager>();
        }
        // print(levelManager.questionId);
        question = levelManager.questions[levelManager.questionId];
        levelManager.IncrementQuestion();
        ImplementNextQuestion();
    }

    /// <summary>
    /// Implements the next question by updating the question panel in the game
    /// </summary>
    void ImplementNextQuestion()
    {
        questionTitleTxt.text = "Math Question #" + question.questionNumber.ToString();
        questionBodyTxt.text = "Answer the following question: \n\nWhat is " + question.questionContent + "?";
        answersTxt.text = "A) " + question.answerOptions[0].ToString() + "\nB) " + question.answerOptions[1].ToString() +
            "\nC) " + question.answerOptions[2].ToString() + "\nD) " + question.answerOptions[3].ToString();
    }

}
