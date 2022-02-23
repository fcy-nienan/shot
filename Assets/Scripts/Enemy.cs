using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0.1f;

    public GameObject player;
    void Start()
    {
        Debug.Log("1生成了一个敌人");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        //物体朝向木一个点移动
        this.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z), step);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("敌人被撞击");
        Debug.Log(other.gameObject.name);
        Debug.Log(other.gameObject.CompareTag("子弹"));
        if (other.gameObject.CompareTag("子弹"))//被子弹射击
        {
            ObjectPool.Instance.PushObject(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("撞击到了东西");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")//如果撞击到了主角，主角扣血
        {
            Debug.Log("主角扣血");
        }
        else
        {
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("持续撞击");
        if (collision.gameObject.name == "Player")//如果撞击到了主角，主角扣血
        {
            Debug.Log("主角扣血");
        }
    }
}
