using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GangScreen : MonoBehaviour {

	bool isHireButton = true;
	bool hasInitialized = false;

	Button toggleButton;

	GameObject[] applicantPanels = new GameObject[5];

	List<GameObject> thugPanels = new List<GameObject> ();

	GameObject groupPanel;
	public GameObject hiredThugPanelPrefab;

	Text toggleText;

	void Start(){

		//Makes sure these initializers only occur once
		if (hasInitialized == false) {
			toggleButton = GameObject.Find ("Toggle_Button").GetComponent<Button> ();
			toggleText = toggleButton.GetComponentInChildren<Text> ();

			toggleButton.onClick.AddListener (ToggleApplyingThugs);
			toggleButton.onClick.AddListener (ToggleButtonText);

			groupPanel = transform.Find ("Panel_ThugPanelGroup").gameObject;

			applicantPanels [0] = GameObject.Find ("ThugApplicant_Panel1");
			applicantPanels [1] = GameObject.Find ("ThugApplicant_Panel2");
			applicantPanels [2] = GameObject.Find ("ThugApplicant_Panel3");
			applicantPanels [3] = GameObject.Find ("ThugApplicant_Panel4");
			applicantPanels [4] = GameObject.Find ("ThugApplicant_Panel5");

			//Sets the thug of each panel by the element in the randomThug list on the GameController
			for (int a = 0; a < 5; a++) {
				applicantPanels [a].GetComponent<BA_ApplicantPanel> ().panelThug = EventManager.ThugByInt (a);
			}

			hasInitialized = true;
		}

		//This may need to move inside the initialization block
		ToggleApplyingThugs ();
	}

	void OnEnable(){
		EventManager.ThugToHire += GenerateHiredThugPanel;
	}
	void OnDisable(){
		EventManager.ThugToHire -= GenerateHiredThugPanel;
	}

	//Instantiates new hired thug panel from prefab
	void GenerateHiredThugPanel(DS_Thug panelThug){
		//Sets the panel's parent to be the group panel UI object
		GameObject newHiredThugPanel = Instantiate (hiredThugPanelPrefab) as GameObject;
		newHiredThugPanel.transform.SetParent (groupPanel.transform, false);
		//Adds the panel game object to the thugPanels list
		thugPanels.Add (newHiredThugPanel);
	}

	//Toggles the application panels when called
	void ToggleApplyingThugs(){
		for (int i = 0; i < applicantPanels.Length; i++) {
			applicantPanels [i].SetActive (!applicantPanels [i].activeSelf);
		}
		ToggleButtonText ();
		EventManager.ToggleHiredThugs ();
	}

	//Changes the button text when called
	void ToggleButtonText (){
		toggleText.text = isHireButton ? "Hire Thugs" : "Return";
		isHireButton = !isHireButton;
	}
}