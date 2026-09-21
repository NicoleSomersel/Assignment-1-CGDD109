using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed = 5;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
    }
}
