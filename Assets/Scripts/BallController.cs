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
    
    [Range(0f,10f)] [SerializeField]  public float force = 1f;
    [Range(0f,10f)] [SerializeField]   public float jumpforce = 8f;
     bool onGround = true;
     bool walljump;

     TextMeshProUGUI Lives;
    

    int livecount = 3;
    //[SerializeField] AudioClip coinsound;
    
     // Start is called before the first frame update
     Rigidbody PlayerRb;
     
    void Start()
    {
        
        //Lives = GameObject.Find("GameUi").GetComponentInChildren<TextMeshProUGUI>();
        PlayerRb = GetComponent<Rigidbody>();
        




    }
    
  
    
    


    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        MoveBall();
        jump();
        if (transform.position.y < 0)
        {
          die();
            
        }
       
    }

    void die()
    {
        
        livecount--;

        transform.position = new Vector3(30.9599991f, 1.75f, 4.0999999f);
        Lives.text = "Lives: " + livecount;
        if (livecount == 0)
        {
            int LevelNumber = SceneManager.GetActiveScene().buildIndex;

            
        
            SceneManager.LoadScene(LevelNumber);
        }
    }
   
    void OnCollisionEnter(Collision collision) {
        //checks if collider is tagged "ground"
        if(collision.gameObject.CompareTag("jumpable")){
            
            //if the collider is tagged "ground", sets onGround boolean to true
            onGround = true;
        }

        
        
        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("LevelHazard"))
        {
            die();
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

        
        float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.UpArrow))
            {
                PlayerRb.AddForce(Vector3.forward*Time.deltaTime);
                
                
            }
            
            Vector3 movement = new Vector3 (moveVertical, 0.0f,-moveHorizontal);
            PlayerRb.AddForce(movement * force);
        
    }
}
