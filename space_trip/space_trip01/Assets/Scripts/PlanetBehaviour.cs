using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    public Texture[] planetTextures;//=new Texture[4];
    public Renderer myRenderer;
    public GameManager GM;
    public AudioClip explosionSound;
    public Renderer playerRenderer;
    void Start()
    {
        ResetPlanet(16);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -GM.gameSpeed, 0, Space.World);
        transform.Rotate(new Vector3(0, +1, 0), Space.World);

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Pit")
        {
            ResetPlanet(12);
            GM.score++;
        }
        if (other.gameObject.tag == "Player")
        {
            GM.GS = GameManager.GameState.gameOver;
            GM.gameSpeed = 0;
            GM.gameObject.GetComponent<AudioSource>().Stop();
            GM.gameObject.GetComponent<AudioSource>().PlayOneShot(explosionSound);
            playerRenderer.enabled = false;
            playerRenderer.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            playerRenderer.gameObject.transform.GetChild(1).gameObject.SetActive(true);

        }
    }
 //ctrl+a -puis-Ctrl+k+f:  tbar9ich lil code
    private void ResetPlanet(int ypos)
    {
        myRenderer.material.SetTexture("_MainTex", planetTextures[Random.Range(0, 4)]);
        transform.position = new Vector3(Random.Range(-GM.limitScreen, GM.limitScreen), ypos, 0);
        transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

    }

}
