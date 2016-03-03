/// <summary>
///  The message that shows at the beginning, telling you what to do and showing
///  a bigger picture of your character.
/// </summary>

using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMessage : MonoBehaviour {
	
	private Text message;
	private Image doctorstart;
	public static bool onHold;
	
	void Start () {
		
		message = GameObject.Find("StartMessage").GetComponent<Text>();
		message.text = " ";

		doctorstart = GameObject.Find ("DoctorImage").GetComponent<Image> ();
		doctorstart.enabled = false;
		
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			message.text = "I should find a way to go back home.";
			StartCoroutine (ShortPause ());

			GameObject.Find ("DoctorImage").GetComponent<Image>().enabled = true;
			
		}
	}
	
	IEnumerator ShortPause(){
		onHold = true;
		yield return new WaitForSeconds(3f);
		onHold = false;
		message.text = "";
		GameObject.Find ("DoctorImage").GetComponent<Image>().enabled = false;
		Destroy(gameObject);
		Destroy (this);
		
		
	}
}
