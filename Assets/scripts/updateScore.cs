using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// Mouse button
		if (Input.GetKeyDown ("mouse 0")) {
			if (touchInsideObject (Input.mousePosition)) {
				updateScoreText ();

			}
		}

		// Single touch
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
				if (touchInsideObject (touch.position)) {
					updateScoreText ();
				}
			}
		}

		// Multi touch
		/*foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
				if (touchInsideObject (touch.position)) {
					updateScoreText ();
				}
			}
		}*/
	}

	private bool touchInsideObject(Vector2 p) {
		Text textObject = GetComponent<Text> ();
		return (p.x >= textObject.rectTransform.position.x - textObject.rectTransform.rect.width / 2
			&& p.x <= textObject.rectTransform.position.x + textObject.rectTransform.rect.width / 2
			&& p.y >= textObject.rectTransform.position.y - textObject.rectTransform.rect.height / 2
			&& p.y <= textObject.rectTransform.position.y + textObject.rectTransform.rect.height / 2);
	}

	private void updateScoreText()
	{
		Text text = GetComponent<Text> ();
		int score = int.Parse(text.text);
		score += 1;
		if (score >= 100)
			score = 0;
		text.text = score.ToString().PadLeft(2, '0');
	}
}
