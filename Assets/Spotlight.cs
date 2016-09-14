using UnityEngine;
using System.Collections;

public class Spotlight : MonoBehaviour
{

	bool stop = false;
	public int min, max;
	public static float speed = 8;//8 degrees per second
	public static float little = 2f;
	public bool pause = false;
	int dir = 1;
	Transform transform;

	void Start ()
	{
		transform = gameObject.transform;
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + little, transform.rotation.eulerAngles.z);
		if (stop) {
			Manager.totalTime += 2;
			StartCoroutine ("Pause", min+little);
		}
	}
	
	void Update ()
	{
		if (!pause) {
			transform.rotation = Quaternion.Euler (15, transform.rotation.eulerAngles.y + speed * dir * Time.deltaTime, 0);
		}
		if (transform.rotation.eulerAngles.y <= min + little && !pause) {
			dir = 1;
			if (stop) {
				StartCoroutine ("Pause", min+little);
			}
		} else if (transform.rotation.eulerAngles.y >= max - little && !pause) {
			dir = -1;
			if (stop) {
				StartCoroutine ("Pause", max-little);
			}
		}
	}

	IEnumerator Pause (float value)
	{
		pause = true;
		yield return new WaitForSeconds (1f);
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, value, transform.rotation.eulerAngles.z);
		pause = false;
		yield return null;
	}
}
