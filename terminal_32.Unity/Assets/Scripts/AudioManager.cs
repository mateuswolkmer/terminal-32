using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
	public AudioSource audioMain;
	public AudioClip start;
	public AudioClip menu;
	public AudioClip startGame;
	public AudioClip game100;
	public AudioClip end;

	public float runTime;
	void Update()
	{
		UpdatePitch ();
	}

	public void VolumeDown()
	{
		audioMain.volume -= 0.2f;
	}
	public void VolumeUp()
	{
		audioMain.volume += 0.2f;
	}

	public void StartMenu()
	{		
		audioMain.clip = menu;
		audioMain.pitch = 1;
		audioMain.loop = true;
		audioMain.Play();
	}
	public void StartGame()
	{		
		if (audioMain) {
			audioMain.clip = startGame;
			audioMain.loop = false;
			audioMain.Play ();
			StartCoroutine (StartAfter (game100));
		}
	}
	public void EndGame()
	{
		audioMain.clip = end;
		audioMain.pitch = 1;
		audioMain.loop = false;
		audioMain.Play ();
	}

	void UpdatePitch()
	{
		if (this.GetComponent<Global> ().runTime <= 0) {
			audioMain.pitch += 0.05f;
			this.GetComponent<Global> ().runTime = 6.5f;
		}
	}

	IEnumerator StartAfter(AudioClip otherClip)
	{
		yield return new WaitForSeconds(audioMain.clip.length);
		audioMain.clip = otherClip;
		audioMain.loop = true;
		audioMain.Play ();
	}
}