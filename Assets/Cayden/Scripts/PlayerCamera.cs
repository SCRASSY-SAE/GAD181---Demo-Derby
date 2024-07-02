using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject target;
    public float height;
    public float distance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = transform.position - target.transform.position;
        offset.y = 0;

        //if(offset.magnitude != distance)
        {
            offset = offset.normalized * distance;
            offset.y = height;

            transform.position = target.transform.position + offset;
            transform.LookAt(target.transform.position);
        }
    }
}
