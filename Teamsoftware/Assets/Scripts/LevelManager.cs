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
    public float backgroundSpeed;
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
    public GameObject loseScreen;
    public int questionsCorrect;
    public Text winProgress;

    // Pause System
    public GameObject pauseScreen;

    // Player Movement
    public Transform player;
    public float moveSpeed = 10f;
    [Range(0, 4)]
    public int actualPos = 3;
    [Range(0, 4)]
    public int newPos = 3;
    public List<Transform> positions = new List<Transform>();

    void Start()
    {
        questionPanel.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
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
            player.position = Vector3.MoveTowards(player.position,
                new Vector3(positions[newPos].position.x, player.position.y, player.position.z),
                moveSpeed * Time.deltaTime);
            if (player.position.x == positions[newPos].position.x)
            {
                actualPos = newPos;
            }
        }

        if (actualPos == 0)
        {
            player.gameObject.SetActive(false);
        }

        if (newPos == 0 && !loseScreen.activeSelf)
        {
            loseScreen.SetActive(true);
            correctAnswerPanel.GetComponentInChildren<Button>().interactable = false;
        }

        // Pause Game with "P"
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

    }

    /// <summary>
    /// Moves the background by background speed
    /// </summary>
    void MoveBackground()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0);
    }

    /// <summary>
    /// Sets a correct question answer panel to off and shows the next question
    /// </summary>
    public void ShowQuestion()
    {
        correctAnswerPanel.SetActive(false);

        if (finalQuestion)
        {
            questionPanel.SetActive(false);
            winScreen.SetActive(true);
            winProgress = GameObject.Find("WinProgress").GetComponent<Text>();
            winProgress.text = "Great Job! You Win! \n\nQuestions Correct: " +
                questionsCorrect.ToString() + "/" + (questions.Count).ToString();
        }
        else
        {
            questionPanelTimer = questionPanelTime;
        }

    }

    /// <summary>
    /// Shows the answer panel and tells whether it was correct or not.
    /// </summary>
    /// <param name="correctAnswer">A boolean describing whether the answer was correct or not.</param>
    public void ShowAnswerPanel(bool correctAnswer)
    {
        correctAnswerPanel.SetActive(true);
        if (correctAnswer)
        {
            // Increment questions correct
            questionsCorrect += 1;
            // Change pos to increase by 1
            ChangePos(1);
            // Set answer title text to correct and color to green
            Text answerTitle = GameObject.Find("AnswerTitle").GetComponent<Text>();
            answerTitle.text = "Correct!";
            answerTitle.color = Color.green;
        }
        else
        {
            // Change pos to decrease by 1
            ChangePos(-1);
            // Set answer title text to Incorrect and color to red
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

    /// <summary>
    /// Restarts the level
    /// NOTE: Probably a test function, we can potentially modify later
    /// </summary>
    public void Restart()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Returns the player to the main menu
    /// </summary>
    public void MainMenu()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(3);
    }

    /// <summary>
    /// Pauses the game and sets the pause screen to be active
    /// </summary>
    public void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Unpauses the game and sets the pause screen to be inactive
    /// </summary>
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    /// <summary>
    /// Changes the new pos of the player
    /// </summary>
    /// <param name="_pos">Pos to change the newPos by (-1 or +1 ONLY)</param>
    public void ChangePos(int _pos)
    {
        if (_pos == -1 || _pos == 1)
        {
            if (newPos < 4 && _pos == 1)
            {
                newPos += _pos;
            }
            if (newPos > 0 && _pos == -1)
            {
                newPos += _pos;
            }
        }
        else
        {
            print("ERROR! _pos must be +1 or -1 ONLY!");
        }
    }

}
