using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLeftScript : MonoBehaviour
{
    private float lifeTime;
    private float leftLifeTime;
    private Vector3 velocity;
    private Vector3 defaultScale;

    public float speed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0.3f;
        leftLifeTime = lifeTime;
        defaultScale = transform.localScale;
        float maxVelocity = 5;
        float max = 2f;
        velocity = new Vector3(
             Random.Range(-max, max),
            Random.Range(-maxVelocity, maxVelocity),
            0);
    }

    // Update is called once per frame
    void Update()
    {
        leftLifeTime -= Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        /* transform.localScale = Vector3.Lerp
             (
             new Vector3(0, 0, 0),
             defaultScale,
             leftLifeTime / lifeTime
             );*/
        MoveBullet();
        if (leftLifeTime <= 0) { Destroy(gameObject); }
    }

    void MoveBullet()
    {
        Vector3 currentPosition = transform.position;

        // 横方向に速度をかけて位置を更新
        currentPosition.x -= speed * Time.deltaTime;

        // 新しい位置をプレイヤーに適用
        transform.position = currentPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.collider.gameObject;

        if (collidedObject.CompareTag("Player"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string collidedObjectTag = other.tag;

        if (collidedObjectTag == ("Player"))
        {

        }
        else
        {
            Destroy(gameObject);
            Debug.Log("hit");
        }
    }
}
