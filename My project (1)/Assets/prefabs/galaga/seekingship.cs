using UnityEngine;

public class seekingship : MonoBehaviour
{
    private GameObject player;
    public GameObject explosion;

    public float speed = 2f;
    public float maxDegrees = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = -(player.transform.position - transform.position);
        transform.rotation = Quaternion.Euler(
            Mathf.Rad2Deg * transform.rotation.x, 
            Mathf.Rad2Deg * transform.rotation.y, 
            Mathf.Clamp(Mathf.Rad2Deg * transform.rotation.z, -maxDegrees, maxDegrees));
        
        transform.Translate(-transform.up * speed * Time.deltaTime);

        if(transform.position.y <-6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Playerbullet"))
        {
            Destroy(collision.gameObject);
            GameObject temp = Instantiate(explosion, transform.position, Quaternion.
                identity);
            Destroy(temp, 1.0f);
            Destroy(gameObject);
        }
    }
}
