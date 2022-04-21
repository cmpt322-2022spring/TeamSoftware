using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSaving : MonoBehaviour
{
    public static ScoreSaving scoreSaving;
    public int currLevel;

    [Header("Scores To Save")]
    public int totalScore;
    public int levelScore1;
    public int levelScore2;

    private void Awake()
    {
        if (scoreSaving == null)
        {
            scoreSaving = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        // load the levels scores
        totalScore = PlayerPrefs.GetInt("totalScore");
        levelScore1 = PlayerPrefs.GetInt("levelScore1");
        levelScore2 = PlayerPrefs.GetInt("levelScore2");
    }

    public void SceneChanged()
    {
        // Set current level Id
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            currLevel = 0;
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            currLevel = 1;
        }
        else
        {
            // default case to check for errors
            currLevel = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Saves the score of the level and checks if there is a better score
    /// </summary>
    /// <param name="_newScore">The new score is used to determine if the player has a new high score</param>
    public void SaveScore(int _newScore)
    {
        switch (currLevel)
        {
            case 0:
                if (_newScore > levelScore1)
                {
                    levelScore1 = _newScore;
                    PlayerPrefs.SetInt("levelScore1", levelScore1);
                }
                break;
            case 1:
                if (_newScore > levelScore2)
                {
                    levelScore2 = _newScore;
                    PlayerPrefs.SetInt("levelScore2", levelScore2);
                }
                break;
            default:
                print("Error! Level Id Parameter Out of Bounds.");
                break;
        }
    }

}
