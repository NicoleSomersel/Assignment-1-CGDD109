using TMPro;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public TextMeshProUGUI scoreBox;
    public TextMeshProUGUI lives;
    public float speed = 4;
    private int score = 0;
    private int health = 3;

    private void Start()
    {
        scoreBox.text = "Score: " + score;
        lives.text = "health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
        //traveling upwards (AND = &&, OR = ||)
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
        }
        //traveling downwards
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        //traveling downwards
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        //setting position to new vector3, storing it as current x position and constraining y position, z is our depth
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 3.5f), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (collision.gameObject.GetComponent<Projectile>() != null) 
            {
                score += collision.gameObject.GetComponent<Projectile>().points;
                scoreBox.text = "Score: " + score;
                health -= collision.gameObject.GetComponent<Projectile>().points;
                lives.text = health;
            }
        }
        Destroy(collision.gameObject);
    }
}
