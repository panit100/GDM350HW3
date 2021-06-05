using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBar : BaseBar
{
    PlayerMovement player;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            player = other.GetComponent<PlayerMovement>();
            AddSpeedPlayer();
                pickupBarEvent.Invoke(1);
            Destroy(gameObject);
        }
    }

    void AddSpeedPlayer(){
        player.speed += speed;
    }
}
