using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float t;
    public float secondsBetweenSpawns;

    public GameObject knight;
    public GameObject[] pieces;


    public GameObject cam;
    public GameObject coinSpawner;

    public float scale;

    private void Start()
    {
        t = 0;
        
    }

    private void Update()
    {
        
        if (cam.GetComponent<CameraMovement>().started)
        {
            t += Time.deltaTime;

            if (t > secondsBetweenSpawns)
            {
                Spawn();
                t = 0;
                secondsBetweenSpawns *= 0.98f;
            }
        }

        

    }

    private void Spawn()
    {
        int x, y;
        do
        {
            x = Random.Range(-2, 3);
            y = knight.GetComponent<Knight>().y + Random.Range(6, 8);
        } while (!GoodPosition(x, y));

        int j = 0;
        float r = Random.Range(0f, 1f);
        float s = 0;
        for (int i = 0; i < pieces.Length; i++)
        {
            s += pieces[i].GetComponent<Enemy>().freq;
            if (r <= s)
            {
                j = i;
                break;
            }
        }
        Vector3 pos = new(x * scale, y * scale, -1);
        GameObject enemy = Instantiate(pieces[j], pos, Quaternion.identity, transform);
        enemy.GetComponent<Enemy>().x = x;
        enemy.GetComponent<Enemy>().y = y;
    }


    private bool GoodPosition(int x, int y)
    {

        if (x == knight.GetComponent<Knight>().x) return false;

        for (int i = 0; i < transform.childCount; i++)
        {
            Enemy e = transform.GetChild(i).gameObject.GetComponent<Enemy>();
            if (Vector2.Distance(new Vector2(x, y), new Vector2(e.x, e.y)) < 1.5f) return false;
        }

        for (int i = 0; i < coinSpawner.transform.childCount; i++)
        {
            Coin c = coinSpawner.transform.GetChild(i).gameObject.GetComponent<Coin>();
            if (c.x == x && c.y == y) return false;
        }

        return true;
    }
}
