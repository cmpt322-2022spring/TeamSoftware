using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour
{

    // Value from the question panel
    public int selectedValue = 0;

    // Answering quesions
    // private Dropdown ansDropdown;
    private Button buttonA;
    private Button buttonB;
    private Button buttonC;
    private Button buttonD;
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

        /*
        ansDropdown = GetComponentInChildren<Dropdown>();
        ansDropdown.onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(ansDropdown);
        });
        */

        submitButton.onClick.AddListener(delegate
        {
            SubmitAnswer(submitButton);
        });
    }

    void Update()
    {
        
    }

    /*
    void DropdownValueChanged(Dropdown change)
    {
        selectedValue = change.value;
        print(selectedValue);
    }
    */

    void SubmitAnswer(Button btn)
    {
        // print("Answer: " + selectedValue.ToString());
        // IF Answer correct...
        if (selectedValue == question.answer)
        {
            levelManager.ShowAnswerPanel(true);
        }
        // ElSE...
        else
        {
            levelManager.ShowAnswerPanel(false);
        }
    }

    void OnEnable()
    {
        GetObjects();
        ResetOptions();
        if (levelManager == null)
        {
            levelManager = FindObjectOfType<LevelManager>();
        }
        // print(levelManager.questionId);
        question = levelManager.questions[levelManager.questionId];
        levelManager.IncrementQuestion();
        ImplementNextQuestion();
    }

    void GetObjects() {
        submitButton = GameObject.Find("Submit").GetComponent<Button>();
        buttonA = GameObject.Find("A").GetComponent<Button>();
        buttonB = GameObject.Find("B").GetComponent<Button>();
        buttonC = GameObject.Find("C").GetComponent<Button>();
        buttonD = GameObject.Find("D").GetComponent<Button>();
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

    /// <summary>
    /// Make all the buttons white again
    /// </summary>
    void ResetOptions()
    {
        buttonA.GetComponent<Image>().color = Color.white;
        buttonB.GetComponent<Image>().color = Color.white;
        buttonC.GetComponent<Image>().color = Color.white;
        buttonD.GetComponent<Image>().color = Color.white;

        submitButton.interactable = false;
    }

    public void SelectAnswer(int _value)
    {
        selectedValue = _value;

        submitButton.interactable = true;

        buttonA.GetComponent<Image>().color = Color.white;
        buttonB.GetComponent<Image>().color = Color.white;
        buttonC.GetComponent<Image>().color = Color.white;
        buttonD.GetComponent<Image>().color = Color.white;

        switch (_value)
        {
            case 0:
                buttonA.GetComponent<Image>().color = Color.green;
                break;
            case 1:
                buttonB.GetComponent<Image>().color = Color.green;
                break;
            case 2:
                buttonC.GetComponent<Image>().color = Color.green;
                break;
            case 3:
                buttonD.GetComponent<Image>().color = Color.green;
                break;
            default:
                print("ERROR! Value is not 0-3!");
                break;
        }
    }



}
