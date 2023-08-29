using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRigidbody;

    private float minSpeed = 12f, maxSpeed = 16f;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRigidbody = GetComponent<Rigidbody>();

        targetRigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        targetRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // private void OnMouseDown()
    // {
    //     if (gameManager.isGameActive)
    //     {
    //         gameManager.UpdateScore(pointValue);
    //         Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    //         Destroy(gameObject);
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("Good Target"))
        {
            gameManager.LoseLives();
            if (gameManager.lives <= 0)
            {
                gameManager.gameOver();
            }
        }
        Destroy(gameObject);
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position,
                explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
}
