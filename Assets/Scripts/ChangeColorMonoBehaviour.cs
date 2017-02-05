using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorMonoBehaviour : MonoBehaviour {

    public ColorManagerMonoBehaviour colorManager;
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.color = colorManager.color;
	}
}
