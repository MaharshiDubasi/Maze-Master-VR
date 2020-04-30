using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareTargetMove : MonoBehaviour
{
    public bool backward;

    private float move = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        backward = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (backward == false)
        {
            Vector3 tempPos = this.transform.position;
            tempPos.x += move * Time.deltaTime;

            this.transform.position = tempPos;
        }
        else
        {
            Vector3 tempPos = this.transform.position;
            tempPos.x -= move * Time.deltaTime;

            this.transform.position = tempPos;
        }

        if (this.transform.localPosition.x > 3.7)
        {
            backward = true;
        }
        
        if (this.transform.localPosition.x < -4)
        {
            backward = false;
        }
    }
}
