using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour 
{
    public float timeLeft = 1f;
    public Text timerTextSize;
    public Text uiScore;
    public GameObject gameOverScreen;
    public PlayerController playerController;
    public GameObject Chi1;
    public GameObject Chi2;
    public GameObject Chi3;
    public Slider health;
    bool paused = false;
    public GameObject pauseMenu;

	// Use this for initialization
	void Start () 
    {
        pauseMenu.SetActive(false);

        gameOverScreen.SetActive(false);

        Time.timeScale = 1;
        health.value = 100;
	}
	
	// Update is called once per frame
    void Update()
    {
        //ui score(unfinished)
        uiScore.text = ("Current Score: ");
        //sets timeleft to the hud
        timerTextSize.text = "Time left: " + timeLeft;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = togglePause();
        }
            //if the paused bool is true call the togglePause function
            
        //sets the players health to the health.value slider
        health.value = playerController.playersHealth;

        //time left if time less than 0 start gameover
        timeLeft -= Time.deltaTime;

        PlayerChi();

        if (timeLeft < 0)
        {
            GameOver();

        }
        if (health.value <= 0)
        {
            GameOver();
        }
    }
    void PlayerChi()
    {
        if (playerController.chi == 0)
        {
            Chi1.SetActive(false);
            Chi2.SetActive(false);
            Chi3.SetActive(false);
        }
        if (playerController.chi == 1)
        {
            Chi1.SetActive(true);
            Chi2.SetActive(false);
            Chi3.SetActive(false);
        }
        if (playerController.chi == 2)
        {
            Chi1.SetActive(true);
            Chi2.SetActive(true);
            Chi3.SetActive(false);
        }
        if (playerController.chi == 3)
        {
            Chi1.SetActive(true);
            Chi2.SetActive(true);
            Chi3.SetActive(true);
        }
    }
    //game over screen (unfinished)
    void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    //reset function (unfinished)
    public void restart()
    {
        Application.LoadLevel ("MainScene");
        gameOverScreen.SetActive(false);
    }

    public void Quit()
    {
        //if you're in unity editor do nothing
    #if UNITY_Editor
		//if you're not then quit the application
    #else
        Application.Quit();
    #endif
    }

    bool togglePause()
    {
        //sets the game object pause menu to true
        pauseMenu.SetActive(true);
        // if the time scale equals 0 already
        if (Time.timeScale == 0f)
        {
            //set the time scale back to 1
            Time.timeScale = 1f;
            //and return the togglePause bool false
            return (false);
        }
        //if not then
        else
        {
            //pause the game by setting the time scale to 0
            Time.timeScale = 0f;
            //and return the togglePause bool true
            return (true);
        }
    }
    public void Resume()
    {
        //resumes the game by setting time scale to zero
        Time.timeScale = 1f;
        //and removes the pause menu by setting it's game object to false
        pauseMenu.SetActive(false);
    }
}
