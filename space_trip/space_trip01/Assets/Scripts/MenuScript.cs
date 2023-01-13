using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Text HighScoreText;
    void Start()
    {
        HighScoreText.text= "Highest Score:"+PlayerPrefs.GetFloat("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
        //SceneManager.GetActiveScene().buildindex;

    }
}
