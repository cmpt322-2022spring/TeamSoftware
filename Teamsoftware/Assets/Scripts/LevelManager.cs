using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject questionPanel;

    public float backrgoundSpeed;
    public Renderer backgroundRenderer;

    void Start()
    {
        questionPanel.SetActive(false);
    }

    void Update()
    {
        MoveBackground();
    }

    void MoveBackground()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backrgoundSpeed * Time.deltaTime, 0);
    }

}
