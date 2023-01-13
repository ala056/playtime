using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameManager GM;
    public GameObject myPrefab;
    public AudioClip BonusSound;
    public AudioSource GMAS;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-GM.limitScreen, GM.limitScreen), 20, 0);
    }

    void Update()
    {
        transform.Translate(0, -GM.gameSpeed, 0, Space.World);
        transform.Rotate(new Vector3(0, 0, 1), Space.World);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GM.score++;
            //sound :
            GMAS.PlayOneShot(BonusSound);
            ResetCycle(22);

        }
        if (other.gameObject.name == "Pit")
        {
            ResetCycle(17);

        }
        if (other.gameObject.name == "Planet") //to  avoid bonus and planet overlap
        {
            ResetCycle(other.transform.position.y + 5);
        }
    }
    private void ResetCycle(float ypos)
    {
        Instantiate(myPrefab, new Vector3(Random.Range(-GM.limitScreen, GM.limitScreen), ypos, 0), myPrefab.transform.rotation);
        Destroy(gameObject);

    }
}
