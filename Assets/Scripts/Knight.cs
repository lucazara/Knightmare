using UnityEngine;
using UnityEngine.SceneManagement;

public class Knight : MonoBehaviour
{

    public int x;
    public int y;

    public float scale = 0.8f;

    public float t;

    private Vector3 targetPosition;

    public GameObject cam;
    public GameObject spawner;


    void Start()
    {
        targetPosition = transform.position;
        x = 0;
        y = -3;

        t = 0;
    }

    void Update()
    {
        t += Time.deltaTime;

        if (t > 0.01f)
        {
            transform.position += (targetPosition - transform.position) * 0.2f;
            t = 0;
        }

        CheckTriggered();
    }

    public void MoveTo(int cx, int cy)
    {
        if (!cam.GetComponent<CameraMovement>().started) return;

        int dx = Mathf.Abs(x - cx);
        int dy = Mathf.Abs(y - cy);

        if (dx == 2 && dy == 1 || dx == 1 && dy == 2)
        {
            x = cx;
            y = cy;
            UpdatePosition();
        }

        
    }

    private void UpdatePosition()
    {
        targetPosition = new Vector3(x * scale, y * scale, -1);
    }


    private void CheckTriggered()
    {
        for (int i = 0; i < spawner.transform.childCount; i++)
        {
            GameObject enemy = spawner.transform.GetChild(i).gameObject;
            Enemy e = enemy.GetComponent<Enemy>();


            //TODO: check for forks
            if (!e.triggered)

            {
                switch (e.type)
                {
                    case "rook":
                        if (e.x == x)
                        {
                            e.triggered = true;
                            e.direction = Vector3.up * ((y > e.y) ? 1 : -1);
                        }
                        if (e.y == y)
                        {
                            e.triggered = true;
                            e.direction = Vector3.right * ((x > e.x) ? 1 : -1);
                        }

                        break;
                    case "bishop":

                        if (e.x + e.y == x + y)
                        {
                            e.triggered = true;
                            e.direction = (Vector3.up + Vector3.left).normalized * ((y > e.y) ? 1 : -1);
                        }
                        if (e.x - e.y == x - y)
                        {
                            e.triggered = true;
                            e.direction = (Vector3.up + Vector3.right).normalized * ((y > e.y) ? 1 : -1);
                        }


                        break;
                    case "queen":
                        break;
                }
            }

            if (Vector3.Distance(transform.position, enemy.transform.position) < 0.5 || Vector2.Distance(transform.position, cam.transform.position) > 6)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(0);
            }
        }
    }
}
