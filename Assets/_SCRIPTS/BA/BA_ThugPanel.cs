using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BA_ThugPanel : MonoBehaviour {
	Text thugName;
	Text thugSalary;
	Text thugMorale;

	Text smugglingNum;
	Text brewingNum;
	Text snoopingNum;
	Text notorietyNum;

	Button depose;
	Button paySalary;

	public DS_Thug panelThug;

	void Awake(){
		thugName = transform.Find ("Thug_Name").GetComponent<Text> ();
		thugSalary = transform.Find ("Thug_Salary").GetComponent<Text> ();
		thugMorale = transform.Find ("Thug_Morale").GetComponent<Text> ();

		smugglingNum = transform.Find ("Thug_SmugglingNum").GetComponent<Text> ();
		brewingNum = transform.Find ("Thug_BrewingNum").GetComponent<Text> ();
		snoopingNum = transform.Find ("Thug_SnoopingNum").GetComponent<Text> ();
		notorietyNum = transform.Find ("Thug_NotorietyNum").GetComponent<Text> ();

		depose = transform.Find ("Depose_Button").GetComponent<Button> ();
		paySalary = transform.Find ("PaySalary_Button").GetComponent<Button> ();
	}

	void OnEnable ()
	{
		EventManager.HiredPanelToggle += TogglePanelActive;
	}

	void OnDisable ()
	{
		EventManager.HiredPanelToggle -= TogglePanelActive;
	}

	void PopulatePanelValues(DS_Thug panelThug){
		
	}

	void TogglePanelActive(){
		gameObject.SetActive (!gameObject.activeSelf);
	}
}