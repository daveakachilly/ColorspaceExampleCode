using UnityEngine;
using System.Collections;

public class ufoScript : MonoBehaviour {

	public bool right = false;
	private bool floatUp = true;
	private int floatTimer = 0;
	public Transform bullet;
	public badbullet bb;
	private bool paused = false;

	// Use this for initialization
	void Start () {
		if (right) {
			transform.rotation = Quaternion.Euler(0,180,0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		paused = GameObject.FindWithTag ("leftarr").GetComponent<controllerscript> ().paused;

		if (!paused) {
			floatTimer++;
			if (right) {
				transform.Translate (Vector3.left * 1 * Time.deltaTime);
				if (transform.position.x > 3) {
					Destroy (gameObject);
				}
			} else {
				transform.Translate (Vector3.left * 1 * Time.deltaTime);
				if (transform.position.x < -3) {
					Destroy (gameObject);
				}
			}
			if (floatUp) {
				transform.Translate (Vector3.up * 0.3f * Time.deltaTime);
			} else {
				transform.Translate (Vector3.down * 0.4f * Time.deltaTime);
			}
			if (floatTimer >= 90) {
				var shotTransform = Instantiate (bullet) as Transform;
				bb = shotTransform.GetComponent<badbullet> ();
				if (right) {
						bb.horizontalSpeed = 1.5f;
				} 
				else {
					bb.horizontalSpeed = -1.5f;
				}
				bb.verticalSpeed = 4;
				shotTransform.position = new Vector3 (transform.position.x, transform.position.y, -9.5f);
				shotTransform.Translate (new Vector3 (0, -0.3f, 0));
				changeFloat ();
			}
		}
	}

	void changeFloat() {
		floatUp = !floatUp;
		floatTimer = 0;
	}
}
