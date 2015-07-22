using UnityEngine;
using System.Collections;

public class ProtagAnimation : MonoBehaviour 
{
	public int Lwalking;
	public int Rwalking;

	public int Walltouch;

	void Start () 
	{
		animation.Play("IdleStanding");
	}
	

	void FixedUpdate()
	{

		if (Input.GetKey (KeyCode.D) && Walltouch == 0 ) 
		{
			Rwalking = 1;
			transform.rotation = Quaternion.Euler (0, 90, 0);
			if (Input.GetKeyUp (KeyCode.A))
			{
				Rwalking = 1;
				transform.rotation = Quaternion.Euler (0, 90, 0);
			}

		}
		if (Input.GetKey (KeyCode.A) && Walltouch == 0)
		{
			Lwalking = 1;
			transform.rotation = Quaternion.Euler (0, 270, 0);
			if (Input.GetKeyUp (KeyCode.D))
			{
				Lwalking = 1;
				transform.rotation = Quaternion.Euler (0, 270, 0);
			}
		}

		if (Input.GetKeyUp (KeyCode.D) ) 
		{
			Rwalking = 0;
		}
		if (Input.GetKeyUp (KeyCode.A))
		{
			Lwalking = 0;
		}

		if (PlayerController.jumps == 1) 
		{
			Walltouch = 0;

			if ( Lwalking + Rwalking == 1)
			{
				animation.Play ("RunCycle", PlayMode.StopAll);
			}

			if ( Lwalking + Rwalking == 2 || Lwalking + Rwalking == 0)
			{
				animation.Play("IdleStanding", PlayMode.StopAll);
			}
		}

		if(Input.GetKey(KeyCode.Space) ) 
		{
			if (PlayerController.jumps == 0)
			{
				animation.Play ("Jump", PlayMode.StopAll);
			}

		}

		if (PlayerController.jumps == 0 &&  PlayerController.WallContact == 0 )
		{
			Walltouch = 0;
			if( !Input.GetKey(KeyCode.Space) )
			{
			animation.Play ("AirHang", PlayMode.StopAll);
			}
		}



		if (PlayerController.jumps == 0 && Input.GetKeyUp (KeyCode.Space))
		{
			animation.Play ("AirHang", PlayMode.StopAll);
		}

		if( PlayerController.WallContact == 1 && !Input.GetKey(KeyCode.Space) && !Input.GetKey (KeyCode.D))
		{
			if (Input.GetKey (KeyCode.A))
			{
			animation.Play ("HitWallLeft", PlayMode.StopAll);
			Walltouch = 1;
			}
		}

		if( PlayerController.WallContact == -1 && !Input.GetKey(KeyCode.Space) && !Input.GetKey (KeyCode.A))
		{
			if (Input.GetKey (KeyCode.D) )
			{
			animation.Play ("HitWallRight", PlayMode.StopAll);
			Walltouch = 1;
			}
		}

		if (PlayerController.WallContact == 0 && PlayerController.jumps == 0 && Walltouch == 1 && !Input.GetKey(KeyCode.Space)) 
		{
			animation.Play ("AirHang", PlayMode.StopAll);
		}

	}
}
