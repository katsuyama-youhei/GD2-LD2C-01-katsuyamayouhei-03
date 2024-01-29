using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberScript : MonoBehaviour
{
    private GameObject player;
    private PlayerManagerScript playerScript;
    private SpriteRenderer sprites;

    public Sprite sprite0; // 変数の値が1のときに表示するスプライト
    public Sprite sprite1; // 変数の値が2のときに表示するスプライト
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;

    // Start is called before the first frame update
    void Start()
    {
        sprites = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        CheakNull();

    }

    // Update is called once per frame
    void Update()
    {


        NumberChenge();
    }

    public void NumberChenge()
    {
        if (playerScript.getCoinCount == 1)
        {
            sprites.sprite = sprite1;
            return;
        }
        else if (playerScript.getCoinCount == 2)
        {
            sprites.sprite = sprite2;

            return;
        }
        else if (playerScript.getCoinCount == 3)
        {
            sprites.sprite = sprite3;
            return;
        }
        else if (playerScript.getCoinCount == 4)
        {
            sprites.sprite = sprite4;
            return;
        }
        else if (playerScript.getCoinCount == 5)
        {
            sprites.sprite = sprite5;
            return;
        }
        else if (playerScript.getCoinCount == 6)
        {
            sprites.sprite = sprite6;
            return;
        }
        else if (playerScript.getCoinCount == 7)
        {
            sprites.sprite = sprite7;
            return;
        }
        else if (playerScript.getCoinCount == 8)
        {
            sprites.sprite = sprite8;
            return;
        }
        else if (playerScript.getCoinCount == 9)
        {
            sprites.sprite = sprite9;
            return;
        }
        else
        {
            sprites.sprite = sprite0;
            return;
        }

    }

    private void CheakNull()
    {
        if (player == null)
        {
            return;
        }
        playerScript = player.GetComponent<PlayerManagerScript>();
        if (playerScript == null)
        {
            return;
        }

    }



}
