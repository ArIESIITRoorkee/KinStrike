using UnityEngine;
using System.Collections;

public class raycasting : MonoBehaviour {
	public bool shot=false;
	public AudioClip shotClip;
	public float fadespeed = 10f;
	public float flashspeed = 3f;
	public float flashintensity = 5f;
	public GameObject startPoint;
	public GameObject Sphere1;
	private LineRenderer laserShotLine;
	private Light laserShotLight;
	public int x=0;
	healthScript11 enemyhealth;



	// Use this for initialization
	void Start () {
		GameObject  enemy1 = GameObject .Find("ShockTrooper1");
		enemyhealth =	enemy1.GetComponent<healthScript11> ();
		laserShotLine = GetComponentInChildren<LineRenderer> ();
		laserShotLight = laserShotLine.gameObject.GetComponent<Light>();
		laserShotLine.enabled = false;
		laserShotLight.intensity = 0f;



	}
	
	// Update is called once per frame
	void Update () {shot=true;//x++;
	/*	if (NewBehaviourScript.buttonPressed == true) {
			shot = true;
		} 
		else {
			shot = false;
		}
		*/
		GameObject rayCast = GameObject.Find ("FirstPersonCharacter");
		KinectOverlayer targetScript = rayCast.GetComponent<KinectOverlayer> ();

		Sphere1 = targetScript.Sphere2;
		startPoint = GameObject.Find ("fx_shot");
		Vector3 direction = (Sphere1.transform.position - startPoint.transform.position).normalized;
		RaycastHit hit;
		float theDistance;
		Debug.DrawRay (transform.position, direction, Color.green);

		if (shot ) {//x=0;
			if (Physics.Raycast (transform.position, direction, out hit)) {
				theDistance = hit.distance;
				//print (theDistance + " " + hit.collider.gameObject.name);


				if (hit.collider.gameObject.name == "ShockTrooper1") {
					hit.collider.gameObject.GetComponent<healthScript11> ().health -= 10f;
					enemyhealth.takedamage(hit.point);
				}

			}

			laserShotLine.SetPosition (0, laserShotLine.transform.position);
			laserShotLine.SetPosition (1, Sphere1.transform.position);
			laserShotLine.enabled = true;
			laserShotLight.intensity = flashintensity;
			AudioSource.PlayClipAtPoint (shotClip,transform.position);
		

	
		}
		else {
			laserShotLine.enabled =false;
		}
		//shot = false;
	}
}
