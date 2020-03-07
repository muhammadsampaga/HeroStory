using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite  fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue HeartContainer;
    public FloatValue playerCurrentHealth;


    void Start()
    {
        initHearts();
    }

    public void initHearts(){
        for(int i = 0 ; i < HeartContainer.initialValue; i ++){
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void updateHearts(){
       float tempHealth = playerCurrentHealth.RuntimeValue / 2;
       for(int i = 0 ; i < HeartContainer.initialValue; i ++){
           if(i <= tempHealth-1){
               //full hearth
               hearts[i].sprite = fullHeart;
           }else if(i >= tempHealth){
               //empty hearth
               hearts[i].sprite = emptyHeart;
           }else{
               //half full hearth
               hearts[i].sprite = halfFullHeart;
           }
       }
    }
}
