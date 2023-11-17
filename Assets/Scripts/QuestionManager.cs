using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;
    public QuestionData[] questions;
    // Start is called before the first frame update
    List<QuestionData> questionList;
    QuestionData m_curQuestion;

    public QuestionData CurQuestion { get => m_curQuestion; set => m_curQuestion = value; }
   
    private void Awake()
    {
        questionList = questions.ToList();
        MakeSingleton();
       

    }
    public QuestionData GetRamdomQuestion()
    {
        if (questionList != null && questionList.Count>0)
        {
            int ramdomIndex = Random.Range(0, questionList.Count);
            m_curQuestion = questionList[ramdomIndex];
            questionList.RemoveAt(ramdomIndex);
        }
        return m_curQuestion;
    }

    public void MakeSingleton()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
