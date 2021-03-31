using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour, IItem 
{

    [SerializeField]
    Light flashlight;
    
    bool canSwitchLight = true;  //the player can turn the flashlight on or off. 

    public void Pickup (Transform hand) {
        Debug.Log("BANKS");
        this.gameObject.transform.SetParent(hand); 
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity; 
        this.GetComponent<Rigidbody>().isKinematic = true;  
        this.GetComponent<Collider>().enabled = false; 
    }
    public void Use() {
        Debug.Log("Using our Light!"); 
        flashlight.enabled = !flashlight.enabled; 
        if (canSwitchLight) { //if canswitch is true 
            flashlight.enabled = !flashlight.enabled;  //switch the light 
            canSwitchLight = false;  //disable canswitch 
            StartCoroutine(Wait());  //wait 1 secound 
        }

    }

    public void Drop() {
        Debug.Log("Dropping our item"); 
        this.gameObject.transform.SetParent(null); 
        this.transform.Translate(0,0,2); 
        this.GetComponent<Rigidbody>().isKinematic = false; 
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward*10, ForceMode.Impulse); 
        this.GetComponent<Collider>().enabled = true; 
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(1);  //wait for 1 secound 
        canSwitchLight = true; //make canswitch true again. 
    }
}
