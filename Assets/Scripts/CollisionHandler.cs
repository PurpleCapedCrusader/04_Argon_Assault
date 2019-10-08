using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;

    // Start is called before the first frame update
    void Start()
    {
        // deathFX = GameObject.Find("/MainCamera/PlayerShip/Explosion");
    }

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }
    private void StartDeathSequence()
    {
        print("CollisionHandler.StartDeathSequence");
        deathFX.SetActive(true);
        SendMessage("OnPlayerDeath");
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    private void LoadFirstLevel() // string referenced
    {
        SceneManager.LoadScene(1);
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}