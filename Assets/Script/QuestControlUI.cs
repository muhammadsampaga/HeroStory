using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestControlUI : MonoBehaviour
{
    public GameObject dialogBox;
    public Text textBox;

    public void SetText(string text)
    {
        textBox.text = text;
    }
}
