using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaIgnore : MonoBehaviour
{
    private GameObject player;
    private Collider[] playerColliders;
    private Collider[] thisColliders;

    // Start is called before the first frame update
    void Start()
    {
        thisColliders = GetComponentsInChildren<Collider>();
        player = GameObject.FindGameObjectWithTag("Player Collider");
        playerColliders = player.GetComponentsInChildren<Collider>();

        for (int i = 0; i < thisColliders.Length; i++)
        {
            for (int j = 0; j < playerColliders.Length; j++)
            {
                Physics.IgnoreCollision(thisColliders[i], playerColliders[j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
