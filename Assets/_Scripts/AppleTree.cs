using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	public GameObject applePrefab;
	public float speed = 10f; //speed of the apple tree
	public float leftAndRightEdge = 30f; //the end of the screen
	public float chanceToChangeDirections = 0.02f; //chance that the tree will change directions
	public float secsBetweenAppleDrop = 1f; //seconds between each apple drop

	// Use this for initialization
	void Start () {
		InvokeRepeating ("dropApple", 2f, secsBetweenAppleDrop); //repeat the apple dropping
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime; //moves the apple tree
		transform.position = pos;

		if (pos.x < -leftAndRightEdge) { //moves right if it reaches end of screen
			speed = Mathf.Abs (speed);
		}//end if
		else if (pos.x > leftAndRightEdge) { //moves left if it reaches end of screen
			speed = -Mathf.Abs (speed);
		}//end else if

	}//end update

	void FixedUpdate(){
		if (Random.value < chanceToChangeDirections) { //chance to change directions
			speed *= -1;
		}//end else if
	}//end FixUpdate

	void dropApple(){ //set the position of the apple to the tree.
		GameObject apple = Instantiate (applePrefab) as GameObject;
		apple.transform.position = transform.position;
	}//end dropApple
		

}//end class
