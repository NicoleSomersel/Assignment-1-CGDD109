using UnityEngine;

public class Dragonmove : MonoBehaviour
{
    public float speed = 5;
    private bool goingUp = true;

    private float ratTimer = 0, fireballTimer = 0, lazerTime = 0;

    private float ratWait = 3;
    private float fireballwait = 3;

    private float lazerwait = 5;
    public GameObject rat;
    public GameObject fireball;

    public GameObject lazer;


    // Update is called once per frame
    void Update()
    {

        //spawning
        ratTimer += Time.deltaTime;
        fireballTimer += Time.deltaTime;
        

        if (ratTimer > ratWait) {
            Instantiate(rat, transform.position, Quaternion.identity);
            ratTimer = 0;
            ratWait = Random.Range(1f, 3f);
        }
        if (fireballTimer > fireballwait)
        {
            Instantiate(fireball, transform.position, Quaternion.identity);
            fireballTimer = 0;
            fireballwait = Random.Range(1f, 3f);
        }
        if (lazerTime > lazerwait)
        {
            Instantiate(lazer, , Quaternion.identity);
            lazerTime = 0;
            lazerwait = Random.Range(1f, 3f);
        }



        transform.Translate(transform.up * speed * Time.deltaTime);
        if (transform.position.y > 4 && goingUp == true) {
            goingUp = false;
            speed *= -1;
        }
        if (transform.position.y < -4 && goingUp == false)
        {
            goingUp = true;
            speed *= -1;
        }
    }
}
    