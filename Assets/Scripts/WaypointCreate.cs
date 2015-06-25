using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class WaypointCreate: MonoBehaviour, IPointerDownHandler, IDragHandler {
	
	public GameObject wayPoint;
	public string playerTag = "Player";

	void Start () {
		wayPoint.SetActive(false);
	}

	#region IPointerDownHandler implementation
	
	public void OnPointerDown (PointerEventData eventData)
	{
//		Debug.Log ("hit detected");
		MoveWaypoint(eventData);
	}
	
	#endregion
	
	#region IDragHandler implementation
	
	public void OnDrag (PointerEventData eventData)
	{
//		Debug.Log ("drag detected");
		MoveWaypoint(eventData);
	}
	
	#endregion

	public void MoveWaypoint (PointerEventData eventData) {

		Vector3 hitPosition = eventData.pointerCurrentRaycast.worldPosition;
//		GameObject selectedObject = CameraFollow.selected;
		if (CameraFollow.selected.tag == playerTag) {
			NavMeshHit hit;
			if (NavMesh.SamplePosition(hitPosition, out hit, 1, 1)) {
				wayPoint.SetActive(true);
				wayPoint.transform.position = new Vector3 (hitPosition.x, wayPoint.transform.position.y, hitPosition.z);
			}
		}
	}	
}
