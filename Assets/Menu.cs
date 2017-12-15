using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public GameObject screen1;
	public GameObject screen2;

	public void goToScreen1() {
		screen1.SetActive (true);
		screen2.SetActive (false);
	}

	public void goToScreen2() {
		screen1.SetActive (false);
		screen2.SetActive (true);
	}

	public void Play() {
		SceneManager.LoadScene ("DownFall Stage1");
	}

	public void Quit() {
		Application.Quit ();
	}
}
