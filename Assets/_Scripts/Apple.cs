using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {

	public static float bottomY = -20f; //the bottom of the screen
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.y < bottomY) {
			Destroy (this.gameObject);// destroy apples if it reaches bottom of the screen

			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); 
			// Call the public AppleDestroyed() method of apScript
			apScript.AppleDestroyed();


		}//end if
	}
}
