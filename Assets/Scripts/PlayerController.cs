using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    public MoveLeft MoveLeft;
    
    public TimerScript Timer;
    
    private Rigidbody playerRb;
    
    public float jumpForce;
    
    public float gravityModifier;
    
    public bool isOnGround = true;
    
    public bool gameOver;
    
    private Animator playerAnim;
    
    public ParticleSystem explosionParticle;
    
    public ParticleSystem dirtParticle;
    
    public AudioClip jumpSound;
    
    public AudioClip crashSound;
    
    private AudioSource playerAudio;
    
    public GameObject GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        dirtParticle.Play();
        GameOverCanvas.SetActive(false);

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 10f);
            dirtParticle.Stop();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 10f);


        }

        if (gameOver)
        {
            GameOverCanvas.SetActive(true);
            
            MoveLeft.speed = 0;
            
            gameObject.SetActive(false);
        }
    }
}

