using UnityEngine;

public class TimeManager : MonoBehaviour {

	public float slowdownFactor = 0.1f;
	public float slowdownLength = 2f;
	private TimeBehaviour _time;

	void Awake(){
		_time = GetComponent<TimeBehaviour> ();
		if (_time == null)
			Debug.Log ("Add TimeBehaviour Script to this Object");
		_time.localTimeScale = 1f;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Z)) {
			Debug.Log ("Z pressed");
			_time.localTimeScale = slowdownFactor;
		}
		if (Input.GetKeyUp (KeyCode.Z)) {
			Debug.Log ("Z released");
			_time.localTimeScale = 1f;
			//Time.fixedDeltaTime = .02f;
		}
			
	}

	public void DoSlowmotion ()
	{
		_time.localTimeScale = slowdownFactor;
		//Time.fixedDeltaTime = Time.timeScale * .02f;
	}
	public float localDeltaTime(){
		return _time.localDeltaTime;
	}

}
