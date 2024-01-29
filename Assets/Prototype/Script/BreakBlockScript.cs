using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BreakBlockScript : MonoBehaviour
{
    public Sprite secondSprite;
    public Sprite therdSprite;
    SpriteRenderer spriteRenderer;

    private int count = 0;
    private float leftLifeTime;
    private float lostLifeTime;
    private bool isBreack=false;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        leftLifeTime = 0.3f;
        lostLifeTime = leftLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 1)
        {
            spriteRenderer.sprite = secondSprite;
        }
        else if (count == 2)
        {
            spriteRenderer.sprite = therdSprite;
        }
        if (isBreack)
        {
            lostLifeTime-=Time.deltaTime;
            if(lostLifeTime < 0)
            {
                isBreack = false;
                lostLifeTime = leftLifeTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string collidedObjectTag = other.tag;
        Debug.Log("break");
        if (collidedObjectTag == ("Bullet"))
        {
            if (!isBreack)
            {
                count += 1;
                isBreack = true;
            }
          
            if (count >= 3)
            {
                Destroy(gameObject);
            }
        }
    }

}
