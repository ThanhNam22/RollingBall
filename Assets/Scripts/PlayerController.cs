using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float initialSpeed = 0f;
    public float maxSpeed = 13f;
    public float jumpForce = 5.0f;
    public float acceleration = 3f;
    public float groundCheckDistance = 0.2f;
    private bool isGrounded;
    private bool wasGrounded;
    private bool isMoving;
    private bool isStarted = false;
    public GameController gameController;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void Update()
    {
        if (!isStarted)
            return;

        CheckGroundStatus();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        isMoving = moveHorizontal != 0 || moveVertical != 0;
    }

    private void FixedUpdate()
    {
        if (!isStarted)
            return;

        if (isMoving)
        {
            initialSpeed += acceleration * Time.fixedDeltaTime;
            initialSpeed = Mathf.Clamp(initialSpeed, 0, maxSpeed);

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
            if (!isGrounded)
            {
                rb.AddForce(movement * (initialSpeed - 5f));
            }
            else
            {
                rb.AddForce(movement * initialSpeed);

            }
        }
        else
        {
            initialSpeed = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Watter"))
        {
            audioManager.PlaySFX(audioManager.loseClip);
            gameController.GameOver("GAME OVER");
        }
        if (other.CompareTag("Finish"))
        {
            audioManager.PlaySFX(audioManager.winClip);
            gameController.GameOver("YOU WIN!!!");
        }
    }
    void CheckGroundStatus()
    {
        wasGrounded = isGrounded; // Save the previous grounded state

        if (Physics.Raycast(transform.position, Vector3.down, groundCheckDistance))
        {
            isGrounded = true;

            // Play ballClip only if transitioning from air to ground
            if (!wasGrounded)
            {
                audioManager.PlaySFX(audioManager.ballClip);
            }
        }
        else
        {
            isGrounded = false;
        }
    }

    public void StartMoving()
    {
        isStarted = true;
        rb.useGravity = true;
    }
}
