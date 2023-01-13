using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGCycle : MonoBehaviour
{
    public GameManager GM;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //if Vector3()<=(0,-20,0f,0)

        transform.Translate(new Vector3(0, -GM.gameSpeed, 0));
        if (transform.position.y <= -20)//y=-20 quad out of edges
        { transform.position = new Vector3(0, 20, 2f); }
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);

    }
}
