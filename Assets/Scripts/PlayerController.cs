using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Egg Projectile
    public GameObject eggPrefab;
    private float eggCd = 0.4f;
    private float eggSpawn = 0.0f;

    // Controls X + Z Movement
    public float speed = 5.0f;
    private Vector3 shootDirection = Vector3.forward; // Default shoot direction

    void Update()
    {
        // Movement Code
        float speedX = Input.GetAxis("Horizontal");
        float speedZ = Input.GetAxis("Vertical");

        // Update shoot direction based on user input, but only if there is input
        if (speedX != 0 || speedZ != 0)
        {
            shootDirection = new Vector3(speedX, 0, speedZ).normalized;
        }

        // Move the player based on input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * speedZ);
        transform.Translate(Vector3.right * Time.deltaTime * speed * speedX);

        // Projectile Code
        eggSpawn += Time.deltaTime;

        if (eggSpawn >= eggCd)
        {
            // Instantiate the egg at the player's position and set its rotation based on shoot direction
            GameObject egg = Instantiate(eggPrefab, transform.position, Quaternion.LookRotation(shootDirection));

            // Reset the spawn time after spawning
            eggSpawn = 0.0f;
        }
    }
}
