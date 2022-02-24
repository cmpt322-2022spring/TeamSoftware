using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    // Flags for questions
    public bool finalQuestion;

    // Win and lose screens
    public GameObject winScreen;

    // Player Movement
    public Transform player;
    public int actualPos = 3;
    public int newPos = 3;
    public List<Transform> positions = new List<Transform>();

    void Start()
    {
        questionPanel.SetActive(false);
        winScreen.SetActive(false);
        ShowQuestion();
        questions = FindObjectOfType<QuestionData>().questions;
    }

    void Update()
    {
        MoveBackground();
        if (!finalQuestion)
        {
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

        // If we are not in the actual pos...
        // ... Move to the new pos
        if (actualPos != newPos)
        {
            // player.position = Vector3.MoveTowards(player)
        }

    }

    void MoveBackground()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backrgoundSpeed * Time.deltaTime, 0);
    }

    public void ShowQuestion()
    {
        correctAnswerPanel.SetActive(false);

        if (finalQuestion)
        {
            questionPanel.SetActive(false);
            winScreen.SetActive(true);
        }
        else
        {
            questionPanelTimer = questionPanelTime;
        }
        
    }

    public void ShowAnswerPanel(bool correctAnswer)
    {
        correctAnswerPanel.SetActive(true);
        if (correctAnswer)
        {
            Text answerTitle = GameObject.Find("AnswerTitle").GetComponent<Text>();
            answerTitle.text = "Correct!";
            answerTitle.color = Color.green;

        }
        else
        {
            Text answerTitle = GameObject.Find("AnswerTitle").GetComponent<Text>();
            answerTitle.text = "Incorrect!";
            answerTitle.color = Color.red;
        }
    }

    /// <summary>
    /// We need to do it this way to prevent out of bounds error
    /// </summary>
    public void IncrementQuestion()
    {
        if (questionId < questions.Count - 1)
        {
            questionId++;
        }
        else
        {
            questionId++;
            finalQuestion = true;
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangePos(int _pos)
    {
        newPos += _pos;
    }

}
