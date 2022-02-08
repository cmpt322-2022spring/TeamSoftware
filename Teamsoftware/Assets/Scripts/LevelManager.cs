using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject questionPanel;
    public GameObject correctAnswerPanel;

    public float backrgoundSpeed;
    public Renderer backgroundRenderer;

    void Start()
    {
        questionPanel.SetActive(false);
        StartCoroutine(ShowQuestion());
    }

    void Update()
    {
        MoveBackground();
    }

    void MoveBackground()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backrgoundSpeed * Time.deltaTime, 0);
    }

    IEnumerator ShowQuestion()
    {
        correctAnswerPanel.SetActive(false);
        yield return new WaitForSeconds(1);
        questionPanel.SetActive(true);
    }

    public void CorrectAnswer()
    {
        correctAnswerPanel.SetActive(true);
    }

    public void ContinueButton()
    {
        StartCoroutine(ShowQuestion());
    }

}
