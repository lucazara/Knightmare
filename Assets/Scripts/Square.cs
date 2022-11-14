using UnityEngine;

public class Square : MonoBehaviour
{
    int x, y;
    float t;

    private Collider2D col;

    public GameObject knight;
    public GameObject cam;


    public Color color;
    void Start()
    {
        char[] sep = new char[]{ ' ' };
        string[] s = name.Split(sep);

        x = int.Parse(s[0]);
        y = int.Parse(s[1]);

        col = GetComponent<Collider2D>();

        color = GetComponent<SpriteRenderer>().color;
        t = 0;
    }

    void Update()
    {
        t += Time.deltaTime;
        CheckForTouch();
        if (cam.transform.position.y > y * 0.8f + 10) Destroy(gameObject);

        if (knight.GetComponent<Knight>().IsReachable(x, y) && y <= 15)
        {
            Color c;
            c = Color.Lerp(color, Color.white, (Mathf.Sin(t * 3f) + 1f) * 0.5f * Mathf.Lerp(1, 0, (float)y * 0.09f));
            GetComponent<SpriteRenderer>().color = c;
            
        }
            
        else
            GetComponent<SpriteRenderer>().color = color;


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
