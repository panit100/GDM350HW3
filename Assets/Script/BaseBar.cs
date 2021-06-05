using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class BaseBar : MonoBehaviour
{
    public int score = 1;
    public float speedRotation = 10f;
    public GameObject[] Enemy;
    public float speed = 0f;

    public PickupBarEvent pickupBarEvent = new PickupBarEvent();
    
    private void Start() {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        EndLine endLine = FindObjectOfType<EndLine>().GetComponent<EndLine>();
        endLine.AddPickupListener(this.gameObject);
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

    public void PickupListener(UnityAction<int> listener){
        pickupBarEvent.AddListener(listener);
        
    }

    
}
