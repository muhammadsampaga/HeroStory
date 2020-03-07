﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject DialogBox;
    public Text DialogText;
    public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && playerInRange)
        {
            if (DialogBox.activeInHierarchy)
            {
                DialogBox.SetActive(false);
            }else
            {
                DialogBox.SetActive(true);
                DialogText.text = dialog;
            }
        }
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
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
