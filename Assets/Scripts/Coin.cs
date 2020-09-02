using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip coinsound;
    [SerializeField] float rotationspeed;
    [Header("If coin script is used for special gem, mark true.")]
    [SerializeField] bool isgem;
    AudioSource coinclip;
    int CoinCount;
    TextMeshProUGUI CoinText;
    
     
    void Start()
    {
        coinclip =  GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(GameObject.Find(gameObject.name));
            //CoinCount++;
            //CoinText.text = "Coins: " + CoinCount;
            coinclip.PlayOneShot(coinsound);
            

        }
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
        if (isgem)
        {
            transform.Rotate(Vector3.left * RotationSpeed);
        }

        
    }

    
   
}
