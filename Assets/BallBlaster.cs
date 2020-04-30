using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBlaster : MonoBehaviour
{
    public GameObject ball;
    private float ballSpawnTime = 0.2f;
    private float ballForce = 50.0f;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BlastBalls(ballSpawnTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BlastBalls(float waitTime)
    {
        while (true)
        {
            bullet = Instantiate(ball, this.transform.position, this.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(ballForce, 0, ballForce);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
