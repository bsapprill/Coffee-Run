using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BA_ApplicantPanel : MonoBehaviour {

	bool hasInitialized = false;

	Text appTitle;
	Text appName;
	Text smugNum;
	Text brewNum;
	Text snoopNum;
	Text feeNum;

	Button hireButton;

	public DS_Thug panelThug;

	void Start(){
		
		if (hasInitialized == false) {
			appTitle = transform.Find ("Title_Text").GetComponent<Text> ();
			appName = transform.Find ("ApplicantName_Text").GetComponent <Text> ();
			smugNum = transform.Find ("SmugglingSkillNum_Text").GetComponent<Text> ();
			brewNum = transform.Find ("BrewingSkillNum_Text").GetComponent<Text> ();
			snoopNum = transform.Find ("SnoopingSkillNum_Text").GetComponent<Text> ();
			feeNum = transform.Find ("FeeNum_Text").GetComponent<Text> ();

			hireButton = transform.Find ("Button").GetComponent<Button> ();

			hasInitialized = true;
		}

		hireButton.onClick.AddListener (HireThug);
	}

	void OnEnable (){
		
	}

	void OnDisable (){
		
	}

	void HireThug(){
		EventManager.HireThug (panelThug);
		gameObject.SetActive (!gameObject.activeSelf);
	}
}