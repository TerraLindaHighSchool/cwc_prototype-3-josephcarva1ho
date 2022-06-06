using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleScript : MonoBehaviour
{

    private PlayerController playerControllerScript;

    public GameObject Title;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Title.SetActive(false);
        }

        if(playerControllerScript.gameOver)
        {
            Title.SetActive(false);
        }
    }
}
