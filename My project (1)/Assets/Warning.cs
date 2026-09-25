using UnityEngine;

public class Warning : MonoBehaviour
{
    private float warningtimer = 0;

    private float warningwait = 120;
    private float xposition;
    private float yposition;

     Vector2 pos;

    // Update is called once per frame
    void Update()
    {
        yposition = -1;
        xposition = Random.Range(-8, 9);

        pos = new Vector2(xposition, yposition);
        transform.position = pos;
        if (warningtimer > warningwait)
        {
            warningtimer = 0;
            warningwait = Random.Range(1f, 3f);
        }
    }

}