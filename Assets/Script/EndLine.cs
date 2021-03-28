using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndLine : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;
    public TextMeshProUGUI score;
    public PlayerMovement player;
    public GameObject Win;
    public int _score = 0;


    private void Update() {
        if(score != null)
        score.text = "Score : " + player.score + "/" + _score;

        if(player.score >= _score){
            Object1.SetActive(false);
            Object2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && other.GetComponent<PlayerMovement>().score >= _score){
            Win.SetActive(true);
        }
    }    
}
