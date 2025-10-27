using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float playerSpeed = 2f;
    public ParticleSystem gustParticle;
    float moveHorizontal, moveVertical;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        //get inputs
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector2(moveHorizontal * playerSpeed, moveVertical * playerSpeed);

    }
    void Flap()
    {
        gustParticle.Play();
    }
}
