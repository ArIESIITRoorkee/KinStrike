using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour {
	Animator Anim;
	//public Transform player;
	//public float playerDistance;
	public float rotationDamping;
	public float movespeed;
	//public static bool isPlayerAlive = true;
	public float x=0;
	public float y=0;
	public  int rotation1;

	public static bool testKinect_forward=false;
	public static bool testKinect_backward=false;
	public static bool testKinect_left=false;
	public static bool testKinect_right=false;
	public static bool testKinect_rotateleft=false;
	public static bool testKinect_rotateright=false;
	public static bool testKinect_jump=false;
	public static bool walking1=false;
	public static bool jump1=true;

	Vector3 jumpdirection = Vector3.zero;

	// Use this for initialization
	void Start () {

		Anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {


		/*
		rotation1 = potScript.rotation;
		//rotation1 = rotation1 - 512;

		if (rotation1 < -100 && rotation1!=-200000 ) {
			testKinect_rotateleft = true;
			testKinect_rotateright = false;

		}
		if (-100 < rotation1 && rotation1 < 100 && rotation1!=-200000) {
			testKinect_rotateleft = false;
			testKinect_rotateright = false;
		}
		if (rotation1 > 100 && rotation1!=-200000) {
			testKinect_rotateright = true;
			testKinect_rotateleft =false;
		}
		if (rotation1 == -200000) {
			testKinect_rotateleft = false;
			testKinect_rotateright = false;
		}
*/
//		Debug.Log (KinectGestures.jump);
		CharacterController controller = GetComponent<CharacterController> ();

		walking1 = false;
		jump1 = false;
		Animating (walking1,jump1);
		//kinectrotateleft

	
	 	if (KinectGestures.swiperight == true) {
			testKinect_rotateleft = true;

		}
		//kinectrotateright
		if (KinectGestures.swipeleft == true) {
			testKinect_rotateright = true;
		}
		

		//kinectforward
		//if(KinectGestures.jump==true){testKinect_jump=true;
			
		//}
		if (KinectGestures.jump == true) {testKinect_jump=true;

		}
		if (KinectGestures.forward == true) {testKinect_forward = true;

		}
		//kinectbackward
		if (KinectGestures.backward == true) {testKinect_backward = true;
		
		}
		//kinectleft
		if (KinectGestures.left== true) {testKinect_left = true;
		
		}
		//kinectright
		if (KinectGestures.right == true) {testKinect_right = true;
		
		}
		if (testKinect_rotateleft == true) {
			transform.Rotate (0, 1, 0);
			testKinect_rotateleft = false;
		}
		if (testKinect_rotateright == true) {
			transform.Rotate (0, -1, 0);
			testKinect_rotateright = false;
		}

		//if (testKinect_jump == true) {
		//	Debug.Log ("JUMPED");

		//	jumpdirection.y = 80.0f;
		//	}
		//if (jumpdirection.y > 0) {
		//	jumpdirection.y -= 20.0f * Time.deltaTime;
		//	controller.Move (jumpdirection * Time.deltaTime);
		//}

		if (testKinect_jump==true) {
			Debug.Log("Jumped");
			jump1=true;
			jumpdirection.y=5.0f;
			testKinect_jump=false;
			Animating(walking1,jump1);
		}
		if (jumpdirection.y >= 0) {
			controller.Move(Vector3.up*jumpdirection.y*Time.deltaTime);
		}
			if ( testKinect_forward==true) {
			controller.Move (Vector3.forward *movespeed * Time.deltaTime);
			//float h=Vector3.forward;
			walking1=true;
			Animating(walking1,jump1);

				testKinect_forward=false;
			}
			//backward
			if ( testKinect_backward==true) {
			controller.Move (Vector3.forward*(-1)*movespeed * Time.deltaTime);
			walking1=true;

			Animating(walking1,jump1);
				
				testKinect_backward=false;
			}
			//left
			if ( testKinect_left==true) {
			controller.Move(Vector3.left* (1)*movespeed * Time.deltaTime);
			walking1=true;
			Animating(walking1,jump1);
				
				testKinect_left=false;
			}
			//right
			if ( testKinect_right==true) {
			controller.Move (Vector3.left* (-1)*movespeed * Time.deltaTime);
			walking1=true;
			Animating(walking1,jump1);
				
				testKinect_right=false;
			}
		if (controller.isGrounded)
			Debug.Log ("ground");
		else {
			jumpdirection.y-=10.0f*Time.deltaTime;
			controller.Move(Vector3.up* jumpdirection.y*Time.deltaTime);

		}


	}

	void Animating(bool walking,bool jump)
	{
		Debug.Log ("Animating Called");

		Anim.SetBool ("IsWalking", walking);
		Anim.SetBool ("IsJump", jump);

	}	
	}