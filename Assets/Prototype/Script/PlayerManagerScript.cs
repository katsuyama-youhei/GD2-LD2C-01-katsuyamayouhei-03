using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerScript : MonoBehaviour
{

    public int getCoinCount = 0;
    public int clearCoinCount;

    private int hp = 3;

    private bool isCollision = false;

    private float lifeTime;
    private float leftLifeTime;

    private bool isDamege = true;

    private SpriteRenderer spriteRenderer;
    public float newAlpha = 0.5f;
    private float maxAlpha = 1f;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 3.0f;
        leftLifeTime = lifeTime;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Damege();

        //Debug.Log("hp" + hp);
    }

    void Damege()
    {
        if (isCollision)
        {

            hp -= 1;
            isDamege = false;
            isCollision = false;

            Color currentColor = spriteRenderer.color;

            // 新しい透明度を設定
            currentColor.a = newAlpha;

            // 新しい色を設定
            spriteRenderer.color = currentColor;

        }

        if (!isDamege)
        {
            leftLifeTime -= Time.deltaTime;

            if (leftLifeTime <= 0)
            {
                isDamege = true;
                leftLifeTime = lifeTime;
                Color currentColor = spriteRenderer.color;

                // 新しい透明度を設定
                currentColor.a = maxAlpha;

                // 新しい色を設定
                spriteRenderer.color = currentColor;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 当たった相手のコライダーの情報を取得
        Collider2D otherCollider = collision.collider;

        // 相手のゲームオブジェクトのタグを取得
        string otherTag = otherCollider.gameObject.tag;

        if (otherTag == "Enemy" && isDamege == true)
        {
            isCollision = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // 当たった相手のコライダーの情報を取得
        Collider2D otherCollider = collision.collider;

        // 相手のゲームオブジェクトのタグを取得
        string otherTag = otherCollider.gameObject.tag;

        if (otherTag == "Enemy" && isDamege == true)
        {
            isCollision = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string collidedObjectTag = other.tag;

        if (collidedObjectTag == ("Coin"))
        {
            getCoinCount += 1;
            Debug.Log("count" + getCoinCount);
        }
    }
}
