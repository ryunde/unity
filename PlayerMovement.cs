/// <summary>
///  Player movement by using arrow keys.
///  Includes HP counter and Spaceship part counter.
/// </summary>

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class PlayerMovement : MonoBehaviour {
	
	public GameObject faderObject;
	public Text countText;
	public static int count;
	public Text countHealth;
	public static int count2;

	private Rigidbody2D rbody;
	private Animator anim;
	private ScreenFader fader;
	private CircleCollider2D collision;

	public ArrayList playerInventory = new ArrayList();
	
	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		fader = faderObject.GetComponent<ScreenFader> ();
		collision = GetComponent<CircleCollider2D> ();
		countHealth = GameObject.Find ("countHealth").GetComponent<Text> ();
		count = 0;
		count2 = 7;
		SetCountText ();
		SetCountHealth ();
	}
	
	void Update () {
		if (fader.isFading == false) {
			Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			
			if (movement_vector != Vector2.zero) {
				anim.SetBool ("iswalking", true);
				anim.SetFloat ("input_x", movement_vector.x);
				anim.SetFloat ("input_y", movement_vector.y);
			} else {
				anim.SetBool ("iswalking", false);
			}
			
			rbody.MovePosition (rbody.position + movement_vector * Time.deltaTime);
		} else {
			anim.SetBool ("iswalking", false);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Relic") {
			playerInventory.Add("Relic");
			count = count + 1;
			SetCountText ();
			foreach (string item in playerInventory) {
				Debug.Log (playerInventory.Count);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Enemy") {
			count2 = count2 - 1;
			SetCountHealth ();
			Debug.Log (count2);
		}
		if (count2 == 0) {
			Application.Quit();
		}
	}

	void SetCountText () {

		countText.text = "Parts found: " + count.ToString ();

	}

	void SetCountHealth ()  {
		countHealth.text = "Health left: " + count2.ToString ();
	}


}
