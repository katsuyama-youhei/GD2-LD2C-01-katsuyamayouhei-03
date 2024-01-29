using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    private bool isStart = false;

    private float speed = -1f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float hp = 2f;
    private bool isCount = true;

    private float lifeTime;
    private float leftLifeTime;

    public float newAlpha = 0.5f;
    private float maxAlpha = 1f;

    private bool isReversal = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        lifeTime = 0.5f;
        leftLifeTime = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�Ƃ̈ʒu�֌W�ňړ����������ύX
        if (isReversal)
        {
            if (player.transform.position.x > transform.position.x + 10f)
            {
                speed *= -1;
                isReversal = false;
            }
        }
        else
        {
            if (player.transform.position.x < transform.position.x - 10f)
            {
                speed *= -1;
                isReversal = true;
            }
        }


        if (!isStart)
        {
            if (player.transform.position.x > transform.position.x - 14f)
            {
                isStart = true;
            }
        }
        else
        {
            MoveEnemy();
            if (player.transform.position.x > transform.position.x + 14f)
            {
                isStart = false;
            }
        }

        // �_���[�W���󂯂Ă���leftLifeTime�ԐV���Ƀ_���[�W���󂯂Ȃ��悤��
        if (!isCount)
        {
            leftLifeTime -= Time.deltaTime;
            if (leftLifeTime <= 0f)
            {
                isCount = true;
                leftLifeTime = lifeTime;
                Color currentColor = spriteRenderer.color;

                // �V���������x��ݒ�
                currentColor.a = maxAlpha;

                // �V�����F��ݒ�
                spriteRenderer.color = currentColor;
            }
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }

    }
    void MoveEnemy()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    /*  private void OnCollisionEnter2D(Collision2D collision)
      {
          GameObject collidedObject = collision.collider.gameObject;

          if (collidedObject.CompareTag("Bullet"))
          {
              if (isCount)
              {
                  hp -= 1f;
                  isCount = false;
                  Color currentColor = spriteRenderer.color;

                  // �V���������x��ݒ�
                  currentColor.a = newAlpha;

                  // �V�����F��ݒ�
                  spriteRenderer.color = currentColor;
              }
              Debug.Log("hit");
          }
      }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        string collidedObjectTag = other.tag;

        if (collidedObjectTag == ("Bullet"))
        {
            if (isCount)
            {
                hp -= 1f;
                isCount = false;
                Color currentColor = spriteRenderer.color;

                // �V���������x��ݒ�
                currentColor.a = newAlpha;

                // �V�����F��ݒ�
                spriteRenderer.color = currentColor;
            }
            Debug.Log("hit");
        }
    }
}
