using System.Collections;
using System.Collections.Generic;
using BulletHell;
using UnityEngine;

public class Wall : MonoBehaviour
{    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        Debug.Log("撞墙");
        Debug.Log(other.gameObject.name);
    }

    void GetMessage()
    {
        
    }
}
