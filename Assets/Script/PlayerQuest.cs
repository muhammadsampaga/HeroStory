using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public QuestItem quest;
    public int currentQuest;
    public QuestControlUI questControlUI;

    private Item item;
    private bool onItem;

    private void Start()
    {
        onItem = false;    
    }

    private void Update()
    {
        if(onItem && Input.GetKeyUp(KeyCode.Z))
        {
            if (item.itemName == quest.name)
            {
                if(currentQuest < quest.quantity)
                {
                    Destroy(item.gameObject);
                    currentQuest++;
                    questControlUI.setQty(currentQuest, quest.quantity);
                }
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "item")
        {
            item = collision.GetComponent<Item>();
            onItem = true;
        }
    }           

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "item")
        {
            onItem = false;
        }
    }
}
