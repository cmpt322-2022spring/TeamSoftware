using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject levelPage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Level()
    {
        levelPage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
    public void BackToMainMenu()
    {
        levelPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(500f, 500f);
    }
    public void loadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
