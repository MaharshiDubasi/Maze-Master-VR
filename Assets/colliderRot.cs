using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderRot : MonoBehaviour
{
    public GameObject head;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = new Quaternion(0.0f, head.transform.rotation.y, 0.0f, 0.0f);
    }
}
