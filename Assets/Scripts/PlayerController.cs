using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;

    // Private Vars
    private float velocidad = 10.0f;
    private float turnSpeed = 75.0f;
    private float horizontalInput;
    private float forwardInput;

    public bool canJump;
    private float xRange = 9.0f;

    public AudioClip jumpSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // There is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // We'll move the traceur forward
        transform.Translate(Vector3.forward * Time.deltaTime * velocidad * forwardInput);

        // We'll move the traceur right, in X
        transform.Translate(Vector3.right * Time.deltaTime * velocidad * horizontalInput);

        // We turn the traceur
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        // Traceur jump the obstacles        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * upForce, ForceMode.Impulse);
            canJump = false;
        }
        else if (!canJump && Physics.Raycast(transform.position, -Vector3.up, 0.1f))
        {
            canJump = true;
        }

        // Traceur limited move in X
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Assing song to jump traceur
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Reproduce el sonido de salto
        audioSource.PlayOneShot(jumpSound);
    }
}
