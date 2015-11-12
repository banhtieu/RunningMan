using UnityEngine;
using System.Collections;

public class FlappyController : MonoBehaviour {

	public Vector2 flyingForce;
	public Vector2 speed;
	public Rigidbody2D rigidbody2D;
	float velocity;
	Vector2 gravity;
	bool isTouching;
	
	// Use this for initialization
	void Start () {
	
		flyingForce = new Vector2(10.0f, 0.0f);
		rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		velocity = 0.0f;
		speed = new Vector2(0.0f, 0.0f);
		gravity = new Vector2(0.0f, -1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isTouching)
		{
			
			speed.y += gravity.y; // * Time.deltaTime;
			Debug.Log(Time.deltaTime);
			Debug.Log(transform.position.y);
			transform.Translate(transform.position.x, transform.position.y + speed.y /** Time.deltaTime*/, transform.position.z);
			Debug.Log("pos: " + transform.position.y);
			
			//isTouching = false;
		}
		
		if(Input.touchCount == 0)
		{
			if(Input.GetMouseButtonDown(0))
			{
				isTouching = true;
				speed.y = 3.0f;
				Debug.Log("wwheeeee");
			}	
		}
		
	}
}
