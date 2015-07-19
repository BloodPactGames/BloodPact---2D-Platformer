using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public Rigidbody player;

    //The Players MoveSpeed
    public float moveSpeed = 10;
    //The Strength of the players Jump
    public float jumpStrength = 50;
    //Chi Level of Player (max 3)
    public int chi = 3;
    //Informs the engine that the player is grounded.
    public bool isGrounded = false;
    //Players Health
    public float playersHealth = 100;
    //Which side the player is on
    public bool playerOnLeft = false;
    public bool playerOnRight = false;

    public bool playerOnLeftWall = false;
    public bool playerOnRightWall = false;

    public bool playerOnWall = false;
	// Use this for initialization
	void Start () 
    {
        player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.Log(playersHealth);

        if(isGrounded == true && chi <= 2)
        {
            chi = 3;
        }
	}

    void OnTriggerEnter(Collider other)
    {
       if (other.tag == "TestGround")
       {
           isGrounded = true;
       }
        if(other.tag == "LeftSide")
        {
            playerOnLeft = true;
        }
        if (other.tag == "RightSide")
        {
            playerOnRight = true;
        }
      if (other.tag == "LeftWall")
      {
          playerOnLeftWall = true;
      }
      if (other.tag == "RightWall")
      {
          playerOnRightWall = true;
      }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "TestGround" && chi <= 2)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "TestGround")
        {
            isGrounded = false;
        }
        if (other.tag == "LeftSide")
        {
            playerOnLeft = false;
        }
        if (other.tag == "RightSide")
        {
            playerOnRight = false;
        }
      if (other.tag == "LeftWall")
      {
          playerOnLeftWall = false;
      }
      if (other.tag == "RightWall")
      {
          playerOnRightWall = false;
      }
       
    }
    void FixedUpdate()
    {
        /////Player Movement/////
        //Moves the player Left
        if(Input.GetKey(KeyCode.A))
        {
            player.AddForce(-transform.right * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A) && playerOnLeftWall == true)
        {
            player.isKinematic = true;
        }
        else if (Input.GetKey(KeyCode.D) && playerOnRightWall == true)
        {
            player.isKinematic = true;
        }
        else
        {
            player.isKinematic = false;
        }
        //Moves the player right
       if (Input.GetKey(KeyCode.D))
       {
           player.AddForce(transform.right * moveSpeed);
       }
       //Jump
        if(Input.GetKeyDown(KeyCode.Space) && chi > 0)
        {
            player.AddForce(transform.up * jumpStrength);
            chi -= 1;
        }
       // if(isGrounded == true && chi <= 2)
       // {
       //     chi = 3;
       // }

       //if (Input.GetKey(KeyCode.T))
       //{
       //    player.MovePosition(transform.position + transform.right * 1);
       //}
    }
}
