using UnityEngine;
using System.Collections;

public class shootandmove : MonoBehaviour {
	public KeyCode shootKey = KeyCode.T;
	public Transform sprite;
	// Use this for initialization
	Animator anim;
	//Speed and jump vary between characters
	public bool spy_spawn;
	public static float Speed = 4.00f;
	public static float Jump = 8.5f;
	public static bool grounded;
	public bool ground;
	public static bool Scout = false;
	public Rigidbody2D rigid;
	Movement Move = new Movement ();
	private SpriteRenderer mySpriteRenderer;


	Ray2D ray;
	RaycastHit2D hit;

	public GameObject gunPoint;
	public GameObject bullet;

	void Start () {
		anim = GetComponent<Animator>();
		
	}
	void FixedUpdate(){
		GroundDetection ();
		ground = grounded;

	}
	  private void Awake()
    {
		mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
	

	// Update is called once per frame
	void Update () {
		anim.SetFloat ("Speed", Mathf.Abs(rigid.velocity.x));
		Move.Motion(Speed, Jump, rigid, grounded, Scout,sprite);

		if(Input.GetKeyDown(shootKey)){
			Shooting ();
		}
	}

	public void GroundDetection(){
		hit = Physics2D.Raycast (GameObject.Find("Feet").transform.position, Vector2.down);

		if(hit.distance < 0.03){
			grounded = true;
		}
		if(hit.distance > 0.03){
			grounded = false;
		}
	}
	public void Shooting(){
		GameObject Bullet = Instantiate (bullet, gunPoint.transform.position, gunPoint.transform.rotation) as GameObject;
		Bullet.tag = "Bullet";
		Destroy (Bullet, 2f);
		if(Movement.facingRight){
			Bullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 400);
			mySpriteRenderer.flipX = false;
		}
		if(!Movement.facingRight){
			Bullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 400);
			mySpriteRenderer.flipX = true;
		}
	}

}