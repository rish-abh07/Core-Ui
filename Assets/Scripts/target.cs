using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameM;
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float minTorque = -10.0f;
    private float maxTorque = 10.0f;
    private float xRange = 4.0f;
    public int pointValue;
    public ParticleSystem explosionParticle;
 
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameM = GameObject.Find("GameM").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = SpawnPos();

    }
    private void OnMouseDown()
    {
       
       if(gameM.IsGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameM.updateScore(pointValue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            gameM.GameOver();
        }
        Destroy(other.gameObject);
    }
    Vector3 RandomForce()
    {
       return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
     float RandomTorque()
    {
        return  Random.Range(minTorque, maxTorque);
    }
     Vector3 SpawnPos()
    {
        return  new Vector3(Random.Range(-xRange, xRange), -6);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
