using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	Animator anim;
	int tiltHash = Animator.StringToHash("TiltDown");

	public GameObject startingWizard;
	public string playerTag = "Player";
	Vector3 startingCameraPosition;
	public static GameObject selected;
	public static GameObject lastWizardSelected;
	public GameObject waypoint;
	public float cameraSmoothing = 0.8f;
	public float zoomDistance = 5f;
	public float minFov = 8f;
	public float maxFov = 14f;
	public float zoomOutSmoothing = 1f;
	public float zoomInSmoothing = 1.5f;

	void Start () {
		selected = startingWizard;
		lastWizardSelected = startingWizard;
		startingCameraPosition = transform.position;
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		//camera follow ////add conditional to turn on off follow
		Vector3 targetPosition = startingCameraPosition + selected.transform.position;
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSmoothing);

		//fov change
		if(Camera.main.orthographic == true){
			if(waypoint.gameObject.activeSelf == true) {
				float dist = Vector3.Distance(selected.transform.position, waypoint.transform.position);
				if(dist > zoomDistance) {
					Camera.main.orthographicSize = Mathf.Clamp((Camera.main.orthographicSize += Time.deltaTime*zoomOutSmoothing), 5.5f, 12f);
				} else {
					if(Camera.main.orthographicSize > 5.5f) {
						Camera.main.orthographicSize = Mathf.Clamp((Camera.main.orthographicSize -= Time.deltaTime*zoomInSmoothing), 5.5f, 12f);
					}
				}
			} else {
				if(Camera.main.orthographicSize > 5.5f) {
					Camera.main.orthographicSize = Mathf.Clamp((Camera.main.orthographicSize -= Time.deltaTime*zoomInSmoothing), 5.5f, 12f);
				}
			}
		} else { //if camera IS NOT orthographic
			if(waypoint.gameObject.activeSelf == true) {
				float dist = Vector3.Distance(selected.transform.position, waypoint.transform.position);
				if(dist > zoomDistance) {
					Camera.main.fieldOfView = Mathf.Clamp((camera.fieldOfView += Time.deltaTime*zoomOutSmoothing), minFov, maxFov);
				} else {
					if(Camera.main.fieldOfView > minFov) {
						Camera.main.fieldOfView = Mathf.Clamp((camera.fieldOfView -= Time.deltaTime*zoomInSmoothing), minFov, maxFov);
					}
				}
			} else {
				if(Camera.main.fieldOfView > minFov) {
					Camera.main.fieldOfView = Mathf.Clamp((camera.fieldOfView -= Time.deltaTime*zoomInSmoothing), minFov, maxFov);
				}
			}
		}

		if(selected.tag == playerTag){
			lastWizardSelected = selected;
		}
	}

	public void TiltDown (bool tilt) {
		anim.SetBool(tiltHash, tilt);
	}

	public void ChangeOrthographic () { //remove from final build
		bool isCamOrthographic = Camera.main.orthographic;
		Camera.main.orthographic = !isCamOrthographic;
	}

	public void ChangeCameraTilt () {
		bool tilt = anim.GetBool(tiltHash);
		anim.SetBool(tiltHash, !tilt);
	}
}
