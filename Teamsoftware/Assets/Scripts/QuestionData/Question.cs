using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public int questionNumber;
    public string questionContent;
    public int[] answerOptions = new int[4];
    public int answer;
    public string answerExplanation;

    public Question (int _number, string _content, int[] _options, int _answer, string _explanation)
    {
        questionNumber = _number;
        questionContent = _content;
        answerOptions = _options;
        answer = _answer;
        answerExplanation = _explanation;
    }
}
