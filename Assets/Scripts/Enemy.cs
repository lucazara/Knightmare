using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool triggered;

    public Vector3 direction;
    public float speed;
    public float acceleration;

    public float lifeTime;

    public string type;

    public int x, y;
    public float t;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (triggered)
        {
            GetComponent<SpriteRenderer>().color = Color.red;

            transform.position += speed * Time.deltaTime * direction;

            switch (type)
            {
                case "rook":

                    

                    break;
                case "queen":
                    break;
                case "bishop":
                    break;
            }

            t += Time.deltaTime;
            if (t > lifeTime) Destroy(gameObject); 
        }
    }


}
