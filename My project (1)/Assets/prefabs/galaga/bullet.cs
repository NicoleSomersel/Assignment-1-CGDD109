using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
}
