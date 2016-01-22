using UnityEngine;
using System.Collections;

public class alienscript : MonoBehaviour {
	
	public Sprite kingShoot;
	public Sprite kingNorm;
	public Transform laser;
	public Transform entrance;
	private int Rando;
	private bool isShooting;
	private Transform char1;
	private int timer = 0;
	private prelaser pl;
	private int rotate = 0;
	private bool paused = false;
	public bool alien = false;
	public AudioClip sound;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		transform.position = new Vector3(0, 2.5f, -7);
		var fx = Instantiate (entrance) as Transform;
		fx.position = transform.position;
		fx.Translate(new Vector3(0, 0, -2));
	}
	
	// Update is called once per frame
	void Update () {
		paused = GameObject.FindWithTag ("leftarr").GetComponent<controllerscript> ().paused;
		
		if (!paused) {
			if (!isShooting) {
				timer++;
				char1 = GameObject.FindGameObjectWithTag ("char").transform;
				if (((transform.position.x) - char1.position.x) > 0) {
					transform.Translate (new Vector3 (-0.025f, 0, 0));
				} 
				else if (Mathf.Abs ((transform.position.x ) - char1.position.x) <= 0.05f) {} 
				else {
					transform.Translate (new Vector3 (0.025f, 0, 0));
				}
				if(timer == 180 ) source.PlayOneShot(sound,1);
				if (timer >= 225) {
					transform.rotation = Quaternion.Euler (0, 0 + rotate, 0);
					rotate += 6;
				}
				if (timer >= 240) {
					isShooting = true;
					timer = 0;
					GetComponent<SpriteRenderer> ().sprite = kingShoot;
					var laser1 = Instantiate (laser) as Transform;
					laser1.position = transform.position;
					laser1.Translate (0, -0.45f, -1.5f);
					pl = laser1.GetComponent<prelaser> ();
					pl.alien = true;
					rotate = 0;
				}
			} 
			else {
				if(timer >= 40) {
					if ((transform.position.x - char1.position.x) > 0) {
						transform.Translate (new Vector3 (0.01f, 0, 0));
					} 
					else if (Mathf.Abs ((transform.position.x) - char1.position.x) <= 0.05f) {} 
					else {
						transform.Translate (new Vector3 (-0.01f, 0, 0));
					}
				}
				timer++;
				if (timer <= 15) {
					rotate += 6;
					transform.rotation = Quaternion.Euler (0, 90 + rotate, 0);
				}
				if (timer == 15) {
					transform.rotation = Quaternion.Euler (0, 180, 0);
					rotate = 0;
				}
				if (timer >= 175) {
					rotate += 6;
					transform.rotation = Quaternion.Euler (0, 180 - rotate, 0);
				}
				if (timer == 180) {
					GetComponent<SpriteRenderer> ().sprite = kingNorm;
				}
				if (timer >= 205) {
					isShooting = false;
					timer = 0;
					rotate = 0;
					transform.rotation = Quaternion.Euler (0, 0, 0);
				}
			}
		}
	}
}
