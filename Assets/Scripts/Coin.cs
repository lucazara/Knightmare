using UnityEngine;

public class Coin : MonoBehaviour
{ 
    public float rotationSpeed;
    public int x, y;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
}
