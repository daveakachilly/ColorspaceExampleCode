using UnityEngine;
using System.Collections;

public class alienlaser : MonoBehaviour {

	private float timer = 0;
	private bool paused = false;
	
	// Use this for initialization
	void Start () {
		transform.Translate (0, 0.08f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		paused = GameObject.FindWithTag ("leftarr").GetComponent<controllerscript> ().paused;
		
		if(!paused) {
			Transform char1 = GameObject.FindGameObjectWithTag ("char").transform;
			if ((transform.position.x - char1.position.x) > 0) {
				transform.Translate (new Vector3 (-0.01f, 0, 0));
			} 
			else if (Mathf.Abs (transform.position.x - char1.position.x) > 0.05f)
				transform.Translate (new Vector3 (0.01f, 0, 0));
			}
			timer+=1;
			if (timer <= 40) {
				transform.localScale += new Vector3 (0.02f, 0, 0);
			}
			if (timer >= 60) {
				Destroy (gameObject, 0.3f);
			}
		}
	}
}
