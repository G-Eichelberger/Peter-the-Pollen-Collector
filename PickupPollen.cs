using UnityEngine;

public class PickupPollen : MonoBehaviour
{
    private GameManager gameManager;
    private bool didCountPickup = false;

    private void Start()
    {
        // Finds the GameManager attached to Canvas
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !didCountPickup)
        {
            didCountPickup = true;
            gameManager.numberOfPollen++; // Count pollen instead of keys
            Destroy(gameObject); // Removs the pollen after collecting it
        }
    }
}

