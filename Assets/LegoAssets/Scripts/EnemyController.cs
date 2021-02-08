using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

	public GameObject Gameover;
	public Transform player;
	UnityEngine.AI.NavMeshAgent nav;

	public float delayEnemy = 3;
	public bool isWalking = false;
	
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	void Start() {
		StartCoroutine(DelayEnemy());
	}
	
	IEnumerator DelayEnemy() {
		yield return new WaitForSeconds(delayEnemy);
		isWalking = true;
	}

	
	// Update is called once per frame
	void Update () {
		if (isWalking) {
			nav.SetDestination (player.position);
		} else {
			nav.SetDestination (gameObject.transform.position);
		}
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Player") {

			GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
			
			foreach (GameObject enemy in enemys) {
				enemy.SendMessage("PlayerDie");
			}

			col.gameObject.GetComponent<PlayerMovement>().enabled = false;
			Gameover.SetActive(true);
			StartCoroutine("RestartGame");
		}
	}

	

	IEnumerator RestartGame(){
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(0);
	}
}
