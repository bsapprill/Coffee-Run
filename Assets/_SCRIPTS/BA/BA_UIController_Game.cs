using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BA_UIController_Game : MonoBehaviour {
	GameObject optionsPanel;
	GameObject gangPanel;

	void Awake(){
		optionsPanel = GameObject.Find ("Panel_Pause_Fadeout");
		gangPanel = GameObject.Find ("Panel_Gang");

		Button returnButton = GameObject.Find ("Button_ReturnToTitle").GetComponent<Button>();
		Button exitButton = GameObject.Find ("Button_ExitGame").GetComponent<Button>();
		Button gangButton = GameObject.Find ("GangButton").GetComponent<Button> ();
		Button worldButton = GameObject.Find ("WorldButton").GetComponent<Button> ();
		Button cityButton = GameObject.Find ("CityMapButton").GetComponent<Button> ();

		ToggleObjectActive (optionsPanel);
		ToggleObjectActive (gangPanel);

		returnButton.onClick.AddListener (ReturnToTitle);
		exitButton.onClick.AddListener (ExitGame);

	}

	void OnEnable(){
		EventManager.GangPanelToggle += ToggleGangMenu;

	}

	void OnDisable(){
		EventManager.GangPanelToggle -= ToggleGangMenu;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			ToggleObjectActive (optionsPanel);
		}
	}

	//Loads title scene
	void ReturnToTitle(){
		SceneManager.LoadScene ("_TitleScene");	
	}

	//Toggles any objects active state when passed in
	void ToggleObjectActive(GameObject _toToggle){
		_toToggle.SetActive (!_toToggle.activeSelf);//Sets panel state to its opposite state
	}

	//Exits the application when called
	void ExitGame(){
		Application.Quit ();
	}

	void ToggleGangMenu(){
		ToggleObjectActive (gangPanel);
	}
}