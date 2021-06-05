using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedBar : BaseBar
{
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            AddSpeedEmemy();
                pickupBarEvent.Invoke(1);
            Destroy(gameObject);
        }
    }

    void AddSpeedEmemy(){
        foreach(GameObject n in Enemy){
            n.GetComponent<NavMeshAgent>().speed += speed;
        }
    }
}
