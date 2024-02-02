using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float forceMagnitude = 8f;
    public float forceUp = 8f;
    public float forceDown = 3f;

    private bool isFacingRight = true;

    public GameObject bulletRightPrefab;
    public GameObject bulletLeftPrefab;
    public GameObject bulletUpPrefab;
    public GameObject bulletDownPrefab;

    private float lifeFireTime;
    private float fireLeftTime;
    private float fireRightTime;
    private float fireUpTime;
    private float fireDownTime;

    private bool isFireLeft = true;
    private bool isFireRight = true;
    private bool isFireUp = true;
    private bool isFireDown = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeFireTime = 0.3f;
        fireLeftTime = lifeFireTime;
        fireRightTime = lifeFireTime;
        fireUpTime = lifeFireTime;
        fireDownTime = lifeFireTime;


    }

    // Update is called once per frame
    void Update()
    {

        PlayerMove();

        FlipPlayer();

        FireJudgment();

    }

    void FlipPlayer()
    {
        // 入力が正（右方向）でプレイヤーが左を向いている場合、または入力が負（左方向）でプレイヤーが右を向いている場合
        if ((Input.GetButtonDown("Fire2") && !isFacingRight) || (Input.GetButtonDown("Fire3") && isFacingRight))
        {
            // プレイヤーの向きを反転させる
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;

            // プレイヤーの向きを更新
            isFacingRight = !isFacingRight;
        }
    }

    void PlayerMove()
    {
        if (Input.GetButtonDown("Jump") && isFireUp)
        {
            // AddForceメソッドで力を加える
            // 引数のVector2は力の方向を示し、forceMagnitudeは力の大きさ
            rb.AddForce(Vector2.up * forceUp, ForceMode2D.Impulse);

            isFireUp = false;

            // 移動方向の逆方向に弾を飛ばす
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(bulletDownPrefab, pos, Quaternion.identity);
            }
        }
        else if (Input.GetButtonDown("Fire1") && isFireDown)
        {
            // AddForceメソッドで力を加える
            // 引数のVector2は力の方向を示し、forceMagnitudeは力の大きさ
            rb.AddForce(Vector2.down * forceDown, ForceMode2D.Impulse);

            isFireDown = false;

            // 移動方向の逆方向に弾を飛ばす
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(bulletUpPrefab, pos, Quaternion.identity);
            }
        }



        if (Input.GetButtonDown("Fire2") && isFireRight)
        {
            // AddForceメソッドで力を加える
            // 引数のVector2は力の方向を示し、forceMagnitudeは力の大きさ
            rb.AddForce(Vector2.right * forceMagnitude, ForceMode2D.Impulse);

            isFireRight = false;

            // 移動方向の逆方向に弾を飛ばす
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = new Vector3(transform.position.x-0.72f, transform.position.y, 0);
                Instantiate(bulletLeftPrefab, pos, Quaternion.identity);
            }
        }
        else if (Input.GetButtonDown("Fire3") && isFireLeft)
        {
            // AddForceメソッドで力を加える
            // 引数のVector2は力の方向を示し、forceMagnitudeは力の大きさ
            rb.AddForce(Vector2.left * forceMagnitude, ForceMode2D.Impulse);

            isFireLeft = false;

            // 移動方向の逆方向に弾を飛ばす
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = new Vector3(transform.position.x+0.72f, transform.position.y, 0);
                Instantiate(bulletRightPrefab, pos, Quaternion.identity);
            }
        }
    }

    void FireJudgment()
    {
        if (!isFireLeft)
        {
            fireLeftTime -= Time.deltaTime;
            if (fireLeftTime <= 0)
            {
                fireLeftTime = lifeFireTime;
                isFireLeft = true;
            }
        }

        if (!isFireRight)
        {
            fireRightTime -= Time.deltaTime;
            if (fireRightTime <= 0)
            {
                fireRightTime = lifeFireTime;
                isFireRight = true;
            }
        }
        if (!isFireUp)
        {
            fireUpTime -= Time.deltaTime;
            if (fireUpTime <= 0)
            {
                fireUpTime = lifeFireTime;
                isFireUp = true;
            }
        }

        if (!isFireDown)
        {
            fireDownTime -= Time.deltaTime;
            if (fireDownTime <= 0)
            {
                fireDownTime = lifeFireTime;
                isFireDown = true;
            }
        }
    }


}
