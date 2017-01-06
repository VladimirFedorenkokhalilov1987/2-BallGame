using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {
	private Vector3 _targetPoint;
	private Vector3 _direction;

	public CanonGameController CanonGameController
	{
		get; set;
	}

	public Vector3 TargetPoint
	{
		set
		{
			_targetPoint=value;
			_direction = _targetPoint-transform.position;
		}
	}

	[SerializeField, Range(-10,10)]
	private float _speed;
	public float Speed
	{
		set
		{
			if(value==0) _speed=1;
			else
			{
				_speed=value;
			}
			//_speed=value==0?1:value;
		}
	}
	void Update () 
	{
		if (Vector3.Distance (transform.position, _targetPoint)<.5f) {
			Destroy(gameObject);
		}
		
		transform.Translate (_direction*_speed*Time.deltaTime);
	}

}
