using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float t;
    public float secondsBetweenSpawns;

    public GameObject knight;
    public GameObject[] coins;

    public GameObject cam;
    public GameObject spawner;

    public GameObject darkCoinLabel;
    public GameObject lightCoinLabel;

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
            y = knight.GetComponent<Knight>().y + Random.Range(10, 16);
        } while (!GoodPosition(x, y));



        int r = Random.Range(0, coins.Length);
        Vector3 pos = new(x * scale, y * scale, -1);
        GameObject coin = Instantiate(coins[r], pos, Quaternion.identity, transform);
        Coin c = coin.GetComponent<Coin>();
        c.x = x;
        c.y = y;
        c.knight = knight;
        c.darkCoinLabel = darkCoinLabel;
        c.lightCoinLabel = lightCoinLabel;

    }

    private bool GoodPosition(int x, int y)
    {
        for (int i = 0; i < spawner.transform.childCount; i++)
        {
            Enemy e = spawner.transform.GetChild(i).gameObject.GetComponent<Enemy>();
            if (Vector2.Distance(new Vector2(x, y), new Vector2(e.x, e.y)) < 1.5f) return false;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Coin c = transform.GetChild(i).gameObject.GetComponent<Coin>();
            if (c.x == x && c.y == y) return false;
        }
        return true;
    }
}
