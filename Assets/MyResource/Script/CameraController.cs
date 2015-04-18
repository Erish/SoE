using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private	float 				Scroll;
	public	float				moveSpeed;
	public	float				RotateSpeed;
	public	float				ZoomSpeed;
	private	float				zoomDistance;
	public	float				minDistance;
	public	float				maxDistance;
	public	Transform 	CameraObject;
	private	Vector3		 	offset;


	// Use this for initialization
	void Start () {
		zoomDistance = (maxDistance - minDistance) / 2;
	}
	
	// Update is called once per frame
	void Update () {


		//Wheel Zoom
		Scroll = Input.GetAxis ("Mouse ScrollWheel");
		
		if (Scroll != 0.0f) {
		
			this.WheelZoom (Scroll);
		
		}



		//Wheel Drag move
		if (Input.GetMouseButton (2)) {
		
			//DragMove (offset);
			//transform.eulerAngles = Vector3.zero;
		
		}


		//Right-Click Rotate
		if (Input.GetMouseButton (1)) {

			MouseRotate();
		}

		if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}

	
	void WheelZoom(float Scroll){
		/*GameObject _target = GetComponent("Transform") as Transform;*/
		if (Scroll > 0) {
		
			/*Debug.Log("up");*/
			
				if ( minDistance < zoomDistance ){
					float fWheel = Input.GetAxis("Mouse ScrollWheel");
					CameraObject.transform.Translate(0, 0, fWheel * ZoomSpeed);
					//Debug.Log(fWheel);
					zoomDistance -=  fWheel;
				}
				
		} else if (Scroll < 0) {
		
			/*Debug.Log("down");*/
				
				if( maxDistance > zoomDistance ){
					float fWheel = Input.GetAxis("Mouse ScrollWheel");
					CameraObject.transform.Translate(0, 0, fWheel * ZoomSpeed);
					//Debug.Log(fWheel);
					zoomDistance -= fWheel;
				}
		}

	}


	void DragMove(Vector3 offset){
	
		offset = new Vector3(Input.GetAxis("Mouse X") * moveSpeed *-1, Input.GetAxis("Mouse Y") * moveSpeed *-1, 0.0f);
		transform.Translate(offset);
		return;
	
	}


	void MouseRotate(){
		
		//Debug.Log ("Right-Clicked");
		offset = new Vector3((Input.GetAxis("Mouse Y") * RotateSpeed) * -1.0f , Input.GetAxis("Mouse X") * RotateSpeed , 0.0f);
		transform.eulerAngles += offset;
	
	}
}
