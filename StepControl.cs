using UnityEngine;
using System.Collections;

public class StepControl : MonoBehaviour {

	private bool stepMode = true ;
	private bool stopping = false ;
	public float frameParSec = 30.0f ;
	float timeForFrame = 0.0f ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (stepMode) {
			if ( !stopping ){
				// Count time
				timeForFrame += Time.deltaTime ;
				if ( timeForFrame > 1.0f / frameParSec ){
					Time.timeScale = 0;
					stopping = true ;
				}
			}
		}
	}

	void OnGUI()
	{
		Rect rect1 = new Rect(10, 10, 400, 30);
		stepMode = GUI.Toggle(rect1, stepMode, "Step mode");
		if (!stepMode) {
			Time.timeScale = 1.0f ;
		}

		if (GUI.Button (new Rect (10, 50, 100, 30), "Next Frame")) {
			stopping = false ;
			timeForFrame = 0.0f ;
			Time.timeScale = 1.0f ;
		}
	}
}
