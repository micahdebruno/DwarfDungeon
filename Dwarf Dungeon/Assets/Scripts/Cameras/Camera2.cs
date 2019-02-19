using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public GameObject player, otherPlayer;
    public float smoothTime = 0.3f;
    public Camera cam;
    [SerializeField]
    private float splitScreenDist;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        if (Vector2.Distance(player.transform.position, otherPlayer.transform.position) > splitScreenDist)
        {
            cam.enabled = true;
            Vector3 pos = new Vector2();
            if (player != null)
            {
                pos.x = player.transform.position.x;
                pos.z = player.transform.position.z - 10;
                pos.y = player.transform.position.y;

                transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime);
            }
        }
        else
        {
            cam.enabled = false;

        }
    }
}
