using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public float timePerQuestion;
    float m_curTime;
    int m_rightCount;
    private void Awake()
    {
        m_curTime =timePerQuestion;
    }
    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.SetTimeText("00:" + m_curTime);
        CreateQuestion();
        StartCoroutine(TimeCountingDown());
    }



    public void CreateQuestion()
    {
        QuestionData qs = QuestionManager.instance.GetRamdomQuestion();
        if (qs != null)
        {
            UIManager.instance.SetQuestionText(qs.question);
            string[] wrongAnswer = new string[] { qs.answerA, qs.answerB, qs.answerC };
            UIManager.instance.ShuffleAnswer();

            var temp = UIManager.instance.answerButtons;
            if (temp != null && temp.Length > 0)
            {
                int wrongAnswerCount = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    int answerId = i;
                    if (string.Compare(temp[i].tag, "Untagged") == 0)
                    {
                        temp[i].SetAnswerText(wrongAnswer[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }
                    else
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                       
                    }
                    temp[answerId].btnComp.onClick.RemoveAllListeners();
                    temp[answerId].btnComp.onClick.AddListener(() => CheckRightAnswerEvent(temp[answerId]));
                }
            }

        }
    }
    void CheckRightAnswerEvent(AnswerButton answer)
    {
        if (answer.CompareTag("RightAnswer"))
        {

            m_curTime = timePerQuestion;
            UIManager.instance.SetTimeText("00:" + m_curTime);
            m_rightCount++;
            if (m_rightCount==QuestionManager.instance.questions.Length)
            {
                UIManager.instance.dialog.SetDialogContent("Ba?n ?a? chiê?n th??ng!");
                UIManager.instance.dialog.Show(true);
                AudioController.instance.PlayWinSound();
                StopAllCoroutines();
                
            }
            else
            {
               
                CreateQuestion();
                Debug.Log("ba?n ?a? tra? l??i ?u?ng");
                AudioController.instance.PlayRightSound();
            }
           
           
        }
        else
        {
            UIManager.instance.dialog.SetDialogContent("Ba?n ?a? thua!");
            UIManager.instance.dialog.Show(true);
            Debug.Log("Ba?n ?a? tra? l??i sai");
            AudioController.instance.PlayLoseSound();
        }
    }
    IEnumerator TimeCountingDown()
    {
        yield return new WaitForSeconds(1);
        if (m_curTime>0)
        {
            m_curTime--;
            StartCoroutine(TimeCountingDown());
            UIManager.instance.SetTimeText("00:" + m_curTime);
        }
        else
        {
            UIManager.instance.dialog.SetDialogContent("?a? hê?t th??i gian.Ba?n ?a? thua");
            UIManager.instance.dialog.Show(true);
            StopAllCoroutines();
            AudioController.instance.PlayLoseSound();
        }
       
       
    }
    public void Replay()
    {
        AudioController.instance.StopMusic();
        SceneManager.LoadScene("Gameplay");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
