using UnityEngine;
using System.Collections;

public class ArcherAI : MonoBehaviour 
{
    public Transform target;

    public Transform spawner;

    public PlayerController playerController;
    public int maxDistance;
    public bool inRange = false;

    public Rigidbody arrow;
    private Transform myTransform;

    public float timer = 3;
	// Use this for initialization
	void Start () 
    {
        myTransform = transform;

        
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if (Vector3.Distance(target.position, myTransform.position) < maxDistance)
        {
            //Move towards target
            transform.LookAt(target.position);
            inRange = true;
        }
        else
            inRange = false;

        if(inRange == true && timer <= 0)
        {
            Rigidbody clone;
            clone = Instantiate(arrow, spawner.transform.position, spawner.transform.rotation) as Rigidbody;
            clone.velocity = spawner.transform.TransformDirection(Vector3.forward * 50);
            //clone = Instantiate(arrow, playerController.player.position, transform.rotation) as Rigidbody;
            timer = 3;
        }
	}
}
