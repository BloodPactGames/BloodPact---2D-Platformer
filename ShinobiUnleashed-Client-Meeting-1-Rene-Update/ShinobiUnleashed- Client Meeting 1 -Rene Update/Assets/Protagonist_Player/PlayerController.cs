using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public Rigidbody player;

    //The Players MoveSpeed
    public int moveSpeed;
    //The Strength of the players Jump
    public int jumpStrength;
    //Chi Level of Player (max 3)
    public int chi;
	public int ShlashYesNo;  //SlashStep is handled in a seperate script, but this variable  tells this script to remove Chi or not when clicking the mouse.
    public float playersHealth = 100;

	/*THIS is a static variable that the animation will use in it's script. 
	This number will display if the player hits a wall and weather it's on the left or right.*/
	public static int WallContact;

	public static int jumps; //Shows animation Scrip when Player is On the ground

	//I am the best this is a change


	//THIS IS MY CHANGE DAN

	void Start () 
    {
		chi = 3;
		moveSpeed = 100;
		jumpStrength =2000;
		WallContact = 0;
		ShlashYesNo = 2;
        player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {

        
	}


	void OnCollisionEnter (Collision col)
	{
		moveSpeed = 200;



		//If statements detecting what side of a "wall" the player is hitting, --Used for animation
		if (col.gameObject.tag == "LeftWall") 
		{
			WallContact = -1;
			chi = 3;
            //animation.Play("WallClingIdleLeft");
		}
		if (col.gameObject.tag == "RightWall") 
		{
			WallContact = 1;
			chi = 3;
		}
        if(col.gameObject.tag == "Arrow")
        {
            playersHealth -= 10;
        }
		if (col.gameObject.tag == "TestGround") 
		{
			jumps = 1;
			chi = 3;
		}
	}


	void OnCollisionStay (Collision col)
	{
		//Adding these to "OnCollisionStay" to reinforce the code and to prevent error
		moveSpeed = 200;

		if (col.gameObject.tag == "LeftWall") 
		{
			WallContact = -1;
			//animation.Play("WallClingIdleLeft");
		}
		if (col.gameObject.tag == "RightWall") 
		{
			WallContact = 1;
		}
		if (chi <= 0 && col.gameObject.tag == "TestGround")
        {
           chi = 3;
        }
		if (col.gameObject.tag == "TestGround") 
		{
			jumps = 1;
		}
    }

	void OnCollisionExit (Collision col)
	{
		//This slowes down player motion when mid air by half so the player doesn't speed up when in air
        //chi -= 1;
		moveSpeed = 100;

		if (col.gameObject.tag == "LeftWall" || col.gameObject.tag == "RightWall") 
		{
			WallContact = 0;
			//animation.Play("WallClingIdleLeft");
		}

		if (col.gameObject.tag == "TestGround") 
		{
			jumps = 0;
		}

	}



    void FixedUpdate()
    {
		if (Input.GetButton ("Fire1") && ShlashYesNo >= 2) 
		{
			chi = 0;
			InvokeRepeating("TimeOut", 0, 1.5F);
		}


        /////Player Movement/////
        //Moves the player Left
        if(Input.GetKey(KeyCode.A))
        {
            player.AddForce(Vector3.right * -moveSpeed);
        }

        //Moves the player right
       if (Input.GetKey(KeyCode.D))
       {
			player.AddForce(Vector3.right * moveSpeed);
       }
       //Jump
        if(Input.GetKeyDown(KeyCode.Space) && chi > 0)
        {
			//Stops player velocity in "Y" (up/down) direction, then adds force to jump. Also removes Chi
			player.velocity = new Vector3(player.velocity.x , 0, 0);
			player.AddForce(Vector3.up * jumpStrength);
            chi -= 1;
        }


    }

	void TimeOut ()
	{
		ShlashYesNo += 1;
		if (ShlashYesNo >= 2) 
		{
			CancelInvoke();
		}
	}
}
