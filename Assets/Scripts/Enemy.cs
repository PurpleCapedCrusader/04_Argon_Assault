using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    // Start is called before the first frame update
    void Start()
    {
       Collider enemyShipBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyShipBoxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        print("Particles collided with emeny" + gameObject.name);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
