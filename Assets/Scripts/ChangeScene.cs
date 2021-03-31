using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string nextLevelName = "Sample scene";

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(nextLevelName); 
        } 

    } 
}
