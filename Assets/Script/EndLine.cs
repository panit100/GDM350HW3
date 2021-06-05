using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndLine : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;
    public TextMeshProUGUI Textscore;
    public PlayerMovement player;
    public GameObject Win;
    public int _score = 0;
    public int score;

    private void Start() {
        
    }

    private void Update() {
        if(Textscore != null)
        Textscore.text = "Score : " + score + "/" + _score;

        if(score >= _score){
            Object1.SetActive(false);
            Object2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && other.GetComponent<PlayerMovement>().score >= _score){
            Win.SetActive(true);
        }
    }

    public void OnPickupBar(int barScore){
        score += barScore;
    }    

    public void AddPickupListener(GameObject bar){
        
        BaseBar _bar = bar.GetComponent<BaseBar>();
        _bar.PickupListener(OnPickupBar);

        

    }
}
