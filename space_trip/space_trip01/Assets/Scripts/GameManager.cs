using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameSpeed;
    public float speedIncreaseRatio;
    [HideInInspector] public int score;
    public float limitScreen;
    public enum GameState { gamePlay, gameOver }
    [HideInInspector] public GameState GS;
    public AudioClip ExitClip;
    void Start()
    {
        score = 0;
        GS = GameState.gamePlay;
    }

    void Update()
    {
        if (GS == GameState.gamePlay)
        { gameSpeed += speedIncreaseRatio * Time.deltaTime; }
        else if(GS == GameState.gameOver)
        { if (score > PlayerPrefs.GetFloat("HighScore"))
                PlayerPrefs.SetFloat("HighScore", score);
                    }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(ExitGame());
 

        } 
    }
    private IEnumerator ExitGame()
    {
        GetComponent<AudioSource>().Stop();
        
        GetComponent<AudioSource>().PlayOneShot(ExitClip);
        gameSpeed = 0;
        yield return new WaitForSeconds(ExitClip.length);
        Application.Quit();

    }
    
}
