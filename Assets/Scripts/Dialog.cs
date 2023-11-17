using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    public Text dialogContentText;
    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
    public void SetDialogContent(string content)
    {
        if (dialogContentText)
        {
            dialogContentText.text = content;
        }
    }
}
