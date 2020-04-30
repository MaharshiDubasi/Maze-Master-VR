using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ragdoll : MonoBehaviour
{
    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetKinematic(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sword")
        {
            SetKinematic(false);
            GetComponent<Animator>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
