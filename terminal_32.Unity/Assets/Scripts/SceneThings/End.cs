using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour 
{
	private InputField inputField;
	private GameObject inputFieldObject;
	private Text inputFieldPH;

	Text wl;

	float gahScore;
	Text gahText;
	float rikScore;
	Text rikText;	
	float biaScore;
	Text biaText;

	float playerScore;
	Text playerText;

	Global global;
	
	void Start()
	{
		inputFieldObject = GameObject.Find ("InputField");
		inputField = inputFieldObject.GetComponent<InputField> ();
		inputFieldPH = inputFieldObject.GetComponent<InputField> ().placeholder.GetComponent<Text> ();
		playerScore = GameObject.Find("Global").GetComponent<Global>().time;

		wl = GameObject.Find ("wl").GetComponent<Text> ();
		if (playerScore > 0f)
			wl.text = "HACKED!";
		else
			wl.text = "FIREWALLED";

		gahText = GameObject.Find ("gahScore").GetComponent<Text> ();
		rikText = GameObject.Find ("rikScore").GetComponent<Text> ();
		biaText = GameObject.Find ("biaScore").GetComponent<Text> ();
		playerText = GameObject.Find ("playerScore").GetComponent<Text> ();

		gahScore = 15.91f; rikScore = 13.11f; biaScore = 18.21f;
		gahText.text = "GAH " + gahScore.ToString( "F2" );
		rikText.text = "RIK " + rikScore.ToString( "F2" );
		biaText.text = "BIA " + biaScore.ToString( "F2" );
		playerText.text = "TIME: " + playerScore.ToString( "F2" );
		Highscore();

		global = GameObject.Find ("Global").GetComponent<Global> ();
	}
	
	void Update() 
	{
		SelectGameObject (inputFieldObject);
	}
	
	void Highscore()
	{
		if (playerScore > PlayerPrefs.GetFloat ("playerScore"))
			PlayerPrefs.SetFloat ("playerScore", playerScore);
		string highscore = "YOU " + (PlayerPrefs.GetFloat ("playerScore")).ToString ("F2");
		
		if (PlayerPrefs.GetFloat ("playerScore") > biaScore)
			biaText.text = highscore;
		else if (PlayerPrefs.GetFloat ("playerScore") > gahScore)
			gahText.text = highscore;
		else if (PlayerPrefs.GetFloat ("playerScore") > rikScore)
			rikText.text = highscore;
	}	

	public void CheckInputField(string text)
	{
		if (text == "menu") {
			inputFieldPH.text = "going to menu...";
			StartCoroutine(ChangeSceneDelay ("Start"));
		} else if (text == "quit") {
			inputFieldPH.text = "quiting game...";
			StartCoroutine(ChangeSceneDelay ("Quit"));
		}
		inputField.text = "";
	}

	public void SelectGameObject(GameObject select)
	{
		EventSystem.current.SetSelectedGameObject (
			select, new BaseEventData(EventSystem.current));
		inputField.ActivateInputField ();
	}
	IEnumerator ChangeSceneDelay(string nextScene)
	{
		yield return new WaitForSeconds (2);
		if (nextScene == "Quit")
			Application.Quit ();
		else
			global.GoToMenu ();
	}
}
