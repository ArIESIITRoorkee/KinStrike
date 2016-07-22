using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public GameObject[] pauseObjects;
    public GameObject[] nonPauseObjects;
	public GameObject[] finishObjects;
	public GameObject[] nonFinishObjects;
	private healthscriptplayer healthplayer;
    // Use this for initialization
    void Start()
    {
		GameObject  player1 = GameObject .Find("FPSController");
		healthplayer = player1.GetComponent<healthscriptplayer> ();
        Time.timeScale = 1;
        hidePaused();
        Debug.Log(pauseObjects.Length);
    }

    // Update is called once per frame
    void Update()
    {

        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Debug.Log("Pause");
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("UnPause");
                Time.timeScale = 1;
                hidePaused();
            }
        }
		if(healthplayer.currenthealth <= 0)
	{
		foreach (GameObject g in finishObjects)
        	{
           		 g.SetActive(true);
        	}
       	 	foreach (GameObject g in nonFinishObjects)
        	{
           		 g.SetActive(false);
        	}
	}
}


    //Reloads the Level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in nonPauseObjects)
        {
            g.SetActive(false);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in nonPauseObjects)
        {
            g.SetActive(true);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}
