using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translocator : MonoBehaviour, IItem 
{
        [SerializeField] 
        Transform firePoint;

        //[SerializeField] 
        //Transform destination;

        [SerializeField]
        GameObject FiredBullet, player;
        GameObject bullet; 

        bool hasBeenFired = false; 


    public void Pickup(Transform hand) {
        //Debug.Log("BANKS");
        this.gameObject.transform.SetParent(hand); 
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity; 
        this.GetComponent<Rigidbody>().isKinematic = true;  
        this.GetComponent<Collider>().enabled = false;    
    } 
    public void Use() {
        Debug.Log("<color=red>POW!</color>"); 
        if(hasBeenFired) {
            Teleport(); 
        } else {
             bullet = Instantiate(FiredBullet, firePoint.position, firePoint.rotation, null); 
            //GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Cube); 
            bullet.transform.localScale = Vector3.one * 0.2f;
            bullet.transform.position = firePoint.position; 
            bullet.transform.Translate(transform.forward); 
            Rigidbody rb = bullet.AddComponent<Rigidbody>(); 
            rb.AddForce(transform.forward * 15, ForceMode.Impulse); 

        }
        hasBeenFired = !hasBeenFired; 


        
    }
    public void Drop() {
        Debug.Log("Dropping our item"); 
        this.gameObject.transform.SetParent(null); 
        this.transform.Translate(0,0,2); 
        this.GetComponent<Rigidbody>().isKinematic = false; 
        this.GetComponent<Rigidbody>().AddForce(Vector3.forward*10, ForceMode.Impulse); 
        this.GetComponent<Collider>().enabled = true; 
    }

    public void Teleport() {
        Debug.Log("Am I being called?");
        
                player.transform.position = bullet.transform.position; 
                player.transform.Translate(Vector3.up);
                Destroy(bullet); 

    }

}
