using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    public Transform player, player2;
    public float smoothTime = 0.3f;
    public Camera cam, cam2;
    [SerializeField]
    
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam2.enabled == true)
        {
            cam.rect = new Rect(0, 0, 0.5f, 1);
            Vector3 pos = new Vector2();
            if (player != null)
            {
                pos.x = player.position.x;
                pos.z = player.position.z - 10;
                pos.y = player.position.y;

                transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime);
            }
        }
        else
        {
            cam.rect = new Rect(0, 0, 1, 1);

            Vector3 pos = new Vector2();
            if (player != null)
            {
                pos.x = (player.position.x + player2.position.x) / 2;
                pos.z = (player.position.z + player2.position.z) / 2 - 10;
                pos.y = (player.position.y + player2.position.y) / 2;

                transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime);
            }
        }
    }
}
