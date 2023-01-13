using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public Sprite[] spriteArray=new Sprite[14];
    public int currentFrame;
    private float timer;
    public float frameRate;
    void Start()
    {
        currentFrame = 0;
        timer = 0;
    }

    
    void Update()
    {
        timer += 1*Time.deltaTime;
        if (timer >= frameRate)
        {
            mySpriteRenderer.sprite = spriteArray[currentFrame];
            currentFrame++;
            if (currentFrame == spriteArray.Length)
            { Destroy(gameObject); }
            timer = 0;
        }
    }
}
