using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameManager GM;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float deadZone;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        { MoveRight(); }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.acceleration.x > deadZone)
        { MoveRight(); }
        if (Input.acceleration.x < -deadZone)
        { MoveLeft(); }
    }
    private void MoveRight()
    {
        if ((transform.position.x < GM.limitScreen) && (GM.GS == GameManager.GameState.gamePlay))
        {
            transform.Translate(new Vector3(playerSpeed, 0, 0), Space.World);
            transform.Rotate(new Vector3(0, +1, 0), Space.Self);
            //par defaut tabda Space.self!
        }
    }
    private void MoveLeft()
    {
        if ((transform.position.x > -GM.limitScreen) && (GM.GS == GameManager.GameState.gamePlay))
        {
            transform.Translate(new Vector3(-playerSpeed, 0, 0), Space.World);
            transform.Rotate(new Vector3(0, -1, 0), Space.Self);
        }
    }
}
