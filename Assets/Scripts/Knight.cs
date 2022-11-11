using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{

    public int x;
    public int y;

    public float scale = 0.8f;

    public float t;

    private Vector3 targetPosition;

    public GameObject cam;


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
    }

    public void MoveTo(int cx, int cy)
    {
        if (!cam.GetComponent<CameraMovement>().started) return;

        Debug.Log("HIT!");
        Debug.Log(cx.ToString() + " " + cy.ToString());

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
}
