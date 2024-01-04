using UnityEngine;
using UnityEngine.UI;

public class Watcher : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 movementDirection;
    public float distance = 20f;
    private bool _movingDown;
    public Text timer;
    private Zombie[] _zombies;
    private Vector3 _initialPosition;
    private AudioSource _audioSource;

    private void Start()
    {
        _zombies = enemy.GetComponentsInChildren<Zombie>();
        _initialPosition = transform.position;
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_movingDown)
        {
            transform.position += movementDirection;
        }
        else
        {
            transform.position -= movementDirection;
        }

        var newPosition = new Vector3
        {
            x = movementDirection.x > 0 ? _initialPosition.x + distance : 0,
            z = movementDirection.z > 0 ? _initialPosition.z + distance : 0
        };

        if (IsGreaterOrEqual(transform.position, newPosition))
        {
            _movingDown = false;
        }
        else if (IsLesserOrEqual(transform.position, _initialPosition))
        {
            _movingDown = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player")
        {
            return;
        }
        
        _audioSource.Play();

        foreach (var zombie in _zombies)
        {
            zombie.GetComponent<Zombie>().Reset();
        }

        timer.enabled = true;
        timer.GetComponent<Timer>().Reset();
    }

    private static bool IsGreaterOrEqual(Vector3 local, Vector3 other)
    {
        return (local.x >= other.x && local.z >= other.z);
    }

    private static bool IsLesserOrEqual(Vector3 local, Vector3 other)
    {
        return (local.x <= other.x && local.z <= other.z);
    }
}