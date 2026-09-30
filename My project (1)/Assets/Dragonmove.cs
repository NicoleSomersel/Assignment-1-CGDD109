using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Dragonmove : MonoBehaviour
{
    public float speed = 5;
    private bool goingUp = true;
    private float xpos=0;

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
        lazerTime += Time.deltaTime;


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
            xpos = Random.Range(2, 4);
            Vector3 pos = new Vector3(xpos, 0, 1);
            Instantiate(lazer, pos, Quaternion.identity);
            lazerTime = 0;
            lazerwait = Random.Range(1f, 12f);
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
    