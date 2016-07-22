using UnityEngine;
using System.Collections;

public class healthScript11 : MonoBehaviour {
	Animator anim;
	ParticleSystem HitParticles;
	int x=1;
	float delay=1.5f;
	public  float health;
	// Use this for initialization
	void Start () {
		ScoreManager.score = 5;
		anim = GetComponent<Animator> ();
		HitParticles = GetComponentInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(health <= 0f && x==1){
			//EnemyAIScript.isPlayerAlive=false;
			anim.SetTrigger("Mara");
			ScoreManager.score -= 1;
			x=0;
			//takeDamage ();

			//Destroy(gameObject,delay);
		}
	}
	public void takedamage(Vector3 hitpoint){
		HitParticles.transform.position = hitpoint;
		HitParticles.Emit (5);
	}



}