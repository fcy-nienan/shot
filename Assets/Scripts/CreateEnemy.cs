using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject enemy;

    public int speed = 1;

    public int number = 1;

    public float interval = 0.5f;
    public float timer = 0.5f;
    // Start is called before the first frame update

    private bool stop_create = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p"))
        {
            this.stop_create = true;
        }else if (Input.GetKey("o"))
        {
            this.stop_create = false;
        }
        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                timer = 0;
        }
            if (timer == 0)
            {
                timer = interval;
                if (!stop_create)
                {
                    create();
                }
            }
    }

    void create()
    {
        float y_position = Random.Range(-5f, 5f);
        float x_position = Random.Range(5f, 9.5f);
        GameObject bullet = ObjectPool.Instance.GetObject(enemy);
        bullet.transform.position = new Vector2(x_position, y_position);
    }
}
