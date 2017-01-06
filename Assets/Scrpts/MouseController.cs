using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SphereCollider))]
public class MouseController : MonoBehaviour
{
	[SerializeField]
	private Color _ColorOn;

	private Ball _ball;
	private Ball Ball
	{
		get
		{
			if(_ball==null)
			{
				_ball =GetComponent<Ball>();
			}
			return _ball;
		}
	}

	private Renderer _renderer;

	private Color _origColor;

	private void OnMouseDown() //colaider need
	{
		print ("Clik");
		Ball.OnClikc();
	}

	private void OnMouseEnter()//colaider need
	{
		print ("Enter");
		_renderer.material.color = _ColorOn;
	}

	private void OnMouseExit ()//colaider need
	{
		print ("Exit");
		_renderer.material.color = _origColor;
	}



	void Start ()
	{
		_renderer = GetComponent<Renderer>();

		if(_renderer !=null){
				_origColor = _renderer.material.color;
		}
		else
		{
			print("rend Null");
		}
	}
	

	void Update ()
	{
	
	}
}
