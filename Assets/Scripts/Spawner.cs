using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float t;
    public float secondsBetweenSpawns;

    public GameObject knight;
    public GameObject[] pieces;


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
                secondsBetweenSpawns *= 0.95f;
            }
        }

        

    }

    private void Spawn()
    {
        int x = Random.Range(-2, 3);
        int y = knight.GetComponent<Knight>().y + Random.Range(4, 7);
        Vector3 pos = new(x * scale, y * scale, -1);

        GameObject enemy;

        int r = Random.Range(0, pieces.Length);

        enemy = Instantiate(pieces[r], pos, Quaternion.identity, transform);
        enemy.GetComponent<Enemy>().x = x;
        enemy.GetComponent<Enemy>().y = y;
    }
}
