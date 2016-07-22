using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthscriptplayer : MonoBehaviour {
	public float startinghealth=200;
	public float currenthealth=200;
	public Slider healthSlider;
	public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed=10f;
	public Color flashColor=new Color(1f,0f,0f,1f);
	bool isDead;
	bool damaged=false;
	AudioSource playerAudio;
	int x=1;
	public static bool isPlayerAlive = true;
	public float delay=1.5f;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (damaged==true) {
			damageImage.color = flashColor;
		} 
		else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;




	}
	public void TakeDamage(float Amount){
		damaged = true;
		currenthealth -= Amount;
		healthSlider.value = currenthealth;
//		playerAudio.Play;
		if(currenthealth <= 0f && !isDead){


			Death ();
			isPlayerAlive=false;
			//x = 0;

		}

	}

	void  Death(){
		isDead = true;
		anim.SetTrigger ("Die");
		playerAudio.clip = deathClip;
	//	playerAudio.Play;
	}
}
