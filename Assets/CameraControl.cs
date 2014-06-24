using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	private Vector3 oldMousePos;
	private float minX = -1;
	private float minY = -1;
	private float minOrtographicSize = 1;
	private float maxOrtographicSize = 10;
	private Vector3 startingCameraPos;


	void Start () {
		Camera.main.transform.Translate (getCameraWidth () / 2 - Camera.main.transform.position.x, getCameraHeight () / 2 - Camera.main.transform.position.y, 0);
	}

	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize - 50 * Time.deltaTime, minOrtographicSize);
			translateCamera (new Vector3(0,0,0));
		}
		else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize + 50 * Time.deltaTime, maxOrtographicSize);
			translateCamera (new Vector3(0,0,0));
		}
		if (Input.GetMouseButtonDown (0)) {
			oldMousePos = Input.mousePosition;
		}
		if (Input.GetMouseButton (0)) {
			translateCamera (oldMousePos - Input.mousePosition);
			oldMousePos = Input.mousePosition;
		}
	}

	private float getCameraHeight() {
		return 2f * Camera.main.orthographicSize;
	}
	private float getCameraWidth() {
		return 2f * Camera.main.orthographicSize * Camera.main.aspect;
	}

	private void translateCamera(Vector3 translate) {
		var transX = Mathf.Max(Camera.main.transform.position.x + (translate.x) * Time.deltaTime, getCameraWidth ()/2 + minX) - Camera.main.transform.position.x;
		var transY = Mathf.Max(Camera.main.transform.position.y + (translate.y) * Time.deltaTime, getCameraHeight ()/2 + minY) - Camera.main.transform.position.y;
		Camera.main.transform.Translate (transX, transY, 0);
	}
}
