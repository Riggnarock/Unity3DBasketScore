using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showMillis : MonoBehaviour {

	private float time_elapsed;
	private Text textClock;

	// Use this for initialization
	void Start () {
		time_elapsed = 2.0f;
		textClock = GetComponent<Text> ();
		enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (enabled) {
			time_elapsed -= Time.deltaTime;
			if (time_elapsed < 0) {
				Reset ();
			}
			int milliseconds = (int)(time_elapsed * 1000f) % 1000;
			int decimal_part = milliseconds;
			if (milliseconds > 100)
				decimal_part /= 10;
			string millis = decimal_part.ToString ().PadLeft (2, '0');

			textClock.text = millis;
		}
	}

	public void Pause() {
		enabled = false;
	}

	public void Enable() {
		enabled = true;
	}

	public void Reset() {
		time_elapsed = 2.0f;
		enabled = false;
	}
}
