using UnityEngine;
using UnityEngine.UI;

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
    public AudioClip collectClip;
    public AudioClip hurtClip;
    public ParticleSystem ps;
    public ParticleSystem ps2;
    public static Vector3 currentScale;
    public bool damageTaken = false;
    public float health = 3f;
    public Image screenHurt;
    public Image screenDark;
    public GameObject screenUI;
    bool dead = false;
    public GameObject music;
    public GameObject musicf;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        jarFill = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead)
        {
            NiceJar();
            Inputs();
            FlipCharacter();
            CharacterTilt();
            Hurt();
        }
        else
        {
            gameObject.SetActive(false);
            music.SetActive(false);
            musicf.SetActive(true);
            Color currentColor = screenDark.color;
            if(currentColor.a < 1)
            {
                currentColor.a += .75f;
                screenDark.color = currentColor;
            }
            screenUI.SetActive(true);
        }
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
        currentScale = transform.localScale;
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

        rb.angularVelocity = Mathf.Clamp(rb.angularVelocity,-30f,30f);
        
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

        if(jarTime > 2.5f && jarFill > 0)
        {
            jarFill -= 1;
            jarTime = 0f;
        }

    }

    void Hurt()
    {
        if(damageTaken)
        {
            
            audioSource.PlayOneShot(hurtClip);
            Color currentColor = screenHurt.color;
            if(currentColor.a < 1)
            {
                currentColor.a += 1f;
                screenHurt.color = currentColor;
            }
            else
            {
                health -= 1;
                ps2.Play();
                damageTaken = false;
            }
        }
        else
        {
            Color currentColor = screenHurt.color;
            if(currentColor.a > 0 && health > 1)
            {
                currentColor.a -= .005f;
                screenHurt.color = currentColor;
            }
        }

        if(health == 0)
        {
            
            dead = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pollen"))
        {
            ps.Play();
            audioSource.PlayOneShot(collectClip);
        }
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wasp"))
        {
            damageTaken = true;
        }
    }
}
