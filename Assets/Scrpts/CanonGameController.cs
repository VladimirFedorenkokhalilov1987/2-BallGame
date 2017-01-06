using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class CanonGameController : MonoBehaviour {
	bool _isGameStarted=false;
	bool _isSelected;
	public bool IsSelected
	{
		get {return _isSelected;}
		set {_isSelected = value;}
	}
	public bool _clicked;

	public BulletMove BulletMove
	{
		get; set;
	}

	Renderer _renderer;

	[SerializeField]
	private Color _SelectedColor;
	private Color _origColor;


	public float _speed=5f;


	[SerializeField]
	private GameObject _CanonPerfab;

		[SerializeField]
	private GameObject _Bullet;

	private Vector2 Canon1
	{
		get
		{
			//Vector2 pos = Camera.main.ScreenToWorldPoint(Vector3.zero);
			return (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width+70,50)));
		}
	}

	private Vector2 Canon2
	{
		get
		{
			//Vector2 pos = Camera.main.ScreenToWorldPoint(Vector3.zero);
			return (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/4,50)));
		}
	}

	private Vector2 Canon3
	{
		get
		{
			//Vector2 pos = Camera.main.ScreenToWorldPoint(Vector3.zero);
			return (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width/2,50)));
		}
	}

	private Vector2 Canon4
	{
		get
		{
			//Vector2 pos = Camera.main.ScreenToWorldPoint(Vector3.zero);
			return (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width-70,50)));
		}
	}


	void Start ()
	{
		_renderer = GetComponent<Renderer>();
		
		if(_renderer.material.color !=Color.green){
			_origColor = _renderer.material.color;
		}
		else
		{
			print("rend Null");
		}
	}
	
	 private void StartGame ()
{
		if(_CanonPerfab==null)
			{
			print("Eror Perfab NOT FOUND");
			return;
			}
			
		GameObject TempCanon1 =(GameObject) Instantiate (_CanonPerfab);
		GameObject TempCanon2 =(GameObject) Instantiate (_CanonPerfab);
		GameObject TempCanon3 =(GameObject) Instantiate (_CanonPerfab);
		GameObject TempCanon4 =(GameObject) Instantiate (_CanonPerfab);

		if(TempCanon1==null||TempCanon2==null||TempCanon3==null||TempCanon4==null)
		{
			print("Eror Canon NOT FOUND");
			return;
			}			
			
		TempCanon1.transform.localScale=new Vector3(2,3,1);
		TempCanon2.transform.localScale=new Vector3(2,3,1);
		TempCanon3.transform.localScale=new Vector3(2,3,1);
		TempCanon4.transform.localScale=new Vector3(2,3,1);

		Renderer tempRenderer1 = TempCanon1.GetComponent<Renderer>();
		Renderer tempRenderer2 = TempCanon2.GetComponent<Renderer>();
		Renderer tempRenderer3 = TempCanon3.GetComponent<Renderer>();
		Renderer tempRenderer4 = TempCanon4.GetComponent<Renderer>();

			
		if (tempRenderer1 == null||tempRenderer2 == null||tempRenderer3 == null||tempRenderer4 == null)
	{
			return;
	}

		Vector3 pos1 = TempCanon1.transform.position;
		pos1 = Canon1;
		TempCanon1.transform.position = pos1;


		Vector3 pos2 = TempCanon2.transform.position;
		pos2 = Canon2;
		TempCanon1.transform.position = pos2;


		Vector3 pos3 = TempCanon3.transform.position;
		pos3 = Canon3;
		TempCanon3.transform.position = pos3;


		Vector3 pos4 = TempCanon4.transform.position;
		pos4 = Canon4;
		TempCanon4.transform.position = pos4;


	}

	private void OnMouseDown(){
		
		if (_isSelected){
			_isSelected = false;
			_renderer.material.color = _origColor;
		}
		else{
			_isSelected = true;
			_renderer.material.color = _SelectedColor;
			_clicked = true;
		}
	}

	void Update () {
		if (_clicked)
		{
			_clicked=false;
			return;
		}

		if(_isSelected && Input.GetKeyDown(KeyCode.Mouse0)){
			//Shoot (Camera.main.ScreenToWorldPoint(Input.mousePosition));
			GameObject _tempBall = Instantiate(_Bullet) as GameObject;
			_tempBall.transform.position = transform.position;
			BulletMove _tempBallMove = _tempBall.GetComponent<BulletMove>();
			Vector3 _tempCameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_tempCameraPosition.z = 0;
			_tempBallMove.TargetPoint = _tempCameraPosition;
		}
		if(_isSelected && Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			GameObject _tempBullet = Instantiate(_Bullet) as GameObject;
			_tempBullet.transform.position = transform.position;
			BulletMove _tempBulletMove = _tempBullet.GetComponent<BulletMove>();
			Vector3 _tempCameraPosition = Camera.main.ScreenToWorldPoint(touch.position);
			_tempCameraPosition.z = 0;
			_tempBulletMove.TargetPoint = _tempCameraPosition;
		}



					

	}



	private Vector3 GetWorldPosition()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}





	private void OnGUI()
	{
		if (_isGameStarted && GUI.Button (new Rect (500, 10, 100, 100), "Назад")) {
			Application.LoadLevel(0);
		}
		if (_isGameStarted && GUI.Button (new Rect (600, 10, 100, 100), "Выход")) {
			Application.Quit();
		}


		
		if (GUI.Button (new Rect (10, 10, 100, 100), "Start")) {
			_isGameStarted = true;
			StartGame ();
		} 
		else 
		{
			return;
		}
	}
}