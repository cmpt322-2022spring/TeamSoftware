using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    // Panels to modify
    public GameObject questionPanel;
    public GameObject correctAnswerPanel;

    // Background info
    public float backrgoundSpeed;
    public Renderer backgroundRenderer;

    // panel actvation time and timer
    public float questionPanelTime = 1f;
    float questionPanelTimer;

    // Questions list
    public int questionId = 0;
    public List<Question> questions = new List<Question>();

    void Start()
    {
        questionPanel.SetActive(false);
        ShowQuestion();
        questions = FindObjectOfType<QuestionData>().questions;
    }

    void Update()
    {
        MoveBackground();
        if (questionPanelTimer > 0)
        {
            if (questionPanel.activeSelf)
            {
                questionPanel.SetActive(false);
            }
            questionPanelTimer -= Time.deltaTime;
        }
        else
        {
            questionPanel.SetActive(true);
        }
    }

    void MoveBackground()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backrgoundSpeed * Time.deltaTime, 0);
    }

    public void ShowQuestion()
    {
        correctAnswerPanel.SetActive(false);
        // activate question panel in a minute = true
        questionPanelTimer = questionPanelTime;
    }

    public void CorrectAnswer()
    {
        correctAnswerPanel.SetActive(true);
    }

}
