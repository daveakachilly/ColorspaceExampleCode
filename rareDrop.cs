using UnityEngine;
using System.Collections;

public class rareDrop : MonoBehaviour {

	public Transform rbstar;
	public Transform cc;
	public Transform heart;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 0.1f);
		int rando = Random.Range (0, 1000);
		if(GameObject.FindWithTag("char").GetComponent<charhealth>() != null) {
			if (rando >=  500 - (3*PlayerPrefs.GetInt ("luckUps", 0) + GameObject.FindWithTag("char").GetComponent<charhealth>().luckUps) && rando <= 525) { 
				var hu = Instantiate (heart) as Transform;
				hu.position = new Vector3 (transform.position.x, transform.position.y, -9.5f);
			}
			if (rando >=  992 - (PlayerPrefs.GetInt ("luckUps", 0) + GameObject.FindWithTag("char").GetComponent<charhealth>().luckUps)) { 
				var rb = Instantiate (rbstar) as Transform;
				rb.position = new Vector3 (transform.position.x, transform.position.y, -9.5f);
			}
			else if(rando <= (PlayerPrefs.GetInt ("luckUps", 0) + GameObject.FindWithTag("char").GetComponent<charhealth>().luckUps)) {
				var rb = Instantiate (cc) as Transform;
				rb.position = new Vector3 (transform.position.x, transform.position.y, -9.5f);
			}
		}
	}
}
