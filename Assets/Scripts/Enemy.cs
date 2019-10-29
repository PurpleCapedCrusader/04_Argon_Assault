using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       Collider enemyShipBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyShipBoxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        print("Particles collided with emeny" + gameObject.name);
        Destroy(gameObject);
    }
}
