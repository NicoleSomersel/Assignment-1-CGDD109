using UnityEngine;

public class Extraplayership : MonoBehaviour
{

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(1f, 0, 0);
    }
}
