using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float t;
    public float secondsBetweenSpawns;

    public GameObject knight;
    public GameObject[] coins;

    public GameObject cam;

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
        int x = Random.Range(-2, 3);
        int y = knight.GetComponent<Knight>().y + Random.Range(10, 16);
        Vector3 pos = new(x * scale, y * scale, -1);

        GameObject coin;

        int r = Random.Range(0, coins.Length);

        coin = Instantiate(coins[r], pos, Quaternion.identity, transform);
        coin.GetComponent<Coin>().x = x;
        coin.GetComponent<Coin>().y = y;
    }
}
