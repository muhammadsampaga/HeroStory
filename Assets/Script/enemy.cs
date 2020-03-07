﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stragger
}

public class enemy : MonoBehaviour
{
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    // Start is called before the first frame update
  private void Awake(){
      health = maxHealth.initialValue;
  }

    private void TakeDamage(float damage){
        health -= damage;
        if(health <= 0){
            this.gameObject.SetActive(false);
        }
    }

    public void Knock(Rigidbody2D myRigidBody, float knockTime, float damage){
        StartCoroutine(KnockCo(myRigidBody,knockTime));
        TakeDamage(damage);
    }

      private IEnumerator KnockCo(Rigidbody2D myRigidBody, float knockTime)
    {
        if(myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;
               
        }
    }
}
