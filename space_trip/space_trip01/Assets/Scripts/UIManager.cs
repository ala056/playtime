using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameManager GM;
    public Text ScoreText ,HighScoreText;
    public Image gameOverImage;
    public Button replayButton;
    public AudioClip gameOverMusic;
    private bool gameOverStart;
    void Start()
    {
        gameOverImage.enabled = false;//disable component
        replayButton.gameObject.SetActive(false);//disable Game object whole
        gameOverStart = false;
    }

    void Update()
    {
        ScoreText.text = "Score:" + GM.score;
        if (GM.score >= PlayerPrefs.GetFloat("HighScore")) { ScoreText.color = new Color(255, 0, 0); }
        //if (GM.gameSpeed == 0) { gameOverImage.enabled = true; }
        if ((GM.GS == GameManager.GameState.gameOver)&&(!gameOverStart))
        {
            gameOverStart = true;
            StartCoroutine(ActivateGameOverUI());
            
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("MainScene");
        //SceneManager.GetActiveScene().buildindex;

    }
    private IEnumerator ActivateGameOverUI()
    {
        yield return new WaitForSeconds(2);
        gameOverImage.enabled = true; replayButton.gameObject.SetActive(true);
        HighScoreText.text = "High Score :" + PlayerPrefs.GetFloat("HighScore");
        GM.gameObject.GetComponent<AudioSource>().clip = gameOverMusic;
        GM.gameObject.GetComponent<AudioSource>().Play();
    }
}
