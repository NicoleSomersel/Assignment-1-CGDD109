using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Galagamovement : MonoBehaviour
{
    public float speed = 4;

    public GameObject Bullets;
    public GameObject heart;

    public GameObject HeartContainer;

    public int lives = 3;

    public int protection = 0; //starting with none
    public int maxprotection = 5; //for power collection originally set to like 3 but i'm changing it to 5 lowkey
    void Start()
    {
        while (HeartContainer.transform.childCount < lives)
        {
            GameObject temp = Instantiate(heart, HeartContainer.transform);
            temp.transform.SetParent(HeartContainer.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //+ new Vector3(0, 5f, 0) is to spawn the bullet with offset above the player
            Instantiate(Bullets, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
        //traveling upwards (AND = &&, OR = ||)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        //traveling downwards
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        //traveling left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        //traveling right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        //setting position to new vector3, storing it as current x position and constraining y position, z is our depth
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -7f, 7f),
            Mathf.Clamp(transform.position.y, -3.5f, 3.5f), transform.position.z);
    }


        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemybullet"))
        {
            if (protection > 0)
            {
                protection = protection - 1;
            }
            else
            {
                if (HeartContainer.transform.childCount > 0)
                {
                    Destroy(HeartContainer.transform.GetChild(HeartContainer.transform.childCount - 1).gameObject);
                }
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Galagaship"))
        {
            if (protection > 0)
            {
                protection = protection - 1;
            }
            else
            {
                if (HeartContainer.transform.childCount > 0)
                {
                    Destroy(HeartContainer.transform.GetChild(HeartContainer.transform.childCount - 1).gameObject);
                }
                if (HeartContainer.transform.childCount <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
        else if (collision.gameObject.CompareTag("powerup"))
        {
            protection = maxprotection; //for when powerup is collected set it so that it equals the number of hits player can take before damage is taken.
            if (HeartContainer.transform.childCount < 3)
            {
                Instantiate(heart, HeartContainer.transform); //Surely this does the opposite of Destroy and gives the player back one health no?
            }
            Destroy(collision.gameObject);
        }
    }
}
