using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private MoveComponent _moveComponent;

	private MoveComponent MyMoveComponent1
	{
		get
		{
			if(_moveComponent==null)
			{
				_moveComponent =GetComponent<MoveComponent>();
			}
			return _moveComponent;
		}
	}

	private float _minY;
	private int _point;
	private float _speed;

	public float Speed {
		set
		{
			if(value<=0){
				_speed=1;
			}
			else
			{
				_speed=value;
			}

			MyMoveComponent1.Speed =_speed;
		//_speed=value<=0?1:value
		}
	}

	public float MinYPos
	{
		set
		{
			_minY=value;
		}
		get
		{
			return _minY;
		}


	}

	public GameController GameController
	{
		get; set;
	}

	public int Point
	{
		set
		{
			if(value<0)
			{
				_point=0;
			}
			else
			{
				_point=value;
			}
			//_point=value<0&0:value;
		}
	}

	public void OnClikc()
	{
		GameController.OnBallEnd (-_point);
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () {
	if (transform.position.y <= _minY) {
			GameController.OnBallEnd(_point);
			Destroy(gameObject);
		}

	}
}
