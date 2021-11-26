using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private float speed = 20.0f;
    private PlayerController playerController;
    private GameManager gameManager;
    public int pointValueLow;
    public int pointValueHigh;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.hasPowerup == true)
        {
            speed = 60.0f;
        }
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if(transform.position.z > 11)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyLowTag"))
        {
            EnemyLow scriptEnemyLow = other.gameObject.GetComponent<EnemyLow>();
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.UpdateScore(scriptEnemyLow.score);
        }
        if (other.gameObject.CompareTag("EnemyHighTag"))
        {
            EnemyHigh scriptEnemyHigh = other.gameObject.GetComponent<EnemyHigh>();
            Destroy(gameObject);
            scriptEnemyHigh.health--;
            if (scriptEnemyHigh.health == 0)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                gameManager.UpdateScore(scriptEnemyHigh.score);
            }
        }
    }
}
