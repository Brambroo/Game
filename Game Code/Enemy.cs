using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    Slider healthBar;
    public GameObject explosion;
    public float speed;
    private float invincibility;

    // Use this for initialization
    void Start()
    {   
        healthBar = Canvas.FindObjectOfType<Slider>();
    }

    void Update()
    {
        transform.position -= speed * Vector3.down * Time.deltaTime;

        if (transform.position.y <= -8.0)
        {
            Destroy(gameObject);
            healthBar.value -= 25;
            while (!(invincibility >= 2))
            {
                invincibility += Time.deltaTime;
            }
            invincibility = 0;
        }

    }

    //Detects Collision
    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;

        if(name == "bullet(Clone)")
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            Destroy(expl, 0.5f);
            Destroy(obj.gameObject);
            
        }

        if(name == "player")
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            Destroy(expl, 1);
            healthBar.value -= 25;
            while(!(invincibility >= 2))
            {
                invincibility += Time.deltaTime;
            }
            invincibility = 0;
        }
    }
}
