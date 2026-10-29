using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public GameObject[] waves;
    private float waveTimer = 0, waveWait = 3;
    // Update is called once per frame
    void Update()
    {
        waveTimer += Time.deltaTime;

        if (waveTimer > waveWait) {
            waveTimer = 0;
            Instantiate(waves[Random.Range(0, waves.Length)], transform.position, Quaternion.identity);
        }
    }
}
