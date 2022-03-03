using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    public GameObject horse;

    public AudioSource playerAudio;
    public AudioClip jumpSound;

    public float speed = 25.0f;
    public float turnSpeed = 10f;
    private float horizontalInput;
    private float forwardInput;
    public float jumpForce = 10f;
    public bool isOnGround = true;
    public float gravityModifier;
    public bool onHorse = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // This is where player get input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // will move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // will turn direction
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);


        }
        horse.transform.position = transform.position;

        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Horse"))
        {
            onHorse = true;
            ScoreScript.scoreValue += 20;

            horse.gameObject.SetActive(true);
            StartCoroutine(HorseRideTimer());

            if (onHorse == true)
            {
                transform.position = transform.position + new Vector3(0, 0.1f, 0);
            }


        }
        

    }

    IEnumerator HorseRideTimer()
    {
        yield return new WaitForSeconds(5);
        onHorse = false;
        horse.gameObject.SetActive(false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
