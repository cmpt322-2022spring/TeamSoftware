using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerPanel : MonoBehaviour
{

    public Text titleTxt;
    public Text messageTxt;

    public string correctAnswer;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void OnEnable()
    {
        levelManager = FindObjectOfType<LevelManager>();
        correctAnswer = levelManager.questions[levelManager.questionId-1].answerExplanation;
        messageTxt.text = correctAnswer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
