using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	float time_elapsed;
	int minutes;
	bool stopped;

	// Touch control
	bool validTouch;

	// Text Object
	private Text textClock;

	// Use this for initialization
	void Start () {
		minutes = 10;
		time_elapsed = minutes * 60;
		stopped = true;

		textClock = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Canceled) {
				if (touchInsideObject (touch.position)) {
					validTouch = true;
				}
			}
			else if (touch.phase == TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
				if (validTouch && touchInsideObject (touch.position)) {
					stopped = !stopped;
				}
			}
		}

		if (!stopped) {
			time_elapsed -= Time.deltaTime;
			if (time_elapsed < 0) {
				time_elapsed = 0;
				stopped = true;
			}
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

	private bool touchInsideObject(Vector2 p) {
		Text textObject = GetComponent<Text> ();
		return (p.x >= textObject.rectTransform.position.x - textObject.rectTransform.rect.width / 2
			&& p.x <= textObject.rectTransform.position.x + textObject.rectTransform.rect.width / 2
			&& p.y >= textObject.rectTransform.position.y - textObject.rectTransform.rect.height / 2
			&& p.y <= textObject.rectTransform.position.y + textObject.rectTransform.rect.height / 2);
	}
}
