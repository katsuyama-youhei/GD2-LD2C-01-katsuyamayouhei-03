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

            // �V���������x��ݒ�
            currentColor.a = newAlpha;

            // �V�����F��ݒ�
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

                // �V���������x��ݒ�
                currentColor.a = maxAlpha;

                // �V�����F��ݒ�
                spriteRenderer.color = currentColor;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ������������̃R���C�_�[�̏����擾
        Collider2D otherCollider = collision.collider;

        // ����̃Q�[���I�u�W�F�N�g�̃^�O���擾
        string otherTag = otherCollider.gameObject.tag;

        if (otherTag == "Enemy" && isDamege == true)
        {
            isCollision = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // ������������̃R���C�_�[�̏����擾
        Collider2D otherCollider = collision.collider;

        // ����̃Q�[���I�u�W�F�N�g�̃^�O���擾
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
