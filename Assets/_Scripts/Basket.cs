using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Basket : MonoBehaviour {

	public Text scoreCounter;
	public int score;
	// Use this for initialization
	void Start () {
		score = 0;
		GameObject scoreGo = GameObject.Find ("ScoreCounter");
		scoreCounter = scoreGo.GetComponent<Text>();
		scoreCounter.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		// Get the current screen position of the mouse from Input
		Vector3 mousePos2D = Input.mousePosition; // 1
		// The Camera's z position sets the how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z; // 2
		// Convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D ); // 3
		// Move the x position of this Basket to the x position of the Mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter( Collision coll ) { // 2
		// Find out what hit this basket
		GameObject collidedWith = coll.gameObject; // 3
		if ( collidedWith.tag == "Apple" ) { // 4
			Destroy( collidedWith );
		}//end if
			
		score += 100; //increase score

		scoreCounter.text = "Score: " + score; //update the score

		if (score > HighScore.score) {

			HighScore.score = score; //updates the highscore
		}//end if
	}//end OnCollisionEnter
}//end class
