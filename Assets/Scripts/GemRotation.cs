using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRotation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float rotationspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }
    void Spin()
    {
        
        float RotationSpeed = rotationspeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * RotationSpeed);
        transform.Rotate(Vector3.left * RotationSpeed);

        
    }
}
