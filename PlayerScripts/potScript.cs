using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class potScript : MonoBehaviour {
	SerialPort sp=new SerialPort("COM4", 9600);
	private int speed;
	public static int rotation;
	private int s;
	private int amt;
	// Use this for initialization
	void Start () {
		sp.Open ();
		sp.ReadTimeout = 1;
	
	}

	// Update is called once per frame
	void Update () {
		//amt = speed * Time.deltaTime;
		if (sp.IsOpen) {

			try{
				//s=sp.ReadLine();
				//if(sp.ReadByte()<0)
				//speed=speed/60;
				int.TryParse(sp.ReadLine(),out s);
				//Debug.Log(s);
				rotation=s;
				rotation = rotation - 512;
				Debug.Log(rotation);

				//amt = (int)(speed * Time.deltaTime);
				//pot(amt);
				//print(sp.ReadByte());
			}

			catch(System.Exception){
			}



		}
	
	}
		
	void pot(int amt){
			//transform.Translate (Vector3.right * amt, Space.World);

	}
}
