using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class StartScreen : MonoBehaviour
{
    

    
    // Start is called before the first frame update
    [SerializeField] Button StartGame;
    [SerializeField] Button Exit;

    
    void Start()
    {
        StartGame.onClick.AddListener(LoadLevel1);
        Exit.onClick.AddListener(Quit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void LoadLevel1()
    {
        
        SceneManager.LoadScene("Level 1");

        
    }

    void Quit()
    {
        Application.Quit();
        
    }
}
