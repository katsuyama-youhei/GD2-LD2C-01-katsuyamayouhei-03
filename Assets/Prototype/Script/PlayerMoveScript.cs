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
    private float fireUpTime;
    private float fireDownTime;

    private float fireHorizontalTime;
    private float fireVerticalTime;

    private bool isFireUp = true;
    private bool isFireDown = true;

    private bool isFireHorizontal=false;
    private bool isFireVertical=false;

    private bool isScaleChange = false;
    private Vector3 orijinScale;
    private Vector3 changeScale;
    private float scaleTime;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeFireTime = 0.3f;
        fireUpTime = lifeFireTime;
        fireDownTime = lifeFireTime;
        fireHorizontalTime= lifeFireTime;
        fireVerticalTime= lifeFireTime;
        scaleTime = lifeFireTime;

        orijinScale = transform.localScale;
        changeScale = orijinScale;

    }

    // Update is called once per frame
    void Update()
    {

        PlayerMove();

       // FlipPlayer();

        FireJudgment();

        FireScale();

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



        if (Input.GetButtonDown("Fire2") && !isFireHorizontal)
        {

            FlipPlayer();

            // AddForceメソッドで力を加える
            // 引数のVector2は力の方向を示し、forceMagnitudeは力の大きさ
            rb.AddForce(Vector2.right * forceMagnitude, ForceMode2D.Impulse);

            isFireHorizontal = true;

            isScaleChange = true;
            orijinScale = transform.localScale;
            changeScale = orijinScale;

            // 移動方向の逆方向に弾を飛ばす
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = new Vector3(transform.position.x - 0.72f, transform.position.y, 0);
                Instantiate(bulletLeftPrefab, pos, Quaternion.identity);
            }
        }
        else if (Input.GetButtonDown("Fire3") && !isFireHorizontal)
        {
            FlipPlayer();

            // AddForceメソッドで力を加える
            // 引数のVector2は力の方向を示し、forceMagnitudeは力の大きさ
            rb.AddForce(Vector2.left * forceMagnitude, ForceMode2D.Impulse);

            isFireHorizontal = true;

            isScaleChange = true;
            orijinScale = transform.localScale;
            changeScale = orijinScale;

            // 移動方向の逆方向に弾を飛ばす
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = new Vector3(transform.position.x + 0.72f, transform.position.y, 0);
                Instantiate(bulletRightPrefab, pos, Quaternion.identity);
            }
        }
    }

    void FireJudgment()
    {
      /*  if (!isFireLeft)
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
        }*/
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

        if (isFireHorizontal)
        {
            fireHorizontalTime-=Time.deltaTime;
            if(fireHorizontalTime <= 0)
            {
                fireHorizontalTime = lifeFireTime;
                isFireHorizontal = false;
            }
        }

        if (isFireVertical)
        {
            fireVerticalTime -= Time.deltaTime;
            if (fireVerticalTime <= 0)
            {
                fireVerticalTime = lifeFireTime;
                isFireVertical = false;
            }
        }

    }

    void FireScale()
    {
        if (isScaleChange)
        {
            scaleTime -= Time.deltaTime;
            changeScale.y -= Time.deltaTime;
            if (orijinScale.x >=0)
            {
                changeScale.x += Time.deltaTime;
            }
            else
            {
                changeScale.x -= Time.deltaTime;
            }
            
            transform.localScale = changeScale;
            if (scaleTime <= 0)
            {
                scaleTime = lifeFireTime;
                changeScale = orijinScale;
                transform.localScale = orijinScale;
                isScaleChange = false;
            }
        }

    }


}
