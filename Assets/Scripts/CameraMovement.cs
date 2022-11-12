using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float initialSpeed;
    public float maxSpeed;
    public float incrementSpeed;
    public float speed;

    public bool started;

    public GameObject button;


    private void Start()
    { 
        started = false;
    }


    void Update()
    {
        if (started)
        {
            transform.position += speed * Time.deltaTime * Vector3.up;
            speed += incrementSpeed * Time.deltaTime;
            speed = Mathf.Min(speed, maxSpeed);

        }
    }

    public void Started()
    {
        started = true;
        speed = initialSpeed;
        button.SetActive(false);
    }
}
