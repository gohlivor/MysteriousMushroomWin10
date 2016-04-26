using UnityEngine;
using System.Collections;

public class GunTR : MonoBehaviour
{

    public GameObject bulletPrefab;

    // Use this for initialization
    void Start()
    {
        Screen.lockCursor = true;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject clonedBullet;
            clonedBullet = Instantiate(bulletPrefab,
                                    transform.position,
                                    transform.rotation) as GameObject;
            clonedBullet.GetComponent<Rigidbody>().AddForce(clonedBullet.transform.forward * 400);

            GameObject.Destroy(clonedBullet, 5); // Jason: this will destroy the bullet after 5 seconds

        }
    }
}