using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	private bool _charged;
	[SerializeField]
	private Color _angreColor;
	private Color _origenalColor;

	private Renderer _renderer;

	public GameObject Ball;

	public bool Charged
	{
		get {return _charged;}
		set {_charged = value;}
	}

	public bool _onClick;

	// Use this for initialization
	void Start () {
		_renderer = gameObject.GetComponent<Renderer>();
		if (_renderer != null)
			_origenalColor = _renderer.material.color;
		else
			print ("Error renderer!");
	}
	
	private void OnMouseDown(){

		if (_charged){
			_charged = false;
			_renderer.material.color = _origenalColor;
		}
		else{
			_charged = true;
			_renderer.material.color = _angreColor;
			_onClick = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_onClick) {
			_onClick = false;
			return;
		}
		if(_charged && Input.GetKeyDown(KeyCode.Mouse0)){
			//Shoot (Camera.main.ScreenToWorldPoint(Input.mousePosition));
			GameObject _tempBall = Instantiate(Ball) as GameObject;
			_tempBall.transform.position = transform.position;
			MoveBall _tempBallMove = _tempBall.GetComponent<MoveBall>();
			Vector3 _tempCameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_tempCameraPosition.z = 0;
			_tempBallMove.PointDelete = _tempCameraPosition;
		}
		if(_charged && Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			GameObject _tempBall = Instantiate(Ball) as GameObject;
			_tempBall.transform.position = transform.position;
			MoveBall _tempBallMove = _tempBall.GetComponent<MoveBall>();
			Vector3 _tempCameraPosition = Camera.main.ScreenToWorldPoint(touch.position);
			_tempCameraPosition.z = 0;
			_tempBallMove.PointDelete = _tempCameraPosition;
		}
	}	 
}
