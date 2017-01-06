using UnityEngine;
using System.Collections;

public class MoveBall : MonoBehaviour {
	public Vector3 PointDelete;
	public float moveSpeed = 0.0f;

	// Use this for initialization
	void Start () {
	
	}

	void Update () {

		if (Vector3.Distance(transform.position, PointDelete) > 0.5f) {

			transform.Translate((PointDelete - transform.position) * Time.deltaTime * moveSpeed);
		}
		else{
			Destroy(gameObject);
		}
	}
}
