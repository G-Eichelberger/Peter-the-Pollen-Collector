using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float playerSpeed = 2f;
    public float forceMagnitude = 1f;
    private float tiltMag = 0f;
    public ParticleSystem gustParticle;
    float moveHorizontal, moveVertical;
    bool mousePressed = false;
    bool flip = false;
    public static int jarFill = 7;
    public static float jarTime = 0f;
    private AudioSource audioSource;
    public AudioClip clip;
    public ParticleSystem ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        NiceJar();
        Inputs();
        FlipCharacter();
        CharacterTilt();
    }

    void FixedUpdate()
    { }

    void Inputs()
    {
        //get inputs
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveHorizontal = 1f;
            flip = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            moveHorizontal = -1f;
            flip = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerSpeed = 5f;
        }
        else
        {
            playerSpeed = 2f;
        }
        mousePressed = Input.GetMouseButton(0);

        rb.linearVelocity = new Vector2(moveHorizontal * playerSpeed, rb.linearVelocity.y);
    }

    void FlipCharacter()
    {
        Vector3 currentScale = transform.localScale;
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentScale.x = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentScale.x = -1;
        }
        transform.localScale = currentScale;
    }
    
    void CharacterTilt()
    {
        if (mousePressed && jarFill > 0)
        {
            transform.Rotate(new Vector3(0, 0, 270 * transform.localScale.x) * Time.deltaTime);
            rb.AddForce(Vector2.up * forceMagnitude, ForceMode2D.Impulse);
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -90 * transform.localScale.x) * Time.deltaTime);
        }

        //if (transform.eulerAngles.z > 45f && transform.eulerAngles.z < 50f)
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 45);
        //}
        //if(transform.eulerAngles.z < 315f && transform.eulerAngles.z > 310f)
        //{
        //    transform.eulerAngles = new Vector3(0, 0, -45f);
        //}
        
        if(rb.linearVelocity.y > 3f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 3f, 0f);
        }
    }
    void Flap()
    {
        gustParticle.Play();
    }

    void NiceJar()
    {
        jarTime += Time.deltaTime;

        if(jarTime > 1.4f && jarFill > 0)
        {
            jarFill -= 1;
            jarTime = 0f;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pollen"))
        {
            ps.Play();
            audioSource.PlayOneShot(clip);
        }
    }
}
