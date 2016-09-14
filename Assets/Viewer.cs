using UnityEngine;
using System.Collections;

public class Viewer : MonoBehaviour {

	public float speed = 5;
	Transform transform;

	void Start () {
		transform = gameObject.transform;
	}
	
	void Update () {
		transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * speed * Time.deltaTime);
		if (Input.GetKey (KeyCode.LeftShift)) {
			transform.position += Vector3.up*speed*Time.deltaTime;
		} else if (Input.GetKey (KeyCode.LeftControl)) {
			transform.position += Vector3.down*speed*Time.deltaTime;
		}
	}
}
