
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public static UIManager instance;
    public Text timeText;
    public Text questionText;
    public Dialog dialog;
    public AnswerButton[] answerButtons;
    private void Awake()
    {
        MakeSingleton();
    }
    private void Start()
    {
        ShuffleAnswer();
    }
    public void SetTimeText(string content)
    {
        if (timeText)
        {
            timeText.text = content;
        }
    }
    public void ShuffleAnswer()
    {
        if (answerButtons != null && answerButtons.Length > 0)
        {
            for (int i = 0; i < answerButtons.Length; i++)
            {
                
                if (answerButtons[i] != null)
                {
                    answerButtons[i].tag = "Untagged";
                }
            }

            int randIndex = Random.Range(0, answerButtons.Length);
            if (answerButtons[randIndex] != null)
            {
                answerButtons[randIndex].tag = "RightAnswer";
            }
        }
    }
   

    public void SetQuestionText(string content)
    {
        if (questionText)
        {
            questionText.text = content;
        }
       
    }

    public void MakeSingleton()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
