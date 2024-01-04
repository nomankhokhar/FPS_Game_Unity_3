using UnityEngine;

public class PlayFootstepSound : MonoBehaviour
{
    public float soundSpeedOnRunning = 1.2f;
    private const float DEFAULT_SPEED = 1.0f;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool isMoving = (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0);
        bool isJumping = Input.GetButton("Jump");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isMoving && !isJumping && !audioSource.isPlaying)
        {
            audioSource.pitch = isRunning ? soundSpeedOnRunning : DEFAULT_SPEED;
            audioSource.Play();
        }

        if (!isMoving)
        {
            audioSource.Stop();
        }
    }
}