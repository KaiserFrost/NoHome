using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Manager : MonoBehaviour {

	
	//public TextMeshPro comidaText;
	public Text comidaText;
	public Text stolenText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		comidaText.text = ("Snacks: " + SaveValue.Comida);
		stolenText.text = ("Stolen: " + SaveValue.Stolen);

	}
}
