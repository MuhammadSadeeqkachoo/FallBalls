using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateCamera : MonoBehaviour
{
    public float RotateSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.down, Horizontal*RotateSpeed*Time.deltaTime);

        
    }
}
