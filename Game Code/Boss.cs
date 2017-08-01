using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {

    public int delay = 100;
    public GameObject explosion;
    public GameObject deathNoise;
    public int sceneIndex;
    public int health = 100;
    private float time = 0;
    private float moveTime = 0;
    private float speed = 1f;
    private bool movingRight = true;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        moveTime += Time.deltaTime;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (time < 60)
        {
            time += Time.deltaTime;
        }
        if(time >= 60)
        {
            if(gameObject.transform.position.y > 4)
            {
                gameObject.transform.position += speed * Vector3.down * Time.deltaTime;
            } 
        }
        if(health <= 20)
        {
            if (movingRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x > 5.08f)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (transform.position.x < -5.08f)
                {
                    movingRight = true;
                }
            }
        }

        
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;

        if (name == "bullet(Clone)")
        {
            

            health -= 1;

            if(health <= 0)
            {
                GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
                Destroy(expl, 0.5f);
                Destroy(obj.gameObject);

                Instantiate(deathNoise, transform.position, Quaternion.identity);
                Destroy(deathNoise);

                Destroy(gameObject);
            }

            Destroy(obj.gameObject);

            

        }
    }

}
