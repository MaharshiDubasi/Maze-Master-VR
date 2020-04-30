using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rollerSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator rollerSpawn()
    {
        while(true)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = this.transform.position;
            sphere.transform.localScale = new Vector3(4.0f, 4.0f, 4.0f);
            sphere.AddComponent<Rigidbody>();
            sphere.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -9.0f);
            sphere.GetComponent<Rigidbody>().mass = 500f;
            sphere.AddComponent<DestroyLimitY>();
            sphere.GetComponent<DestroyLimitY>().YValue = -4;

            yield return new WaitForSeconds(4.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
