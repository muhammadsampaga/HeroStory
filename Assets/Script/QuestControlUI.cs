using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestControlUI : MonoBehaviour
{
    public GameObject dialogBox;
    public Text textBox;
    public Text qty;

    public void SetText(string text)
    {
        textBox.text = text;
    }

    public void setQty(int current, int qty)
    {
        this.qty.text = current + "/" + qty;
    }
}
