/*using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    public PlayerController playerController;

    public int Damage = 10;
    public float timer = 1;

    
	// Use this for initialization
    void Awake()
    {
        playerController = GetComponent("PlayerController") as PlayerController;

        //playerController = GetComponent<PlayerController>() as PlayerController;
    }
	void Start () 
    {
        //playerController = GetComponent<PlayerController>();
        // playerController = playerController.GetComponent<PlayerController>() as PlayerController;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
            timer = 1;
        }
	}

	void OnCollisionEnter(Collision other)
    {
        
      //  Destroy(other);
    }
}
*/