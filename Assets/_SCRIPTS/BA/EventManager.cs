using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	#region Thug

	public delegate void ThugHire(DS_Thug thug);

	public static event ThugHire ThugToHire;
	public static void HireThug(DS_Thug thug){
		ThugToHire (thug);
	}

	public delegate DS_Thug NewThug();

	public static event NewThug NewThugForHire;
	public static DS_Thug AssignNewThug (){
		return NewThugForHire();
	}

	public delegate DS_Thug RandomThug(int element);

	public static event RandomThug ReturnRandomThug;
	public static DS_Thug ThugByInt (int element){
		return ReturnRandomThug(element);
	}

	public delegate DS_Thug HiredThug(string name);

	public static event HiredThug ThugByName;
	public static DS_Thug ReturnThug (string ThugName){
		return ThugByName(ThugName);
	}

	#endregion

	#region UI

	public delegate void UIState();

	public static event UIState GangPanelToggle;
	public static void ToggleGangPanel (){
		GangPanelToggle();
	}

	public static event UIState HiredPanelToggle;
	public static void ToggleHiredThugs (){
		HiredPanelToggle();
	}

	#endregion
}