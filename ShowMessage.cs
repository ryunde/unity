using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ShowMessage : MonoBehaviour
{
	private Text message;
	
	public static bool onHold = false;
	
	void Start()
	{

		message = GameObject.Find("Message").GetComponent<Text>();
		
		message.text = "";
	}
	
	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		if (PlayerMovement.count == 10) {
			if (other.gameObject.tag == "Player") {
				message.text = "You need to find 10 parts in total to use this spaceship.";
			
				StartCoroutine (ShortPause ());
			}
		} else {
			ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();
			
			yield return StartCoroutine (sf.FadeToBlack ());

			Application.Quit();
		}
	}
	
	IEnumerator ShortPause()
	{
		onHold = true;
		yield return new WaitForSeconds(2f);
		onHold = false;
		message.text = "";
	}
}
