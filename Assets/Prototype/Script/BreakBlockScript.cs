using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BreakBlockScript : MonoBehaviour
{
    public Sprite secondSprite;
    public Sprite therdSprite;
    SpriteRenderer spriteRenderer;

    public int count = 3;
    private float leftLifeTime;
    private float lostLifeTime;
    private bool isBreack = false;

    public GameObject blockParticle;

   // private CompositeCollider2D com;

   // public float newAlpha = 0.5f;
   // private float maxAlpha = 1f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       // com = GetComponent<CompositeCollider2D>();
        leftLifeTime = 0.3f;
        lostLifeTime = leftLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
         if (count == 2)
         {
             spriteRenderer.sprite = secondSprite;
         }
         else if (count == 1)
         {
             spriteRenderer.sprite = therdSprite;
         }
        if (isBreack)
        {
            lostLifeTime -= Time.deltaTime;
            if (lostLifeTime < 0)
            {
                isBreack = false;
               // com.isTrigger = false;
                /*Color currentColor = spriteRenderer.color;

                // 新しい透明度を設定
                currentColor.a = maxAlpha;

                // 新しい色を設定
                spriteRenderer.color = currentColor;
                lostLifeTime = leftLifeTime;*/
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
                 count -= 1;
                //com.isTrigger = true;
                 isBreack = true;
               /* Color currentColor = spriteRenderer.color;

                // 新しい透明度を設定
                currentColor.a = newAlpha;

                // 新しい色を設定
                spriteRenderer.color = currentColor;*/
            }

            if (count <= 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                    Instantiate(blockParticle, pos, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }

}
