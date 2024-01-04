using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    public GameObject player;
    public float activeTimeInSeconds = 10;
    public GameObject uiPanel;
    private NavMeshAgent _navMesh;
    private Animator _animator;
    private bool _isRunning;
    private float _activeTime;

    public float health = 100;

    public void Reset()
    {
        _activeTime = activeTimeInSeconds;
    }

    private void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (_activeTime <= 0)
        {
            Stop();
            return;
        }

        if (_isRunning)
        {
            _navMesh.destination = player.transform.position;
            _activeTime -= Time.deltaTime;
            return;
        }

        _isRunning = true;
        _animator.Play("zombie_running");
    }

    private void Stop()
    {
        _activeTime = 0;
        _isRunning = false;
        _animator.Play("zombie_idle");
        _navMesh.destination = this.transform.position;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player")
        {
            return;
        }

        uiPanel.SetActive(true);
        StartCoroutine(RestartScene());
    }

    private static IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3f);
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }
    }
}
