using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1weapon : MonoBehaviour
{
    public GameObject player;
    public float weaponCD = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponCD == 0)
        {
            DisableWeapon();
        }

        if (weaponCD > 0)
        {
            weaponCD -= Time.deltaTime;
            if (weaponCD < 0) { weaponCD = 0; }
        }
    }
    void DisableWeapon()
    {
        Destroy(this.gameObject);
    }
    public void EnableWeapon()
    {
        Instantiate(this.gameObject, player.transform.position, player.transform.rotation);
        weaponCD = .2f;
    }
}
