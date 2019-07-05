using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBatteries : MonoBehaviour 
{
	private Global G;

	void Start () 
	{
		G = GameObject.Find ("Global").GetComponent<Global>();
		if (G.GetDifficulty() == "hard") {
			Destroy (GameObject.Find ("battery extra"));
			Destroy (GameObject.Find ("battery extra 1"));
			Destroy (GameObject.Find ("battery extra 2"));
		}		
	}
}
