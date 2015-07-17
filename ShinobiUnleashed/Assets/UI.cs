using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class UI : MonoBehaviour {
	//set public variables
	public float timeLeft = 120.0f;
	public Text timerTextSize;
	public Text uiScore;
	public GameObject gameOverScreen;
	public PlayerController playerController;
	public GameObject Chi1;
	public GameObject Chi2;
	public GameObject Chi3;
	public Slider health;

	void Start()
	{
		//resets the timescale if gameover or reset
		Time.timeScale = 1;
		//access the player controller
		playerController = GetComponent<PlayerController> ();
	}
	void Update()
	{
		//ui score(unfinished)
		uiScore.text = ("Current Score: ");
		                //sets timeleft to the hud
		                timerTextSize.text = "Time left: " + timeLeft;

		                //sets the players health to the health.value slider
		               GetComponent<PlayerController>().playersHealth = health.value;
		                //time left if time less than 0 start gameover
		                timeLeft -= Time.deltaTime;
		PlayerChi ();

		                if(timeLeft < 0)
		{
			GameOver();
			
		}
	}
	void PlayerChi(){
		//accesses the int chi to set which objects in the hud are to be set active
		if (GetComponent<PlayerController>().chi == 1) {
			Chi1.SetActive(true);
			Chi2.SetActive(false);
			Chi3.SetActive(false);
		}
		if (GetComponent<PlayerController>().chi == 2) {
			Chi1.SetActive(true);
			Chi2.SetActive(true);
			Chi3.SetActive(false);
		}
		if (GetComponent<PlayerController> ().chi == 3) {
			Chi1.SetActive (true);
			Chi2.SetActive (true);
			Chi3.SetActive (true);
		} 
		else {
			Chi1.SetActive(false);
			Chi2.SetActive(false);
			Chi3.SetActive(false);
		}
	}
	//game over screen (unfinished)
	void GameOver(){
		gameOverScreen.SetActive (true);
		Time.timeScale = 0;
	}
	//reset function (unfinished)
	public void restart()
	{
	
		//Application.LoadLevel (Scenes.Title);
		gameOverScreen.SetActive (false);

}
}