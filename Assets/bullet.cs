using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] 
    int damageAmount = 2; 

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.CompareTag("Idamageable")) { 
            Debug.Log("I am attemting to damage something"); 
            col.gameObject.GetComponent<IDamageable>().TakeDamage(damageAmount); 
        }
        Destroy(this.gameObject);
    }
}
