using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	private bool _isGameStarted = false;

	private float _timeToPosh;


	[SerializeField]
	private GameObject _BallPerfab;

	private float minSize = 1;
	private float maxSize = 4;

	private int _currScore;

	private Vector2 LeftDownAngle
	{
		get
		{
			//Vector2 pos = Camera.main.ScreenToWorldPoint(Vector3.zero);
			return (Camera.main.ScreenToWorldPoint(Vector2.zero));
		}
	}

	private Vector2 RightUpAngle
	{
		get
		{
			//Vector2 pos = Camera.main.ScreenToWorldPoint(Vector3.zero);
			return (Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height)));
		}
	}

	void Update () {
		
		if (!_isGameStarted)
			return;
		if (Time.time >= _timeToPosh) {
			StartGame();
			_timeToPosh=Time.time+Random.Range(.1f,1F);
		}
	
	}
	private void OnGUI()
	{
		//if (_isGameStarted)
		//	return;


		if(!_isGameStarted && GUI.RepeatButton (new Rect (10,10,100,100),"Start"))
		   {
			_isGameStarted=true;
			//StartGame ();
		}

		if (_isGameStarted) {
			GUI.Box (new Rect (10, 10, 100, 100), _currScore.ToString());
		}
		}

	// Use this for initialization
	void StartGame ()
	{
		if(_BallPerfab==null)
		{
			print("Eror Perfab NOT FOUND");
			return;
		}

		GameObject TempBall =(GameObject) Instantiate (_BallPerfab);

		if(TempBall==null)
		{
			print("Eror Ball NOT FOUND");
			return;
		}

		float randomSize = Random.Range(minSize,maxSize);
		int randomSize2 = Random.Range(1,100);

		TempBall.transform.localScale=Vector3.one*randomSize;

		Renderer tempRenderer = TempBall.GetComponent<Renderer>();

		if (tempRenderer == null) {
			return;}

		float ballWidth = tempRenderer.bounds.size.x;
		float ballHeigth = tempRenderer.bounds.size.y;

		float rendomPosX = Random.Range (LeftDownAngle.x + ballWidth / 2, RightUpAngle.x - ballWidth / 2);
		float rendomPosY = RightUpAngle.y + ballHeigth/2;
		
		Vector3 pos = TempBall.transform.position;
		pos.x = rendomPosX;
		pos.y = rendomPosY;
		
		TempBall.transform.position = pos;

		float minY = LeftDownAngle.y - ballHeigth / 2;
		Ball TempBall2 = TempBall.GetComponent<Ball>();

		TempBall2.MinYPos = minY;
		TempBall2.GameController = this;

		TempBall2.Point = (int)randomSize2;
		TempBall2.Speed = randomSize;

	}

	public void OnBallEnd(int point)
	{
		print (point);
		_currScore -= point;
	}
}