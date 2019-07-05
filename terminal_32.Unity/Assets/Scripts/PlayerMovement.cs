using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
	private Vector3 nextPos;
	private Animator animation;
	private GameObject[] walls;
	private GameObject[] batteries;
	private GameObject[] triggers;

	Global global;

	void Start()
	{		
		nextPos = new Vector3( 0, -78 );
		animation = GetComponent<Animator>();
		global = GameObject.Find ("Global").GetComponent<Global> ();
	}

	public void PlayerMovementArrows()
	{	
		if( Input.GetKeyDown( KeyCode.UpArrow ))
		{
			nextPos.x = this.transform.position.x;
			nextPos.y = this.transform.position.y + 18f; 
		}	
		else if( Input.GetKeyDown( KeyCode.DownArrow ))
		{
			nextPos.x = this.transform.position.x;
			nextPos.y = this.transform.position.y - 18f;
		}
		else if( Input.GetKeyDown( KeyCode.LeftArrow ))
		{
			nextPos.x = this.transform.position.x - 18f;
			nextPos.y = this.transform.position.y;
		}
		else if( Input.GetKeyDown( KeyCode.RightArrow ))
		{
			nextPos.x = this.transform.position.x + 18f;
			nextPos.y = this.transform.position.y;
		}

		if( Move())
		{			
			this.transform.position = nextPos;
			animation.SetBool( "moved", true );
		}
		else
			animation.SetBool( "moved", false );
	}
	public void PlayerMovementWASD()
	{
		if( Input.GetKeyDown( KeyCode.W ))
		{
			nextPos.x = this.transform.position.x;
			nextPos.y = this.transform.position.y + 18f; 
		}	
		else if( Input.GetKeyDown( KeyCode.S ))
		{
			nextPos.x = this.transform.position.x;
			nextPos.y = this.transform.position.y - 18f;
		}
		else if( Input.GetKeyDown( KeyCode.A ))
		{
			nextPos.x = this.transform.position.x - 18f;
			nextPos.y = this.transform.position.y;
		}
		else if( Input.GetKeyDown( KeyCode.D ))
		{
			nextPos.x = this.transform.position.x + 18f;
			nextPos.y = this.transform.position.y;
		}

		if(Move())
		{			
			this.transform.position = nextPos;
			animation.SetBool( "moved", true );
		}
		else
			animation.SetBool( "moved", false );
	}

	public bool Move()
	{
		bool canMove = true;
		walls = GameObject.FindGameObjectsWithTag("Wall");
		foreach (GameObject wall in walls)
			if (Vector3.Distance (nextPos, wall.transform.position) <= 8) 
			{
				canMove = false;
				break;
			}
		if(canMove)
		{
			batteries = GameObject.FindGameObjectsWithTag("Battery");
			foreach( GameObject battery in batteries )
			{
				if( Vector3.Distance( nextPos, battery.transform.position ) <= 8)
				{
					GameObject.Find("Global").GetComponent<Global>().BatteryPickup();
                    StartCoroutine(GameObject.Find("time").GetComponent<TimeText>().BatteryPickup());
                    AudioSource batteryPicukup = GameObject.Find("batteryPickup").GetComponent<AudioSource>();
                    if (batteryPicukup.isPlaying)
                        batteryPicukup.Stop();
                    batteryPicukup.Play();
					Destroy(battery);
					break;
				}
			}
			triggers = GameObject.FindGameObjectsWithTag("Trigger");
			foreach( GameObject trigger in triggers )
			{
				if ( Vector3.Distance( nextPos, trigger.transform.position ) <= 8)
				{
					if (trigger.name == "endTrigger")
						global.EndGame();
					else 
					{
						GameObject camera = GameObject.Find("camera");
						camera.transform.position = new Vector3( camera.transform.position.x, camera.transform.position.y + 252);
						Vector3 pos = new Vector3 (trigger.transform.position.x, trigger.transform.position.y - 18f);
						Instantiate (Resources.Load ("wall"), pos, trigger.transform.rotation);
						Destroy (trigger);
						break;
					}
				}
			}
			return true;
		}
		return false;
	}
}
