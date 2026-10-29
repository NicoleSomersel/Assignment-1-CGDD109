using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class bulletship : MonoBehaviour
{
    public float bulletTimer = 0, bulletWait = 2;
    public float speed = 3;
    public GameObject bullet;
    public GameObject explosion;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.up * speed * Time.deltaTime);
        bulletTimer += Time.deltaTime;
        if (bulletTimer > bulletWait)
        {
            bulletTimer = 0;
            Instantiate(bullet, transform.position - new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
        if (transform.position.y < -6)
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
