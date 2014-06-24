using UnityEngine;
using System.Collections;

public class CameraControlBackup : MonoBehaviour {

	private Vector3 oldMousePos;
	private Vector3 startingCameraPos;
	// Use this for initialization
	void Start () {
		startingCameraPos = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize - 50 * Time.deltaTime, 1);
		}
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize + 50 * Time.deltaTime, 10);
		}
		if (Input.GetMouseButtonDown (0)) {
			oldMousePos = Input.mousePosition;
		}
		if (Input.GetMouseButton (0)) {
			var currentMousePos = Input.mousePosition;

			float transX = Mathf.Max (Camera.main.transform.position.x + (oldMousePos.x - currentMousePos.x) * Time.deltaTime * 2, startingCameraPos.x) - Camera.main.transform.position.x;
			float transY = Mathf.Min (Camera.main.transform.position.y + (oldMousePos.y - currentMousePos.y) * Time.deltaTime * 2, startingCameraPos.y) - Camera.main.transform.position.y;
			Camera.main.transform.Translate (transX, transY, 0);
			/*
			Vector3 distance = oldMousePos - currentMousePos;
			Camera.main.transform.Translate (distance * Time.deltaTime * 2);
			float newX = Mathf.Max (Camera.main.transform.position.x, startingCameraPos.x);
			float newY = Mathf.Max (Camera.main.transform.position.y, startingCameraPos.y);
			Camera.main.transform.position = new Vector3(newX, newY, Camera.main.transform.position.z);
	*/
			oldMousePos = currentMousePos;
		}
	}
}
