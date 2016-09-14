using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{

	public static float totalTime = 15;
	public static int totalPaintings;
	string fileName = "C:/Users/Sunwoo/Desktop/output.txt";
	//static Plane[] planes1, planes2;
	static Camera camera1, camera2;

	void Awake ()
	{
		//adjust total time because of spotlight's little variable
		totalTime -= 3 * Spotlight.little / Spotlight.speed;
		GameObject [] paintings = GameObject.FindGameObjectsWithTag ("Painting");
		totalPaintings = paintings.Length;
		Debug.Log ("Number of paintings: " + totalPaintings);
		Debug.Log (Application.loadedLevelName);
		for (int i = 0; i < totalPaintings; i++) {
			paintings [i].GetComponent<Painting> ().setID (i + 1);
		}
	}

	void Start ()
	{
		//planes1 = GeometryUtility.CalculateFrustumPlanes (GameObject.Find ("SpotlightUL/Camera").GetComponent<Camera> ());
		//planes2 = GeometryUtility.CalculateFrustumPlanes (GameObject.Find ("SpotlightDR/Camera").GetComponent<Camera> ());
		camera1 = GameObject.Find ("SpotlightUL/Camera").GetComponent<Camera> ();
		camera2 = GameObject.Find ("SpotlightDR/Camera").GetComponent<Camera> ();
	}
	
	void Update ()
	{
	}
	/*
	public static bool isSeen (Bounds bounds) {
		for(int c = 0; c<2; c++){
			Plane[] planes = (c==0)? planes1: planes2;
			if(GeometryUtility.TestPlanesAABB(planes, bounds)){
				return true;
			}
		}
		return false;
	}*/

	public static bool isSeen (Vector3 point, int numb)
	{
		//numb shows which cam to test
		Vector3 cam = (numb == 0) ? camera1.transform.position : camera2.transform.position;
		RaycastHit hit;
		if (Physics.Raycast (point, cam - point, out hit)) {
			//Debug.Log(hit.collider.name);
			if (hit.collider.tag == "Camera") {
				return true;
			}
		}
		return false;
	}
	static int counter = 0;
	static string s = "";
	public static void add(float value){
		counter ++;
		s += value.ToString () + "\t";
		if (counter == totalPaintings) {
			counter = 0;
			System.Console.WriteLine (s);
			s = "";
			Debug.Log("Done");
		}
	}
}
