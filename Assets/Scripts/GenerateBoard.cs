using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    public GameObject darkSquarePrefab;
    public GameObject lightSquarePrefab;

    public GameObject knight;
    public GameObject cam;
    public float scale;
    int j = 0;
    float t;
    private void Start()
    {
        t = 0;
        scale = darkSquarePrefab.transform.localScale.x;
        for (float y = -3; y <= 20; y++)
        { 
            for (float x = -2; x <= 2; x++)
            {
                GameObject cell = Instantiate(((x + y) % 2 == 0) ? darkSquarePrefab : lightSquarePrefab, new Vector3(x * scale, y * scale, 0), Quaternion.identity, transform);
                cell.name = x.ToString() + " " + y.ToString();
                cell.GetComponent<Square>().knight = knight;
                cell.GetComponent<Square>().cam = cam;
            }
        }
        j = 21;
    }

    private void Update()
    {
        t += Time.deltaTime;
        if (t >= 0.3f)
        {
            t = 0;
            float y = j;
            for (float x = -2; x <= 2; x++)
            {
                GameObject cell = Instantiate(((x + y) % 2 == 0) ? darkSquarePrefab : lightSquarePrefab, new Vector3(x * scale, y * scale, 0), Quaternion.identity, transform);
                cell.name = x.ToString() + " " + y.ToString();
                cell.GetComponent<Square>().knight = knight;
                cell.GetComponent<Square>().cam = cam;
            }
            
            j++;
        }
    }

}
