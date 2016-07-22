using UnityEngine;
using System.Collections;

public class LoadAdditive : MonoBehaviour {
    public void LoadAddOnCLick(int level)
    {
        Application.LoadLevelAdditive(level);
    }
}
