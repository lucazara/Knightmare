using UnityEngine;

public class Square : MonoBehaviour
{
    int x, y;

    private Collider2D col;

    public GameObject knight;
    public GameObject cam;

    void Start()
    {
        char[] sep = new char[]{ ' ' };
        string[] s = name.Split(sep);

        x = int.Parse(s[0]);
        y = int.Parse(s[1]);

        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        CheckForTouch();
        if (cam.transform.position.y > y * 0.8f + 10) Destroy(gameObject);
    }

    bool CheckForTouch()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            var touchPosition = new Vector2(wp.x, wp.y);

            if (col == Physics2D.OverlapPoint(touchPosition))
            { 

                knight.GetComponent<Knight>().MoveTo(x, y);
            }
        }
        return false;
    }

}
