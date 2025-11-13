using UnityEngine;

public class PickupPollen : MonoBehaviour
{
    private GameManager gameManager;
    private bool didCountPickup = false;
    private bool followPlayer = false;
    public float force = 1f;
    private Rigidbody2D rb;
    public GameObject playerObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void Update()
    {
        Vector3 direction = transform.position - playerObject.transform.position;
        if (followPlayer)
        {
            rb.AddForce(direction * force);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            followPlayer = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            followPlayer = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            GameManager.numberOfPollen++; // Count pollen instead of keys
            Destroy(gameObject); // Removes the pollen after collecting it
        }
    }
}
