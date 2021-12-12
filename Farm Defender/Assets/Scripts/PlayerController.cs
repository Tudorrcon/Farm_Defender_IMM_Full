using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioClip shootingSoundTap;
    public GameObject projectile;
    public GameObject powerupIndicator;

    private float speed = 10.0f;
    public bool hasPowerup = false;

    private float ZLimit = 8.5f;
    private float XLimit = 15.3f;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);


        if (transform.position.z < -ZLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -ZLimit);
        }

        if (transform.position.z > ZLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ZLimit);
        }

        if (transform.position.x < -XLimit)
        {
            transform.position = new Vector3(-XLimit, transform.position.y, transform.position.z);
        }

        if (transform.position.x > XLimit)
        {
            transform.position = new Vector3(XLimit, transform.position.y, transform.position.z);
        }



        if (Input.GetKeyDown(KeyCode.Space) && hasPowerup == false)
        {
            //Launch a projectile from the player.
            Instantiate(projectile, new Vector3(transform.position.x,1.85f,transform.position.z + 2), projectile.transform.rotation);
            playerAudio.loop = false;
            playerAudio.clip = shootingSoundTap;
            playerAudio.volume = 0.08f;
            playerAudio.Play();
        }

        if (Input.GetKey(KeyCode.Space) && hasPowerup)
        {
            //Launch a line of projectiles from the player.
            Instantiate(projectile, new Vector3(transform.position.x, 1.85f, transform.position.z), projectile.transform.rotation);
            playerAudio.loop = true;
            playerAudio.clip = shootingSoundTap;
            playerAudio.volume = 0.05f;
            playerAudio.Play();
        }

        powerupIndicator.transform.position = transform.position + new Vector3(0, 1, 0);
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUpTag"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
        }
    }
}