using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    public GameObject darkSquarePrefab;
    public GameObject lightSquarePrefab;

    public GameObject knight;
    private void Start()
    {
        float scale = darkSquarePrefab.transform.localScale.x;
        for (float y = -3; y <= 400; y++)
        { 
            for (float x = -2; x <= 2; x++)
            {
                GameObject cell = Instantiate(((x + y) % 2 == 0) ? darkSquarePrefab : lightSquarePrefab, new Vector3(x * scale, y * scale, 0), Quaternion.identity, transform);
                cell.name = x.ToString() + " " + y.ToString();
                cell.GetComponent<Square>().knight = knight;
            }
        }
    }

}
