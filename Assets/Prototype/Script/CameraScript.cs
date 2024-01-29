using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        if (newPosition.x <= -1.0f) { newPosition.x = -1.0f; }

        if (newPosition.y < 0) { newPosition.y = 0; }
        else if (newPosition.y >= 11f && newPosition.y <= 15f) { newPosition.y = 11.0f; }
        else if (newPosition.y > 15f) { newPosition.y = 20.0f; }

        transform.position = newPosition;

       /* if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Prototype");
        }*/
    }
}
