using UnityEngine;

public class Spinning : MonoBehaviour
{
    public float rotateSpeed;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        this.transform.Rotate(new Vector3(0,rotateSpeed, 0));
    }
}
