using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {


    Slider healthBar;
    public GameObject bullet;
    public AudioSource fireSound;

    void Start()
    {
        this.GetComponent<AudioSource>().playOnAwake = false;
        healthBar = Canvas.FindObjectOfType<Slider>();

        StartCoroutine(PauseCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            if(transform.position.x < 12.08f)
            {
                transform.position += Vector3.right * 10 * Time.deltaTime;
            }
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if(transform.position.x > -12.08f)
            {
                transform.position += Vector3.left * 10 * Time.deltaTime;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Space) && healthBar.value > 0)
        {

            fireSound.Play();
            Instantiate(bullet, new Vector3(transform.position.x, -6), Quaternion.identity);
            
        }
    }

    //Pauses Game
    IEnumerator PauseCoroutine()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                  
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
            yield return null;
        }
    }
}
