using UnityEngine;

public class BeeFollow : MonoBehaviour
{
    public Transform beeToFollow;
    private Rigidbody2D rb;
    public float force = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = transform.position - beeToFollow.position;
        rb.AddForce(direction * -force);
        
        rb.linearVelocity = new Vector2(Mathf.Clamp(rb.linearVelocity.x,-10f,10f),Mathf.Clamp(rb.linearVelocity.y,-10f,10f));
    }
}
