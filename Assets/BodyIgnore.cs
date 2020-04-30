using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyIgnore : MonoBehaviour
{
    public GameObject playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player Collider");
        Physics.IgnoreCollision(this.GetComponent<Collider>(), playerCollider.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
