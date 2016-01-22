using UnityEngine;
using System.Collections;

public class ghostscript : MonoBehaviour {

	public int rando;
	public int rando2;
	public float floatrando2;
	public float floatrando;
	public Transform bulletPrefab;
	public Transform teleportFX;
	public Transform char1;
	public badbullet bb;
	public int timer = 0;
	public int spin = 0;
	public float horizSpeed;
	public Vector3 charPosition;
	private bool paused = false;

	// Use this for initialization
	void Start () {
		rando = Random.Range (-240, 240);
		floatrando = (float)rando / 100;
		rando = Random.Range (-100, 100);
		floatrando2 = (float)rando / 100;
		transform.position = new Vector3 (floatrando, 3+floatrando2, -5);
		transform.rotation = Quaternion.Euler(0,90,0);
	}
	
	// Update is called once per frame
	void Update () {
		paused = GameObject.FindWithTag ("leftarr").GetComponent<controllerscript> ().paused;

		if (!paused) {
			timer++;
			if (timer < 80 | timer > 100) {
				spin += 8;
				transform.rotation = Quaternion.Euler (0, 90 + spin, 0);
			} else if (timer == 80) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			}
			if (timer == 90) {
				var shotTransform = Instantiate (bulletPrefab) as Transform;
				shotTransform.position = new Vector3 (transform.position.x, transform.position.y, -9.5f);
				bb = shotTransform.GetComponent<badbullet> ();
				char1 = GameObject.FindGameObjectWithTag ("char").transform;
				charPosition = char1.transform.position;
				horizSpeed = (transform.position.x - charPosition.x) / -2.5f;
				bb.horizontalSpeed = horizSpeed;
				bb.verticalSpeed = 4;
			}
			if (timer == 100) {
				spin = 270;
			}
			if (timer >= 180) {
				spin += 8;
				teleport ();
			}
		}
	}
	
	void teleport () {
		var fx = Instantiate(teleportFX) as Transform;
		fx.position = transform.position;
		rando = Random.Range (-240, 240);
		floatrando = (float)rando / 100;
		rando2 = Random.Range (-150, 150);
		floatrando2 = (float)rando2/100;
		transform.position = new Vector3 (floatrando, 2.5f+floatrando2, -5);
		transform.rotation = Quaternion.Euler(0,90,0);
		timer = 0;
		spin = 0;
	}
}
