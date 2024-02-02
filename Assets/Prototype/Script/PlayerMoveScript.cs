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



        if (Input.GetButtonDown("Fire2") && isFireRight)
        {
            // AddForce���\�b�h�ŗ͂�������
            // ������Vector2�͗͂̕����������AforceMagnitude�͗͂̑傫��
            rb.AddForce(Vector2.right * forceMagnitude, ForceMode2D.Impulse);

            isFireRight = false;

            // �ړ������̋t�����ɒe���΂�
            for (int i = 0; i < 8; i++)
            {
                Vector3 pos = new Vector3(transform.position.x-0.72f, transform.position.y, 0);
                Instantiate(bulletLeftPrefab, pos, Quaternion.identity);
            }
        }
        else if (Input.GetButtonDown("Fire3") && isFireLeft)
        {
            // AddForce���\�b�h�ŗ͂�������
            // ������Vector2�͗͂̕����������AforceMagnitude�͗͂̑傫��
            rb.AddForce(Vector2.left * forceMagnitude, ForceMode2D.Impulse);

            isFireLeft = false;

            // �ړ������̋t�����ɒe���΂�
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
