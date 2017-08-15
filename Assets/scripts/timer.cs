using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	float time_elapsed;
	int minutes;
	bool stopped;

	// Text Object
	private Text textClock;

	// Use this for initialization
	void Start () {
		minutes = 10;
		time_elapsed = minutes * 60;
		stopped = false;

		textClock = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!stopped) {
			time_elapsed -= Time.deltaTime;
			string minute = timeFormat ((int)(time_elapsed / 60));
			string second = timeFormat ((int)(time_elapsed % 60));

			textClock.text = minute + ":" + second;
		}
	}

	/**
	 * returns 2-digit time format from given number n
	 */
	private string timeFormat(int n) {
		return n.ToString ().PadLeft (2, '0');
	}
}
