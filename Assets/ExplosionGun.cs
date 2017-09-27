using UnityEngine;

public class ExplosionGun : MonoBehaviour {
    
	public TimeManager timeManager;

	void Update ()
	{
		// If the player presses fire
		if (Input.GetButtonDown("Fire1"))
			Shoot();
	}

	void Shoot ()
	{		
		timeManager.DoSlowmotion();		
	}

}
