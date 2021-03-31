using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
     public int health {get; set;}
    void Start()
    {
        health = 10; 
        // for an enemy to take random damage health = Random.Range(8,16);

    }
    public void TakeDamage (int amount) {
        Debug.Log("I am taking Damage! ");
        health -= amount; 
        if(health <= 0) {
            Destroy(this.gameObject); 
            Destroy(this); 
            this.gameObject.AddComponent<Rigidbody>();
        }

    } 
}
