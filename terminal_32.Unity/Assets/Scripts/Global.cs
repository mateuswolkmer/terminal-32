using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour 
{
	public static GameObject instance;
	public AudioManager audioManager;

	[HideInInspector]
	[Range( 0, 100 )]
	public float time;
	[HideInInspector]
	[Range( 0, 100 )]
	public float runTime;

	void Start ()
	{
		if (!instance)
			instance = this.gameObject;
		else
			Destroy (this.gameObject);

		DontDestroyOnLoad( this.GetComponent<AudioSource>() );
		DontDestroyOnLoad( this.GetComponent<Global>() );
		DontDestroyOnLoad( this.GetComponent<AudioManager>() );

		time = 32f;
		runTime = 6.5f;
	}
	void Update() 
	{
		if (SceneManager.GetActiveScene().name == "Game") {
			if (time - Time.deltaTime <= 0f){
                time = 0.00f;
                runTime = 0.00f;
                EndGame();
            }
			else {
				time -= Time.deltaTime;
				runTime -= Time.deltaTime;
			}
		}
		if (Input.GetKeyDown (KeyCode.T))
			time = 1;
	}

	public void BatteryPickup()
	{
		if (this.GetDifficulty () == "easy") {
			time += 2;
			runTime += 2;
		}
		if (this.GetDifficulty () == "hard") {
			time += 1;
			runTime += 1;
		}
	}


	private enum difficulty {easy, hard};
	private difficulty d = difficulty.easy;
	public void SetDifficulty(string s)
	{
		if (s == "easy")
			d = difficulty.easy;
		if (s == "hard")
			d = difficulty.hard;
	}
	public string GetDifficulty()
	{
		if (d == difficulty.easy)
			return ("easy");
		if (d == difficulty.hard)
			return ("hard");
		return "";
	}

	private enum movement {arrows, wasd};
	private movement m = movement.arrows;
	public void SetMovement(string s)
	{
		if (s == "arrows")
			m = movement.arrows;
		if (s == "wasd")
			m = movement.wasd;
	}
	public string GetMovement()
	{
		if (m == movement.arrows)
			return ("arrows");
		if (m == movement.wasd)
			return ("wasd");
		return "";
	}

	public void EndGame()
	{
		Global oldGlobal = this.GetComponent<Global>();
		audioManager.EndGame();
		SceneManager.LoadScene ("Highscore");
		Global G = this.GetComponent<Global> ();
		G = oldGlobal;
	}
	public void GoToMenu()
	{
		Global oldGlobal = this.GetComponent<Global>();
		audioManager.StartMenu ();
		SceneManager.LoadScene ("Start");
		Global G = this.GetComponent<Global> ();
		G = oldGlobal;
	}
	public IEnumerator StartGameWithDelay()
	{
		Global oldGlobal = this.GetComponent<Global>();
		audioManager.StartGame ();
		yield return new WaitForSeconds (2.4f);
		SceneManager.LoadScene ("Game");
		Global G = this.GetComponent<Global> ();
		G = oldGlobal;
		G.time = 32;
		G.runTime = 6.5f;
	}
}
