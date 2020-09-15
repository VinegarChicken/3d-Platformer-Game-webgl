using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Rendering;

public class BallController : MonoBehaviour
{
    
    [Range(0f,10f)]   public float force = 1f;
    [Range(0f,10f)]    public float jumpforce = 8f;
    [SerializeField] ParticleSystem DeathExplosion;
     bool onGround = true;
     bool walljump;
    
     TextMeshProUGUI Lives;
     public enum Status
     {
         Alive, Dead, LevelComplete
     }

     private int particlecount;
    int livecount = 3;
    //[SerializeField] AudioClip coinsound;
    
     // Start is called before the first frame update
     Rigidbody PlayerRb;
     private Status _status = Status.Alive;
    void Start()
    {
        
        Lives = GameObject.Find("GameUi").GetComponentInChildren<TextMeshProUGUI>();
        PlayerRb = GetComponent<Rigidbody>();
        




    }
    
  
    
    


    void Update()
    {
        
        //DeathExplosion.transform.position = transform.position;
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        MoveBall();
        jump();
        if (transform.position.y < 0)
        {
            
            _status = Status.Dead;
            Invoke(nameof(die), 1f);
            
        }
        ParticleManager();
       
    }


    void die()
    {
        
        livecount--;
        /*
        transform.position = new Vector3(30.9599991f, 1.75f, 4.0999999f);
        */
        
        
            
            Lives.text = "Lives: " + livecount;
            
            Destroy(GameObject.Find("Ball"));
                int LevelNumber = SceneManager.GetActiveScene().buildIndex;

            
        
                SceneManager.LoadScene(LevelNumber);
            
        
        
    }

    void ParticleManager()
    {
        if (_status == Status.Dead)
        {
            if (!DeathExplosion.isPlaying)
            {
                DeathExplosion.Play();
            }
            
        }
        else
        {
            DeathExplosion.Stop();
        }
    }
    void OnCollisionEnter(Collision collision) {
        
        switch (collision.gameObject.tag)
        {
                
            case "jumpable":
                
                onGround = true;
                break;
            
            case "enemy":
                _status = Status.Dead;
                
                Invoke(nameof(die),1f);
                break;
            
            case "LevelHazard":
                _status = Status.Dead;
                Invoke(nameof(die),1f);
                break;
            

        }
        
  
        

    }
    
  


    void jump()
    {
        if (Input.GetButton("Jump") && onGround) {
            //adds force to player on the y axis by using the flaot set for the variable jumpForce. Causes the player to jump
            PlayerRb.velocity = new Vector3( 0f, jumpforce, 0f);
            onGround = false;
            
        }
   
    }

    
    void MoveBall()
    {

        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (moveVertical*force, 0.0f,-moveHorizontal*force);
            PlayerRb.AddForce(movement * force);
        */
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.B))
            {
                force = 2f;
            }
            else
            {
                force = 1f;
            }
            PlayerRb.AddForce(Vector3.back*force);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.B))
            {
                force = 2f;
            }
            else
            {
                force = 1f;
            }
            PlayerRb.AddForce(Vector3.forward*force);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.B))
            {
                force = 2f;
            }
            else
            {
                force = 1f;
            }
            PlayerRb.AddForce(Vector3.right*force);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.B))
            {
                force = 2f;
            }
            else
            {
                force = 1f;
            }
            PlayerRb.AddForce(Vector3.left*force);
        }
    }
}
