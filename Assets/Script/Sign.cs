﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public QuestItem quest;

    public GameObject DialogBox;
    public GameObject EndMission;
    public Text DialogText;
    public string dialog;
    public bool playerInRange;
   

    public PlayerQuest playerQuest;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z) && playerInRange)
        {
            if (DialogBox.activeInHierarchy)
            {
                DialogBox.SetActive(false);
            }
            else
            {

                DialogBox.SetActive(true);
                DialogText.text = quest.missionDescription;
            }
        }

        if (Input.GetKeyDown(KeyCode.Y) && playerInRange)
        {
            if (playerQuest.currentQuest < quest.quantity)
            {

                DialogBox.SetActive(false);
                playerQuest.questControlUI.gameObject.SetActive(true);
                playerQuest.quest = quest;
                playerQuest.currentQuest = 0;
                playerQuest.questControlUI.SetText(quest.missionDescription);
                playerQuest.questControlUI.setQty(0, quest.quantity);


            }
        }

        if (Input.GetKeyDown(KeyCode.Y) && playerInRange)
        {
 
                if (playerQuest.currentQuest >= quest.quantity)
                {
                    playerQuest.ceklis.SetActive(false);
                    playerQuest.questControlUI.gameObject.SetActive(false);
                    EndMission.SetActive(true);

                }
            

        }
        if (Input.GetKeyUp(KeyCode.U) && playerInRange) { 
            if (EndMission.activeInHierarchy)
        {
            EndMission.SetActive(false);
        }
            }
    }

  

public void ShowSign(string text)
    {
        if (DialogBox.activeInHierarchy)
        {
            DialogBox.SetActive(false);
        }
        else
        {
            DialogBox.SetActive(true);
            DialogText.text = text;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerQuest = other.GetComponent<PlayerQuest>();
        }
    }
        private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
    }
    }

}

[System.Serializable]
public struct QuestItem
{
    public string name;
    public int quantity;
    public string missionDescription;
}