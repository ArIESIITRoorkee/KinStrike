using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
    public GameObject level1Image;
	public void LoadScene(int level)
    {
        if(level1Image) level1Image.SetActive(true);
        Application.LoadLevel(level);
    }
}
