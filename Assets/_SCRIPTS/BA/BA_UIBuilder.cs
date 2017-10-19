using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BA_UIBuilder : MonoBehaviour {

	#region Variables

	#region Floats

	//Hold the screen dimensions
	float screenX;
	float screenY;

	//These are the results of screenX and Y divided by 100.0f
	//These are used to scale UI elements by percent values
	float screenXSectionLength;
	float screenYSectionLength;

	#endregion

	#region Ints

	#endregion

	#region UI Elements
	//References main canvas
	GameObject mainCanvas;

	GameObject testPanel;

	public GameObject panelPrefab;

	#endregion

	#region UI Class

	#endregion

	#endregion

	void Awake(){
		//Assigns the screen values
		SetScreenSizeFloats();

		//Sets screen section lengths
		CalculateScreenSectionLengths ();

		//Assigns main canvas
		mainCanvas = GameObject.Find("Canvas_Main");
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.A)) {
			SetScreenSizeFloats ();
			CalculateScreenSectionLengths ();
			SetElementSize (testPanel, 50, 50);
			SetElementPosition (testPanel, 15, 15);
		}
		if(Input.GetKeyDown(KeyCode.F)){
			testPanel = AddPanelToElement ("testPanel", mainCanvas);
			ChangeElementColor (testPanel, Color.red);

		}
		//Need to add a check for if the screen changes size.
		//If it does, need to re-calculate screen element sizes
	}

	#region Functions

	#region Alter Elements

	#endregion

	#region Generate Elements

	//These functions differ because there is not a panel type; it has to be prefab'd
	GameObject AddPanelToElement(string _name, GameObject _toAddPanelTo){
		GameObject newPanel = Instantiate (panelPrefab) as GameObject;
		newPanel.name = _name;
		newPanel.transform.SetParent (_toAddPanelTo.transform, false);
		
		return newPanel;
	}
	
	//Generates new UI object. Sets its name and parent
	GameObject GenerateNewUIObject(string _name, GameObject _parent){
		GameObject newObj = new GameObject ();
		newObj.name = _name;
		newObj.transform.SetParent (_parent.transform);
		
		return newObj;
	}

	#endregion

	//Calculates how large the screen sections are. Basically breaks the screen up
	//into 100 pieces in both the x and y directions based off screen pixels.
	//This allows for creating UI elements at percent values of the screen size.
	public void CalculateScreenSectionLengths(){
		screenXSectionLength = screenX / 100f;
		screenYSectionLength = screenY / 100f;
	}

	//Changes the color of an element. This only works on elements color by an image
	void ChangeElementColor(GameObject _toColor, Color _color){
		_toColor.GetComponent<Image> ().color = _color;
	}

	void ChangeElementRectTransform(GameObject _toAlter){
		
	}

	public Vector2 ReturnSizePercentages(GameObject _toSize){
		RectTransform toSize = _toSize.GetComponent<RectTransform> ();

		float percentX = toSize.sizeDelta.x / screenXSectionLength;
		float percentY = toSize.sizeDelta.y / screenYSectionLength;
		//percentX += 100f;
		//percentY += 100f;

		return new Vector2 (percentX, percentY);
	}

	public Vector2 ReturnPositionPercentages(GameObject _toMeasure){
		RectTransform toSize = _toMeasure.GetComponent<RectTransform> ();

		float percentX = toSize.transform.localPosition.x / screenXSectionLength;
		float percentY = toSize.transform.localPosition.y / screenYSectionLength;
		percentX += 50f;
		percentY += 50f;

		return new Vector2 (percentX, percentY);
	}

	//Sets the size of the element. Must be integers for percents
	//Use negative percent values to shrink the element
	public void SetElementSize(GameObject _toAlter, int _percentX, int _percentY){
		RectTransform toAlter = _toAlter.GetComponent<RectTransform> ();

		//Gives percent amount of screen sections. This is in pixels, which is why
		//it works as a float. This guarantees that a percent size deemend by a 
		//designer will be the same no matter what the screen size is.
		float xValue = screenXSectionLength * (_percentX - 100);
		float yValue = screenYSectionLength * (_percentY - 100);
		//The percents are changed to negative b/c of how sizeDelta works

		//Increases the size of the element by half of the vector value
		//But does it in both directions; up and down, or left and right
		toAlter.sizeDelta = new Vector2 (xValue, yValue);
	}

	//Will scale the element position between percent positions 
	public void SetElementPosition(GameObject _toAlter, int _percentX, int _percentY){
		RectTransform toAlter = _toAlter.GetComponent<RectTransform> ();

		float xValue = screenXSectionLength * (_percentX - 50);
		float yValue = screenYSectionLength * (_percentY - 50);

		float adjustedXPos = xValue + toAlter.sizeDelta.x;
		float adjustedYPos = yValue + toAlter.sizeDelta.y;

		//Vector3 newPos = new Vector3(adjustedXPos, adjustedYPos, 0f);
		Vector3 newPos = new Vector3(xValue, yValue, 0f);

		toAlter.transform.localPosition = newPos;
	}

	void RectTransformFromTop(GameObject _toAlter, int _percent){
		RectTransform toAlter = _toAlter.GetComponent<RectTransform> ();
		toAlter.sizeDelta -= new Vector2(0f,10f);
	}

	void SetScreenSizeFloats(){
		screenX = Screen.width;
		screenY = Screen.height;
	}

	public void SetScreenSizeFloatsInEditor(float _x, float _y){
		screenX = _x;
		screenY = _y;
	}

	#endregion
}