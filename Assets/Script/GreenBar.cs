using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenBar : BaseBar
{

    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            CutSpeedEnemy();
            other.GetComponent<PlayerMovement>().score += score;
            Destroy(gameObject);
        }
    }

    void CutSpeedEnemy(){
        foreach(GameObject n in Enemy){
            n.GetComponent<NavMeshAgent>().speed -= speed;
        }
    }
}
