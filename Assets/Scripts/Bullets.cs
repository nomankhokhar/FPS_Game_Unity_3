using UnityEngine;

public class Bullets : MonoBehaviour
{
    public Transform shapePrefab;  // Drag your shape prefab into this field in the Unity Editor
    public float shootingSpeed = 10f;

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Call the Shoot() method when the left mouse button is clicked
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a new shape at the current position of the ShootingSystem object
        Transform newShape = Instantiate(shapePrefab, transform.position, Quaternion.identity);

        // Access the Rigidbody component of the new shape
        Rigidbody2D shapeRb = newShape.GetComponent<Rigidbody2D>();

        // Move the shape forward in the Z direction (the direction the ShootingSystem is facing)
        shapeRb.velocity = transform.forward * shootingSpeed;
    }
}
