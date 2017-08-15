using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	float time_elapsed;
	int minutes;
	bool stopped;
	bool paused;

	// Touch control
	bool validTouch;
	Vector2 lastTouchPosition;

	// Text Object
	private Text textClock;

	// Milliseconds counter
	public showMillis millisCounter;

	// Use this for initialization
	void Start () {
		minutes = 10;
		time_elapsed = minutes * 60;
		stopped = false;
		paused = true;

		textClock = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (stopped)
			return;

		// Mouse button
		if (Input.mousePresent) {
			if (Input.GetKeyDown ("mouse 0") && positionInsideObject (Input.mousePosition)) {
				paused = !paused;
				if (paused && millisCounter.enabled)
					millisCounter.Pause ();
			}
			if (Input.GetKeyDown ("mouse 1") && !paused) {
				if (positionInsideSeconds (Input.mousePosition)) {
					time_elapsed -= 10;
				}
				else if (positionInsideMinutes(Input.mousePosition)) {
					time_elapsed -= 60;
				}
			}
		}

		// Single touch
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if (touch.phase == TouchPhase.Began && touch.phase != TouchPhase.Canceled) {
				if (positionInsideObject (touch.position)) {
					validTouch = true;
				}
			}
			lastTouchPosition = touch.position;
		} else if (validTouch) {
			validTouch = false;
			if (positionInsideObject (lastTouchPosition)) {
				paused = !paused;
				if (paused)
					millisCounter.Pause ();
			}
		}

		if (!paused) {
			time_elapsed -= Time.deltaTime;
			if (time_elapsed < 0) {
				time_elapsed = 0;
				stopped = true;
			}
			string minute = timeFormat ((int)(time_elapsed / 60f) % 60);
			string second = timeFormat ((int)(time_elapsed % 60f) % 60);

			if (int.Parse (second) <= 1) {
				millisCounter.Enable ();
			}

			textClock.text = minute + ":" + second;
		}
	}

	/**
	 * returns 2-digit time format from given number n
	 */
	private string timeFormat(int n) {
		return n.ToString ().PadLeft (2, '0');
	}

	private bool positionInsideRange(Vector2 p, int min_x, int max_x, int min_y, int max_y) {
		return (p.x >= min_x && p.x <= max_x && p.y >= min_y && p.y <= max_y);
	}

	private bool positionInsideObject(Vector2 p) {
		Text textObject = GetComponent<Text> ();
		int min_x = (int)(textObject.rectTransform.position.x - textObject.rectTransform.rect.width / 2);
		int max_x = (int)(textObject.rectTransform.position.x + textObject.rectTransform.rect.width / 2);
		int min_y = (int)(textObject.rectTransform.position.y - textObject.rectTransform.rect.height / 2);
		int max_y = (int)(textObject.rectTransform.position.y + textObject.rectTransform.rect.height / 2);
		return positionInsideRange (p, min_x, max_x, min_y, max_y);
	}

	private bool positionInsideMinutes(Vector2 p) {
		Text textObject = GetComponent<Text> ();
		int min_x = (int)(textObject.rectTransform.position.x - textObject.rectTransform.rect.width / 2);
		int max_x = (int)(textObject.rectTransform.position.x);
		int min_y = (int)(textObject.rectTransform.position.y - textObject.rectTransform.rect.height / 2);
		int max_y = (int)(textObject.rectTransform.position.y + textObject.rectTransform.rect.height / 2);
		return positionInsideRange (p, min_x, max_x, min_y, max_y);
	}

	private bool positionInsideSeconds(Vector2 p) {
		Text textObject = GetComponent<Text> ();
		int min_x = (int)(textObject.rectTransform.position.x);
		int max_x = (int)(textObject.rectTransform.position.x + textObject.rectTransform.rect.width / 2);
		int min_y = (int)(textObject.rectTransform.position.y - textObject.rectTransform.rect.height / 2);
		int max_y = (int)(textObject.rectTransform.position.y + textObject.rectTransform.rect.height / 2);
		return positionInsideRange (p, min_x, max_x, min_y, max_y);
	}
}
