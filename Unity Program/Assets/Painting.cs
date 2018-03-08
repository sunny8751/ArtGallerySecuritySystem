using UnityEngine;
using System.Collections;

public class Painting : MonoBehaviour {

	public int id;
	bool timing = false;
	float time=0, startTime = 0;
	Bounds bounds;
	Vector3 point;

	void Start () {
		transform.position = new Vector3 (transform.position.x, 1.7f, transform.position.z);
		startTime = Time.time;
		bounds = gameObject.GetComponent<BoxCollider> ().bounds;
		point = transform.position;
	}

	void Update(){
		//if (timing && Manager.isSeen(bounds)) {
		//if (timing) {
		if (timing) {
			time += Time.deltaTime;
		}
		if (Time.time - startTime >= Manager.totalTime) {
			//start new cycle
			startTime = Time.time;
			Manager.add(time);
			time = 0;
		}
	}
	
	/*
	void OnBecameVisible(){
		Debug.Log (Camera.current.name);
		if(Camera.current.name == "SceneCamera"||Camera.current.name == "Main Camera") return;
		timing = true;
		if(id==42)
			Debug.Log ("lol");
	}
	
	void OnBecameInvisible(){
		timing = false;
		if(id==42)
			Debug.Log ("lol");
	}*/

	void OnTriggerEnter(Collider other) {
		//Debug.Log (other.tag);
		if (!Manager.isSeen(point, (other.tag == "CameraUL")? 0: 1))
			return;
		timing = true;
		ChangeColor (Color.green);
	}

	void OnTriggerExit(Collider other) {
		if (!Manager.isSeen(point, (other.tag == "CameraUL")? 0: 1))
			return;
		timing = false;
		ChangeColor (Color.red);
	}

	void ChangeColor(Color c){
		gameObject.GetComponent<Renderer> ().material.color = c;
	}

	public void setID(int _id){
		id = _id;
	}
}
