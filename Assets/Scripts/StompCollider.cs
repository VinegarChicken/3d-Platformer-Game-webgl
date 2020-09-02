using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class StompCollider : MonoBehaviour
{
    
    // Start is called before the first frame update
    Animation controller;
    float timer = 0f;
    float waittime = 2.0f;
    
    void Start()
    {
        if (GameObject.FindWithTag("enemy").GetComponent<Animation>())
        {
            controller = GameObject.FindWithTag("enemy").GetComponent<Animation>();
            print("Component found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        
       

        if (collision.gameObject.CompareTag("Player"))
        {
            
            controller.Play("Die");
            if (!controller.isPlaying)
            {
                Destroy(GameObject.Find("Slime"));
                print("Animation complete.");
            }
            
            
        }
            
            
        
        
            

            
        }
        
        
    }

