using UnityEngine;

public class Collectable : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _pickedUp;
    
    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player" || _pickedUp)
        {
            return;
        }

        _pickedUp = true;

        _audioSource.Play();
        Destroy(gameObject, 0.6f);
    }
}
