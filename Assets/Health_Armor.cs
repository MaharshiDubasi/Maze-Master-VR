using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Armor : MonoBehaviour
{
    public int health;
    public int armor;
    public int damageTaken;

    private Rigidbody rb;
    private Renderer rend;

    //damage done by different weapons
    public int bulletDamage = 20;
    public int swordDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        if (this.tag == "Cube")
        {
            armor = 0;
        }
        else
        {
            armor = 10;
        }

        rb = this.GetComponent<Rigidbody>();
        rend = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnCollisionEnter(Collision collision)
    {

        ////print("Points colliding: " + collision.contacts.Length);
        ////print("First point that collided: " + collision.contacts[0].point);

        //if (health == 0)
        //{
        //    rb.useGravity = false;
        //    rend.material.SetColor("_Color", Color.red);
        //    return;
        //}

        //if(collision.gameObject.tag == "Bullet")
        //{
        //    damageTaken = bulletDamage - armor;
        //    health = health - damageTaken;
        //}

        //if(collision.gameObject.tag == "Sword")
        //{
        //    damageTaken = swordDamage - armor;
        //    health = health - damageTaken;
        //}
    }
}
