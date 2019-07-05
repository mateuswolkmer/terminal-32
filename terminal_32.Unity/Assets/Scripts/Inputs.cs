using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inputs : MonoBehaviour
{
	private PlayerMovement player;
	private Global G;

	void Start()
	{
		player = GameObject.Find ("player").GetComponent<PlayerMovement> ();
		G = GameObject.Find ("Global").GetComponent<Global> ();
	}
	void Update()
    {
        if( Input.anyKeyDown )
        {
			if ((Input.GetKeyDown (KeyCode.UpArrow) ||
	             Input.GetKeyDown (KeyCode.DownArrow) ||
	             Input.GetKeyDown (KeyCode.LeftArrow) ||
				 Input.GetKeyDown (KeyCode.RightArrow)) &&
				 G.GetMovement() == "arrows")
				player.PlayerMovementArrows ();
			else if ((Input.GetKeyDown (KeyCode.W) ||
			         Input.GetKeyDown (KeyCode.S) ||
			         Input.GetKeyDown (KeyCode.A) ||
				     Input.GetKeyDown (KeyCode.D)) &&
					 G.GetMovement() == "wasd")
				player.PlayerMovementWASD ();
        }		
	}
}
