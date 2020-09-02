using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    // Start is called before the first frame update
    Animation Playanim;
    Animation anim;
    [SerializeField] GameObject AnimObject;
    void Start()
    {
        anim = AnimObject.GetComponent<Animation>();
       Playanim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
            Playanim.Play("Open");
            if(!Playanim.isPlaying)
            {
                anim.Play("TreasureEffect");                                
            }
            
        }
    }
}
