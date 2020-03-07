using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nokbak : MonoBehaviour
{
    public float thrust;
    public float knockTime;
     public float damage;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.CompareTag("breakable")){
            other.GetComponent<Pot>().Smash();
        }

        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);

                if(other.gameObject.CompareTag("enemy") && other.isTrigger){
                     hit.GetComponent<enemy>().currentState = EnemyState.stragger;
                     other.GetComponent<enemy>().Knock(hit, knockTime, damage);
                }

                    if(other.gameObject.CompareTag("Player")){

                        if(other.GetComponent<Movement>().currentState != PlayerState.stagger){

                        hit.GetComponent<Movement>().currentState = PlayerState.stagger;
                        other.GetComponent<Movement>().Knock(knockTime, damage);
                        }
                    }
               
              
               
            }
        }
    }
}
