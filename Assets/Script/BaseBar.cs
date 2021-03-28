using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseBar : MonoBehaviour
{
    public int score = 1;
    public float speedRotation = 10f;
    public GameObject[] Enemy;
    public float speed = 0f;
    
    private void Start() {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update() {
        RotateObject();
        Invoke("DestroyBar",10);
    }
    
    void RotateObject(){
        transform.Rotate(0,0,speedRotation * Time.deltaTime);
    }

    void DestroyBar(){
        foreach(GameObject n in Enemy){
            n.GetComponent<NavMeshAgent>().speed +=1;
        }
        Destroy(gameObject);

    }

    
}
