using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	public GameObject canvas;

	public void Update() {
		if (Player.paused) {
			canvas.SetActive (true);

			if (Input.GetKeyDown (KeyCode.Q))
				Quit ();
		} else {
			canvas.SetActive (false);
		}
	}

	public void Quit() {
		SceneManager.LoadScene ("menu");
		Player.paused = false;
		canvas.SetActive (false);
	}
}
