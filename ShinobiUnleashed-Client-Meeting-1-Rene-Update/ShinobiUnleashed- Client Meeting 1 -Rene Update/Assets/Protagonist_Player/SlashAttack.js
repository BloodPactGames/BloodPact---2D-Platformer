var Protagonist: Rigidbody;  //player must be assigned in Inspector


var hit: RaycastHit;  //The raycast hit location, from the mouse in the direction of the camera

var fwdHit: RaycastHit;	 //The Raycast hit location, from the Protagonist Ridgid body looking left or right for Slash Step attack 
	
var ChiReset : int; //Script Chi. Slash Step removes all Chi

var TimeOut : int;  //Used in Invokedrepeating TimeOut Function to stop slashstep spam	
		
function Start ()
{
	TimeOut = 2;
}			
function OnCollisionEnter (col : Collision)
	{
		ChiReset = 1;   //if your on the ground or on a wall, Chi is reset to 1
	}				
					
function OnCollisionStay (col : Collision)
	{
		ChiReset = 1;   //if your on the ground or on a wall, Chi is reset to 1, CollisionStay is a backup to stop errors.
	}							
							
									
function FixedUpdate () 
	{		
	if (ChiReset > 0  && TimeOut >= 2)
	{
	
		if (Input.GetButtonDown("Fire1")) //when you left click
			{
			Protagonist.velocity = Vector3(0,0,0); //Stop all "prior" motion
			
     		  //Mouse Controls 
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //casts a ray from the mouse in the direction of camera
				
				
				var fwd = transform.TransformDirection (Vector3.right); //Casts a Ray from this object to the Right
				
				
				if (Physics.Raycast(ray, hit)) //If Raycast hits something in the game world
					{
						var MouseVec = hit.point - Protagonist.position;  //The distance between mouseclick point and the player
						
						var fwdVec : Vector3;  //Variable for the distance from the player to the nearest object --in direction left/right

						InvokeRepeating("Timeout", 0, 1.5);
						TimeOut = 0;
								
					if (MouseVec.x > 0) //if Mouse is on the Right of character
						{
						if (Physics.Raycast (transform.position, fwd, fwdHit))  
							{
								ChiReset = 0; //deplete Chi, Protagonist needs to hit ground or wall for reset
								
								fwdVec = fwdHit.point - Protagonist.position;  //calculate distance to nearest object in direction right
								if (fwdVec.x >= 20)   //if distance is greater than 20 teleport
									{
										transform.Translate(Vector3.right * 19.5);
									}			
								if (fwdVec.x < 20 && fwdVec.x > 0.5) //if distance is less than 20 , go a shorter teleport
									{
										transform.Translate(Vector3.right * (fwdVec.x - 0.5));
									}
							
							}

						}
					if (MouseVec.x < 0) //if Mouse is on the Left of character
						{
						if (Physics.Raycast (transform.position, -fwd, fwdHit))
							{
								ChiReset = 0; //deplete Chi, Protagonist needs to hit ground or wall for reset
								
								fwdVec = fwdHit.point - Protagonist.position; //calculate distance to nearest object in direction left
								if (fwdVec.x <= -20) //if distance is less than -20 teleport
									{
										transform.Translate(Vector3.right * -19.5);
									}			
								if (fwdVec.x > -20 && fwdVec.x < -0.5) //if distance is more than -20 , go a shorter teleport
									{
										transform.Translate(Vector3.right * (fwdVec.x - -0.5));
									}				
							}
						}	
					}			
			}
			}
	}
	
	
	
	
	
function Timeout ()
{
	TimeOut += 1;
	
	if (TimeOut >= 2)
		{
			CancelInvoke();
		}
		
 	print (TimeOut);
}