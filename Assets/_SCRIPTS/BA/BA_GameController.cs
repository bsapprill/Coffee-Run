using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BA_GameController : MonoBehaviour {

	#region Variables

	#region Class Reference

	//Five is the random number of thugs available each day
	List<DS_Thug> randomThugs = new List<DS_Thug>();

	public Dictionary<string, DS_Thug> hiredThugs = new Dictionary<string, DS_Thug>();

	int runningThugCount;

	SI_GoToNextDay NextDayHandler;
	SI_HUD_Resources Resources;

	#endregion

	#region String

	#endregion
	
	#region UIElements

	#region Button

	Button nextDayButton;

	#endregion

	#region Integer

	public int startingCash;

	#endregion

	#region Text

	Text coffee;
	Text dayOfWeek;
	Text money;
	Text suspicion;
	Text thugs;

	#endregion

	#endregion

	#endregion

	#region Default

	void Awake(){

		//Initialize UI buttons
		nextDayButton = GameObject.Find ("NextDay_Button").GetComponent<Button> ();

		//Initialize HUD texts
		coffee = GameObject.Find ("CoffeeText").GetComponent<Text> ();
		dayOfWeek = GameObject.Find ("CurrentDay_Text").GetComponent<Text> ();
		money = GameObject.Find ("MoneyText").GetComponent<Text> ();
		suspicion = GameObject.Find ("SuspicionText").GetComponent<Text> ();
		thugs = GameObject.Find ("ThugsText").GetComponent<Text> ();

		//Assign class references
		NextDayHandler = GetComponent<SI_GoToNextDay> ();
		Resources = GetComponent<SI_HUD_Resources> ();

		Resources.AddCash (startingCash);

		UpdateCoffeeText ();
		dayOfWeek.text = "Monday";
		UpdateMoneyText ();
		UpdateSuspicionText();
		UpdateThugText ();

		nextDayButton.onClick.AddListener (ChangeDayOfWeek);

		//Adds five random thugs to the list. Not actually random yet.
		for (int a = 0; a < 5; a++) {
			randomThugs.Add(new DS_Thug ());
			randomThugs [a].thugName = a.ToString ();
		}
		runningThugCount = 5;
	}

	void OnEnable(){
		EventManager.ThugToHire += HireThug;
		EventManager.ReturnRandomThug += ReturnRandomThug;
	}
	void OnDisable(){
		EventManager.ThugToHire -= HireThug;
		EventManager.ReturnRandomThug -= ReturnRandomThug;
	}

	#endregion

	#region Function

	void ChangeDayOfWeek(){
		Resources.ChangeDay ();
		dayOfWeek.text = Resources.GetDay ();
		NextDayHandler.NextDay ();
	}

	//Receives a hired thug when a thug applicant panel hire button is pressed
	void HireThug(DS_Thug thugToHire){
		hiredThugs.Add (thugToHire.thugName, thugToHire);
		int randomThugElement = randomThugs.IndexOf (thugToHire);
		randomThugs.RemoveAt (randomThugElement);
		randomThugs.Insert (randomThugElement, new DS_Thug ());
		runningThugCount++;
		randomThugs [randomThugElement].thugName = runningThugCount.ToString ();
	}

	//Used to return the random thug at the passed element
	DS_Thug ReturnRandomThug(int element){
		return randomThugs [element];
	}

	#region UI Update

	public void UpdateCoffeeText(){
		coffee.text = Resources.GetCoffee () + "/"+Resources.GetMaxCoffee()+" lbs.";
	}
	public void UpdateDayText(){
		dayOfWeek.text = Resources.GetDay();
	}
	public void UpdateMoneyText(){
		money.text = "$" + Resources.GetCash() + ".00";
	}
	public void UpdateSuspicionText(){
		suspicion.text = Resources.GetSuspicion () + "/" + Resources.GetMaxSuspicion ();
	}
	public void UpdateThugText(){
		thugs.text = Resources.GetThugs () + "/" + Resources.GetMaxThugs ();
	}
	#endregion

	#endregion
}