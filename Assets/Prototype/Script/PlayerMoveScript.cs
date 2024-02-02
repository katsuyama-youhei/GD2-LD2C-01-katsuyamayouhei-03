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
        // ���͂����i�E�����j�Ńv���C���[�����������Ă���ꍇ�A�܂��͓��͂����i�������j�Ńv���C���[���E�������Ă���ꍇ
        if ((Input.GetButtonDown("Fire2") && !isFacingRight) || (Input.GetButtonDown("Fire3") && isFacingRight))
        {
            // �v���C���[�̌����𔽓]������
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;

            // �v���C���[�̌������X�V
            isFacingRight = !isFacingRight;
        }
    }

    void PlayerMove()
    {
        if (Input.GetButtonDown("Jump") && isFireUp)
        {
            // AddForce���\�b�h�ŗ͂�������
            // ������Vector2�͗͂̕����������AforceMagnitude�͗͂̑傫��
            rb.AddForce(Vector2.up * forceUp, ForceMode2D.Impulse);

            isFireUp = false;

            // �ړ������̋t�����ɒe���΂�
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(bulletDownPrefab, pos, Quaternion.identity);
            }
        }
        else if (Input.GetButtonDown("Fire1") && isFireDown)
        {
            // AddForce���\�b�h�ŗ͂�������
            // ������Vector2�͗͂̕����������AforceMagnitude�͗͂̑傫��
            rb.AddForce(Vector2.down * forceDown, ForceMode2D.Impulse);

            isFireDown = false;

            // �ړ������̋t�����ɒe���΂�
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(bulletUpPrefab, pos, Quaternion.identity);
            }
        }



        if (Input.GetButtonDown("Fire2") && !isFireHorizontal)
        {

            FlipPlayer();

            // AddForce���\�b�h�ŗ͂�������
            // ������Vector2�͗͂̕����������AforceMagnitude�͗͂̑傫��
            rb.AddForce(Vector2.right * forceMagnitude, ForceMode2D.Impulse);

            isFireHorizontal = true;

            isScaleChange = true;
            orijinScale = transform.localScale;
            changeScale = orijinScale;

            // �ړ������̋t�����ɒe���΂�
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = new Vector3(transform.position.x - 0.72f, transform.position.y, 0);
                Instantiate(bulletLeftPrefab, pos, Quaternion.identity);
            }
        }
        else if (Input.GetButtonDown("Fire3") && !isFireHorizontal)
        {
            FlipPlayer();

            // AddForce���\�b�h�ŗ͂�������
            // ������Vector2�͗͂̕����������AforceMagnitude�͗͂̑傫��
            rb.AddForce(Vector2.left * forceMagnitude, ForceMode2D.Impulse);

            isFireHorizontal = true;

            isScaleChange = true;
            orijinScale = transform.localScale;
            changeScale = orijinScale;

            // �ړ������̋t�����ɒe���΂�
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
