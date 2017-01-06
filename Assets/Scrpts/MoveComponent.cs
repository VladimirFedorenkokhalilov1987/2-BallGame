using UnityEngine;
using System.Collections;

public class MoveComponent : MonoBehaviour
{
	[SerializeField, Range(.1f,10f)]
	private float _speed=1;

	public float Speed
	{
		set
		{
			_speed=value;
		}
	}
	private Vector3 pos;
	private bool go =true;

	void Update () 
	{
		{ 
			
			//if(Input.GetMouseButtonDown(0)) {go=true;}
			if(go)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit; 
				
				if (Physics.Raycast(ray, out hit, Mathf.Infinity)) 
				{
					pos = hit.point;
				} 
				Vector3 direction = Vector3.down; 
				float targ_pos = Vector3.Distance(transform.position, pos);
				
				if(targ_pos>1)
				{
					transform.Translate(direction * _speed*Time.deltaTime, Space.World); 
				}
				else
				{go=false;}
			}
		}
	}
}