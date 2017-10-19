using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BA_UIController_Title : MonoBehaviour {	
	GameObject[] panels;

	void Awake(){
		//Initializes panels array with the number of relevant panels
		panels = new GameObject[3];

		//Assigns panels for use later
		panels [0] = GameObject.Find ("Button_Panel");
		panels[1] = GameObject.Find ("Option_Panel");
		panels[2] = GameObject.Find ("Credit_Panel");

		//Assigns new button components to specific buttons in the scene view
		Button startButton = GameObject.Find ("Button_Start").GetComponent<Button>();
		Button optionButton = GameObject.Find ("Button_Options").GetComponent<Button>();
		Button creditButton = GameObject.Find ("Button_Credits").GetComponent<Button>();
		Button exitButton = GameObject.Find ("Button_Exit").GetComponent<Button>();

		//Finds inner panel buttons
		Button returnOption = GameObject.Find("Return_Option").GetComponent<Button>();
		Button returnCredit = GameObject.Find("Return_Credit").GetComponent<Button>();

		//Deactivate these panels
		ToggleOptionsPanel();
		ToggleCreditsPanel ();

		//Assigns specific listeners to the buttons for call upon being clicked
		startButton.onClick.AddListener (StartGame);
		optionButton.onClick.AddListener (ToggleOptions);
		returnOption.onClick.AddListener (ToggleOptions);
		creditButton.onClick.AddListener (ToggleCredits);
		returnCredit.onClick.AddListener (ToggleCredits);
		exitButton.onClick.AddListener (ExitGame);
	}
		
	void StartGame(){
		//Switch to the first game scene
		SceneManager.LoadScene("__Main");
		SceneManager.LoadScene("_City",LoadSceneMode.Additive);
	}

	//Toggles the relevant panels
	void ToggleOptions(){
		ToggleStartPanel ();
		ToggleOptionsPanel ();
	}

	//Toggles the relevant panels
	void ToggleCredits(){
		ToggleStartPanel ();
		ToggleCreditsPanel ();
	}

	void ToggleStartPanel(){
		panels [0].SetActive (!panels[0].activeSelf);//Sets panel state to its opposite state
	}

	void ToggleOptionsPanel(){
		panels [1].SetActive (!panels[1].activeSelf);//Sets panel state to its opposite state
	}

	void ToggleCreditsPanel(){
		panels [2].SetActive (!panels[2].activeSelf);//Sets panel state to its opposite state
	}

	void ExitGame(){
		Application.Quit ();
	}
}