using UnityEngine;

public class GameOverManager : MonoBehaviour
{
	public healthscriptplayer healthplayer;
	public float restartDelay =5f;

    Animator anim;
	float restartTimer;

    void Awake()
	{ GameObject  player1 = GameObject .Find("FPSController");
		healthplayer = player1.GetComponent<healthscriptplayer> ();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
		if (healthplayer.currenthealth <= 0)
        {
            anim.SetTrigger("GameOver");
			restartTimer +=Time.deltaTime;
			if(restartTimer >= restartDelay){
				Application.LoadLevel(Application.loadedLevel);
        }
    }
}
}
