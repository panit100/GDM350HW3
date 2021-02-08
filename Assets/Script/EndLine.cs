using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    public GameObject Win;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Win.SetActive(true);
        }
    }    
}
