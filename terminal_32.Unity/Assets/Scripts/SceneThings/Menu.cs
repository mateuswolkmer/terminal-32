using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour 
{
	private InputField inputField;
	private GameObject inputFieldObject;
	private Text inputFieldPH;
    private bool SelectText = true;

	private Text mainCommands;
	private string menu1;
	private string menu2;
	private string credits;

	private AudioSource mainMusic;
	public AudioManager audioManager;

	private Global G;

	void Start ()
	{
		inputFieldObject = GameObject.Find ("InputField");
		inputField = inputFieldObject.GetComponent<InputField> ();
		inputFieldPH = inputFieldObject.GetComponent<InputField> ().placeholder.GetComponent<Text> ();

		mainCommands = GameObject.Find("commands").GetComponent<Text>();
		menu1 = "C:"+ (char)92 + "> commands_page1\n  play easy/hard\n  vol up/down\n  next page\n  quit";
		menu2 = "C:"+ (char)92 + "> commands_page2\n  move arrows/wasd\n  reset (highscore)\n  credits\n  back";
		credits = "rikematdev.tumblr.com/\n  with love for my <3\n  friends bi and gah\n\n  back";
		mainCommands.text = menu1;

		audioManager.StartMenu();

		G = GameObject.Find ("Global").GetComponent<Global>();
	}
	void Update ()
	{
        if(SelectText)
		    SelectGameObject (inputFieldObject);
	}

	public void CheckInputField(string text)
	{
        //page1
        if (text == "play easy" || text == "play")
        {
            G.SetDifficulty("easy");
            SelectText = false;
            StartCoroutine(G.StartGameWithDelay());
            inputFieldPH.text = "playing on easy...";
        }
        else if (text == "play hard")
        {
            G.SetDifficulty("hard");
            SelectText = false;
            StartCoroutine(G.StartGameWithDelay());
            inputFieldPH.text = "playing on hard...";
        }
        else if (text == "vol up")
        {
            G.audioManager.VolumeUp();
            inputFieldPH.text = "music volume up";
        }
        else if (text == "vol down")
        {
            G.audioManager.VolumeDown();
            inputFieldPH.text = "music volume down";
        }
        else if (text == "next page" || text == "next")
        {
            mainCommands.text = menu2;
            inputFieldPH.text = "enter command";
        }
        else if (text == "quit")
        {
            inputFieldPH.text = "quiting game";
            Application.Quit();
        }
        //page2
        else if (text == "move arrows")
        {
            G.SetMovement("arrows");
            inputFieldPH.text = "moving on arrows";
        }
        else if (text == "move wasd")
        {
            G.SetMovement("wasd");
            inputFieldPH.text = "moving on wasd";
        }
        else if (text == "reset" || text == "reset highscore")
        {
            PlayerPrefs.DeleteKey("playerScore");
            inputFieldPH.text = "highscore reset";
        }
        else if (text == "credits")
        {
            mainCommands.text = credits;
            inputFieldPH.text = "enter command";
        }
        else if (text == "back")
        {
            mainCommands.text = menu1;
            inputFieldPH.text = "enter command";
        }
        //extras
        else if (text == "pato")
        {
            mainCommands.text = "Q:" + (char)92 + "> .__o<\n  quack quack/quack\n  quack quack/quack\n  quack quack\n  quack";
            inputFieldPH.text = "quack";
            GameObject.Find("title").GetComponent<Text>().text = "quack";
        }
        else if (text == "bi")
        {
            inputFieldPH.text = "bobinha :3";
        }

        else
            inputFieldPH.text = "unknown command";

		inputField.text = "";
	}

	public void SelectGameObject(GameObject select)
	{
		EventSystem.current.SetSelectedGameObject (
			select, new BaseEventData(EventSystem.current));
		inputField.ActivateInputField ();
	}
}
