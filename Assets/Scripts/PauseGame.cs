using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    Button Pause;
    void Start()
    {
        Pause.onClick.AddListener(PauseButton);

        Pause = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PauseButton ()
    {
        Time.timeScale = 0;
    }

}
