using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    public GameObject myExplosion;
    public GameObject myMushroom;
    void OnCollisionEnter(Collision myCollision) {
        Collider myCollidor = myCollision.collider;
        if (myCollidor.CompareTag("Bullet"))
        {
            print("i hit a bullet");
            GameObject thisExplosion;
            thisExplosion = Instantiate(myExplosion, transform.position, transform.rotation) as GameObject;
            myMushroom.GetComponent<Rigidbody>().isKinematic = false;
            myMushroom.GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
            GameObject.FindGameObjectWithTag("Scoremanager").GetComponent<Scorescript>().Addscore();
            this.gameObject.SetActive(false);
        } 
    
    }
}
