using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;//Singleton Method

    [SerializeField] private TextMeshProUGUI gameOverText;//Game Over Variable
    [SerializeField] private ParticleSystem explosionParticle;//Explosion Particle
    //Foot Dust Particles
    [SerializeField] private ParticleSystem rightFoot;
    [SerializeField] private ParticleSystem leftFoot;

    [SerializeField] private AudioSource music;
    private AudioSource playerJump;

    private Rigidbody playerRb;
    public float gravityModifier = 1.3f;
    public float jumpForce = 8f;
    public bool isOnGround = true;

    //Game Over/end game
    [SerializeField] public bool gameOver = false;

    //Animation
    private Animator playerAnim;

    private void Awake()
    {
        //Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerJump = GetComponent<AudioSource>();
    }

    public void OnJump(InputValue value)
    {
        playerJump.PlayOneShot(playerJump.clip, 1.0f);

        if(value.isPressed && isOnGround)
        {
            //Stop dust particles
            rightFoot.Stop();
            leftFoot.Stop();

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
        }

    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            //Reactivate particles
            rightFoot.Play();
            leftFoot.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            rightFoot.Stop();
            leftFoot.Stop();
            music.Stop();

            gameOver = true;
            gameOverText.gameObject.SetActive(true);
            explosionParticle.Play();
            Destroy(collision.gameObject);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }

    private void FixedUpdate()
    {
        playerRb.AddForce(Vector3.down * (gravityModifier - 1) * Physics.gravity.magnitude, ForceMode.Acceleration);
    }
}
