using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public int coins = 0; 

    [SerializeField] 
    AudioClip dooropen; 

    AudioSource aud; 

    // Start is called before the first frame update
    void Start()
    {
        aud = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame

    [SerializeField]
    Transform hand; 
    //Gun heldItem; 


    [SerializeField]
    IItem heldItem; 
    GameObject Bullet;

    void Update() {
    
    if(Input.GetButtonDown("Fire1")) {
        Debug.Log("Is fire one working???");
        if(heldItem != null) {
            heldItem.Use(); 

            Debug.Log("ERROR HERE?" + heldItem);  
        } else {
            Debug.Log("we arent holding anyhting."); 
        }
    }
    if(Input.GetKeyDown(KeyCode.Q)) {
        if(heldItem != null) {
            heldItem.Drop(); 
            heldItem = null; 
        } else {
            Debug.Log("We aren't holding anything."); 
        }
    }
    }

    int totalKeys = 0; 

    void OnTriggerEnter(Collider other) {
        
        Debug.Log("I have hit" + other.gameObject.name);
        if(other.gameObject.CompareTag("Item")) {
            Debug.Log("HELP ME PLEASE");
            if(heldItem != null) {
                return;
            }
            heldItem = other.GetComponent<IItem>(); 
            heldItem.Pickup(hand); 

        }
        if (other.gameObject.CompareTag("floor")) {
            other.gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }

        if(other.gameObject.CompareTag("coin")) {
            Debug.Log("Coins collected: "+ coins);
            Destroy(other.gameObject);
            coins +=1;
            
            // Destroy the coin
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Door")) {
            if(totalKeys > 0 ) {
                totalKeys -= 1; 
                Destroy(other.gameObject); 
                aud.PlayOneShot(dooropen);
            } else {
                Debug.Log("LOL go find the key to open the door bro!");
            }
        }

        if (other.gameObject.CompareTag("Key")) {
            totalKeys += 1; 
            Destroy(other.gameObject);


        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
