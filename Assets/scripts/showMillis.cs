using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showMillis : MonoBehaviour {

	private float time_elapsed;
	private Text textClock;

	// Use this for initialization
	void Start () {
		time_elapsed = 1000.0f;
		textClock = GetComponent<Text> ();
		enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (enabled) {
			time_elapsed -= Time.deltaTime;
			int decimal_part = (int)((time_elapsed - (int)time_elapsed) * 100);
			string millis = decimal_part.ToString ().PadLeft (2, '0');
			textClock.text = millis;
		}
	}
}
