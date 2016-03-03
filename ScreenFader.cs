/// <summary>
///  Animation to make the screen fade black and then back to clear.
/// </summary>

using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

	Animator anim;
	public bool isFading = false;

	void Start () {
		anim = GetComponent<Animator> ();
	
	}

	public IEnumerator FadeToClear() {
		isFading = true;
		anim.SetTrigger ("FadeIn");

		while (isFading)
			yield return null;
	}

	public IEnumerator FadeToBlack () {
		isFading = true;
		anim.SetTrigger ("FadeOut");

		while (isFading)
			yield return null;
	}
	
	void AnimationComplete () {
		isFading = false;
	}
}
