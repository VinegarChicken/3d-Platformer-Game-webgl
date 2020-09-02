using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{

    [Header("Object you don't want to destroy on load")]
    public GameObject _GameObject;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(_GameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
