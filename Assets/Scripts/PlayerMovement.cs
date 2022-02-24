using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

//切换枪，人物移动，枪支旋转
namespace BulletHell
{
    public class PlayerMovement : MonoBehaviour
    {
        public GameObject[] guns;
        public float speed;
        private Vector2 input;
        public GameObject bloodPrefab;
        private Vector2 mousePos;
        private Animator animator;
        private Rigidbody2D rigidbody;
        private int gunNum;
        void Start()
        {
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
            guns[0].SetActive(true);
            blood_value = 100;
            total_blood = 100;
            bloodBar = new Rect(0,0, 30, 0.1f);

        }
        private Rect bloodBar;

        private int all_score = 0;
        private float total_blood;
        public float blood_value;

        public void reduce_blood(float value)
        {
            this.blood_value = blood_value - value;
        }

        public void add_score(int score)
        {
            this.all_score += score;
        }


        private void OnGUI()
        {
            if (blood_value <= 0)
            {
                blood_value = 0;
                ObjectPool.restart_object_pool();
                SceneManager.LoadScene (0);
            }
            // 显示分数
            GUI.Button(new Rect(0, 0, 80, 40), "分数:" + all_score);
            GUI.Button(new Rect(80, 0, 80, 40), "血量:" + blood_value);
            // 使用HorizontalScrollbar作为血条主体，利用value来控制血量多少
            GUI.color = Color.red;
            
            Vector2 player2DPosition = Camera.main.WorldToScreenPoint (transform.position);
            player2DPosition.y = Screen.height - player2DPosition.y - 30f;
            bloodBar.center = player2DPosition + new Vector2(0 , 0);
            if ( player2DPosition.x > Screen.width || player2DPosition.y > Screen.height
                                                   || player2DPosition.x < 0 || player2DPosition.y < 0) {

            } else {
                GUI.HorizontalScrollbar(bloodBar, 0.0f, blood_value, 0.0f, total_blood);  
            }
        
        }
        void Update()
        {
            SwitchGun();
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            rigidbody.velocity = input.normalized * speed;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }

            if (input != Vector2.zero)
                animator.SetBool("isMoving", true);
            else
                animator.SetBool("isMoving", false);
        }

        void SwitchGun()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                guns[gunNum].SetActive(false);
                if (--gunNum < 0)
                {
                    gunNum = guns.Length - 1;
                }
                guns[gunNum].SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                guns[gunNum].SetActive(false);
                if (++gunNum > guns.Length - 1)
                {
                    gunNum = 0;
                }
                guns[gunNum].SetActive(true);
            }
        }
    }

}