using UnityEngine;

public class SideshipGold : MonoBehaviour
{
    public GameObject[] powerup;
    private float powerTimer = 0, powerWait = 3;
    public float maxX = 6f,minX = -6f;
    public float Spawn = 5f;

    // Update is called once per frame
    void Update()
    {
        powerTimer += Time.deltaTime;

        if (powerTimer > powerWait)
        {
            powerTimer = 0;
            float randomX = Random.Range(minX, maxX);
            Vector3 posX = new Vector3(randomX, Spawn, 0);
            Instantiate(powerup[Random.Range(0, powerup.Length)], posX, Quaternion.identity);
        }
    }

}
