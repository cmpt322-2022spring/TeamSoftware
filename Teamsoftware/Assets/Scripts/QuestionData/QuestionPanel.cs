using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour
{

    public int selectedValue = 0;

    private Dropdown ansDropdown;
    private Button submitButton;
    private LevelManager levelManager;

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
    }

}
