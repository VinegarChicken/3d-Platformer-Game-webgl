using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumebar : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource Volume;
    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        Volume =  GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        
        //DontDestroyOnLoad(GameObject.Find("VolumeBar"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        Volume.volume = slider.value;
    }
}
