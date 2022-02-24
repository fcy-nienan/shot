using System;
using System.Collections;
using System.Collections.Generic;
using BulletHell;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0.5f;
    public GameObject bloodPrefab;
    public GameObject player;
    public float blood_value;
    private float start_blood_value;
    public int single_score;//这个怪的分数
    private void OnGUI()
    {
    if(blood_value <=0){
        blood_value = 0;
    }
        // 线性插值，使得变化更平滑
        //blood_value = Mathf.Lerp(blood_value, blood_value, 0.05f);
        // 使用HorizontalScrollbar作为血条主体，利用value来控制血量多少
        GUI.color = Color.red;
            Vector2 player2DPosition = Camera.main.WorldToScreenPoint (transform.position);
            player2DPosition.y = Screen.height - player2DPosition.y - 30f;
            bloodBar.center = player2DPosition + new Vector2(0 , 0);
            if ( player2DPosition.x > Screen.width || player2DPosition.y > Screen.height
                                                   || player2DPosition.x < 0 || player2DPosition.y < 0) {

            } else {
                GUI.HorizontalScrollbar(bloodBar, 0.0f, blood_value, 0.0f, start_blood_value);  
            }
    }
    private Rect bloodBar;

    void Start()
    {
        bloodBar = new Rect(0,0, 30, 0.1f);
        blood_value = Random.Range(10, 50);
        start_blood_value = blood_value;
        single_score = (int) blood_value;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnEnable()
    {
        bloodBar = new Rect(0,0, 30, 0.1f);
        blood_value = Random.Range(10, 50);
        start_blood_value = blood_value;
        single_score = (int) blood_value;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (player)
        {        //物体朝向一个点移动
            this.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z), step);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("敌人被撞击");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("子弹"))//被子弹射击
        {
        
        if(other.gameObject.name.Contains("Bullet")){
                    blood_value = blood_value - 10;
        }else if(other.gameObject.name.Contains("Rocket")){
                    blood_value = blood_value - 23;
        }
            if (blood_value <= 0)
            {
                add_score_for_player(single_score);
                // this.blood_value = start_blood_value;
                ObjectPool.Instance.PushObject(this.gameObject);
            }
        }
    }

    void add_score_for_player(int score)
    {
        player.GetComponent<PlayerMovement>().add_score(score);
    }
    void invoke_player_reduce_blood()
    {
       player.GetComponent<PlayerMovement>().reduce_blood(1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("撞击到了东西");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")//如果撞击到了主角，主角扣血
        {
            invoke_player_reduce_blood();
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
            invoke_player_reduce_blood();
            Debug.Log("主角扣血");
        }
    }
}
