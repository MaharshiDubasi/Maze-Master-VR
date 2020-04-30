using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyIgnoreChildren : MonoBehaviour
{
    public GameObject body;
    public Collider bodyCollider;
    public Collider[] thisColliders;

    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.FindGameObjectWithTag("Player Collider");
        bodyCollider = body.GetComponent<Collider>();
        thisColliders = this.GetComponentsInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < thisColliders.Length; i++)
        {
            Physics.IgnoreCollision(bodyCollider, thisColliders[i]);
        }
    }
}
