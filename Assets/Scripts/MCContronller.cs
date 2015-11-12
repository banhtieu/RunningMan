using UnityEngine;
using System.Collections;

public class MCContronller : MonoBehaviour {

	public GameObject ground;
	public Vector3 speed;
	protected Animator animator;
	public const int numGround = 25;
	public Vector2 movingForce;
	public Vector2 jumpForce;
	Rigidbody2D rigibody2D;
	public GameObject particalSystem;
	
	// Use this for initialization
	void Start () {
	
		speed = new Vector3(5, 0, 0);
		movingForce = new Vector2(10, 0);
		jumpForce = new Vector2(0, 50);
		rigibody2D = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator>();
		
		Vector3 groundPos = ground.transform.position;
		for(int i = 0; i < numGround; i++)
		{
			Instantiate(ground, new Vector3(groundPos.x + i * 0.7f, groundPos.y, groundPos.z), ground.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 localScale = transform.localScale;
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			//gameObject.transform.Translate(-speed * Time.deltaTime);
			rigibody2D.AddForce(-movingForce);
			if(localScale.x > 0)
			{
				localScale.x *= -1.0f;
			}
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			//gameObject.transform.Translate(speed * Time.deltaTime);
			rigibody2D.AddForce(movingForce);
			if(localScale.x < 0)
			{
				localScale.x *= -1.0f;
			}
		}
		
	
		transform.localScale = localScale;
		
		if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
			animator.SetBool("isIdle", false);
			animator.SetBool("isRunning", true);
		}
		else {
			animator.SetBool("isIdle", true);
			animator.SetBool("isRunning", false);
		}
		
		if(Input.GetKey(KeyCode.UpArrow))
		{
			animator.SetBool("isJumping", true);
			animator.SetBool("isIdle", false);
			animator.SetBool("isRunning", false);
		}
		
		if(gameObject.transform.position.y < -30)
		{
			Application.LoadLevel("GameOver");
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("trigger with " + other.gameObject.tag);
		if(other.gameObject.tag == "coin")
		{
			Destroy(other.gameObject);
			Instantiate(particalSystem, other.gameObject.transform.position, other.gameObject.transform.rotation);
		}
	}
}
