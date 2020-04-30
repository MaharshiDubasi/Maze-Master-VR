using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringRotation : MonoBehaviour
{
    public GameObject steeringWheel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = new Quaternion(this.transform.rotation.x, -steeringWheel.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
    }
}
