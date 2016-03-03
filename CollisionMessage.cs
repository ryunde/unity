/// <summary>
///Shows message when a spaceship part is found on the map and destroys object.
/// </summary>

using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollisionMessage : MonoBehaviour {

	private Text message;
	public static bool onHold;

	// Use this for initialization
	void Start () {

		message = GameObject.Find("RelicMessage1").GetComponent<Text>();
		message.text = " ";


	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.tag == "Player") {
				message.text = "You have collected a spaceship part!";
				StartCoroutine (ShortPause ());
			GetComponent<SpriteRenderer>().enabled = false;

			}
	}

	IEnumerator ShortPause(){
		onHold = true;
		yield return new WaitForSeconds(1f);
		onHold = false;
		message.text = "";
		Destroy(gameObject);
		Destroy (this);


	}
}
