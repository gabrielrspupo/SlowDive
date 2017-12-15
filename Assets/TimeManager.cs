using UnityEngine;

public class TimeManager : MonoBehaviour {

	public float slowdownFactor = 0.1f;
	public float slowdownLength = 2f;
	private TimeBehaviour _time;
    public Player player;
	private AudioSource slowdiveSom;
	private bool tocou = false;
    //public ProgressBar progressBar;
    //public float slowdownLimitSeconds = 10; 

	void Start() {
		slowdiveSom = gameObject.AddComponent<AudioSource> ();
	}

	void Awake(){
		_time = GetComponent<TimeBehaviour> ();

		if (_time == null)
			Debug.Log ("Add TimeBehaviour Script to this Object");
		_time.localTimeScale = 1f;
	}

	void Update ()
	{
        
            if (Input.GetKey(KeyCode.Z))
            {
			if (player.hasEnergy ()) {
				_time.localTimeScale = slowdownFactor;
				if (!slowdiveSom.isPlaying && !tocou) {
					slowdiveSom.PlayOneShot ((AudioClip)Resources.Load ("SlowDive"), 1);
					tocou = true;
				}
			}
            }
            if (Input.GetKeyUp(KeyCode.Z) || !player.hasEnergy())
            {
                _time.localTimeScale = 1f;
				tocou = false;
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
	public void buscarPlayer(){
		player = transform.Find("Carol_0(Clone)").GetComponent<Player>();
	}

}
