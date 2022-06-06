using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
    
{

    public PlayerController playerController;

    private TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver)
        {
            timer.text = "" + Mathf.Floor(Time.realtimeSinceStartup);
        }
        else
        {
            timer.enabled = false;
        }

    }
}
