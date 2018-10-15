using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public static BallSpawner current;

    public GameObject pooledBall; //the prefab of the object in the object pool
    public int ballsAmount = 80; //the number of objects you want in the object pool
    public List<GameObject> pooledBalls; //the object pool
    public static int ballPoolNum = 0; //a number used to cycle through the pooled objects

    private float cooldown;
    private float cooldownLength = 0.5f;

    void Awake()
    {
        current = this; //makes it so the functions in ObjectPool can be accessed easily anywhere
    }

    void Start()
    {
        //Create Bullet Pool
        pooledBalls = new List<GameObject>();
        for (int i = 0; i < ballsAmount; i++)
        {
            GameObject obj = Instantiate(pooledBall);
            obj.SetActive(false);
            pooledBalls.Add(obj);
        }
    }
    //Get one ball from the object pool
    public GameObject GetPooledBall()
    {
        for (int i = 0; i < pooledBalls.Count; i++)
        {
            if (!pooledBalls[i].activeInHierarchy)
            {
                return pooledBalls[i];
            }
        }

    //create a new bullet and add it to the bulletList
    GameObject obj = Instantiate(pooledBall);
    pooledBalls.Add(obj);
    ballsAmount++;
    return obj;
    }
   	
	// Update is called once per frame
	void Update () {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            cooldown = cooldownLength;
            SpawnBall(); // Spawns ball every "cooldownLength" seconds
        }		
	}

    void SpawnBall()
    {
        GameObject selectedBall = BallSpawner.current.GetPooledBall();
        selectedBall.transform.position = transform.position;
        Rigidbody selectedRigidbody = selectedBall.GetComponent<Rigidbody>();
        selectedRigidbody.velocity = Vector3.zero;
        selectedRigidbody.angularVelocity = Vector3.zero;
        selectedBall.SetActive(true);
    }
}
