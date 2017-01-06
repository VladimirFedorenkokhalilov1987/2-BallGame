using UnityEngine;
using System.Collections;

public class GameController2 : MonoBehaviour {

	public int moveSpeed = 100;
	//public Transform end;
	public GameObject Ball;

	
	public float arriveTime = 3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.Mouse0)){
			GameObject _tempBall = Instantiate(Ball) as GameObject;
			Vector3 mousePosition = Input.mousePosition;
			MoveBall _tempBallMove = _tempBall.GetComponent<MoveBall>();
			Vector3 _tempCameraPosition = Camera.main.ScreenToWorldPoint(mousePosition);
			_tempCameraPosition.z = 0;
			_tempBallMove.PointDelete = _tempCameraPosition;
		}*/		
	}
}
