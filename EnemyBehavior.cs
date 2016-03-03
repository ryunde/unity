/// <summary>
///  Enemy finds the player on map and move towards it.
/// </summary>

using UnityEngine;
using System.Collections;
using System;

public class EnemyBehavior : MonoBehaviour {

	Rigidbody2D rigid;
	Animator animate;
	public CircleCollider2D collision;
	
	public Transform target;
	public float speed = 0.5f;

	void Start () {

		rigid = GetComponent<Rigidbody2D> ();
		animate = GetComponent<Animator> ();
		collision = GetComponent<CircleCollider2D> ();
		//target = GetComponent<Transform> ();

		GameObject.FindGameObjectWithTag ("Player");
	
	}
	
	public void Update () {

		if (target != null) {
			transform.LookAt (target);
			transform.eulerAngles = new Vector3 (0, 0, -transform.eulerAngles.z);
			//transform.Rotate(new Vector2(0, 90),Space.Self);
		}

		float distance = Vector3.Distance (target.transform.position, transform.position);
		if (distance < 2) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

		}

		Vector3 movement_vector = new Vector3 (target.transform.position.x, target.transform.position.y);

		if (movement_vector != Vector3.zero) {
			animate.SetBool ("iswalking", true);
			animate.SetFloat ("input_x", movement_vector.x);
			animate.SetFloat ("input_y", movement_vector.y);
		}
		else {
			animate.SetBool ("iswalking", false);
		}
		
		//rigid.MovePosition (rigid.position + movement_vector * Time.deltaTime);
		/*else {
			animate.SetBool ("iswalking", false);
		}*/
	}

}
