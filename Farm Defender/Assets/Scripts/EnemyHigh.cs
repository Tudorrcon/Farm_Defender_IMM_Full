using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHigh : MonoBehaviour
{
    public int health = 2;
    public int score = 10;
    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
