using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public Transform visualBox;
    public GameObject[] enemies;
    Transform playerT;

    [Header("Infinity spawns")]
    public int enemySetCount=10;
    public float timeBetweenTwoEnemies = 3f;
    public float enemySpawnBrake = 10f;

    float shw;
    float shh;
    float widht;
    float height;

    int enemyCount = 0;
    Vector3 spawnPosition;
    bool pla=true;
    private void Start()
    {
        playerT = GameObject.FindWithTag("Player").transform;

        float hpw = 0;
        float hph = 0;
        shw = Camera.main.aspect * Camera.main.orthographicSize + hpw;
        shh = Camera.main.orthographicSize + hph;
        visualBox.position = new Vector3(0,-1,0);

        widht = shw*75/100;
        height = shh*75/100;

        StartCoroutine(spawnsEnemy1by1());
        
    }
    private void Update()
    {
        if (playerT == null)
            pla = false;

    }

    IEnumerator spawnsEnemy1by1()
    {
        while (pla)
        {
            for (int i = 0; i < enemySetCount; i++)
            {
                // take random angle and random enemy;
                // instantiate 1 and wait for time
                GameObject e = enemies[Random.Range(0, enemies.Length)];
                float randomAngle = Random.Range(0, 359);
                Quaternion rot = Quaternion.Euler(Vector3.forward * randomAngle);
                e.gameObject.transform.rotation = rot;

                Instantiate(e, gettingPosition(), e.transform.rotation);
                enemyCount++;
                print("enemy Spawned: " + enemyCount);
                yield return new WaitForSeconds(timeBetweenTwoEnemies);
            }
            // wait for long seconds and calculate the next wave enemy style
            // simultaneously count the number of enemies spawned to certain reach and drop second weapon

            yield return new WaitForSeconds(enemySpawnBrake);
        }
    }
    Vector3 gettingPosition()
    {
        Vector3 pos = new Vector3(Random.Range(-shw, shw), Random.Range(-shh, shh),0);
        if((pos.x>-widht || pos.x<widht)&& (pos.y < shh&& pos.y>0.5))
        {
            spawnPosition = pos;
        }
        return spawnPosition;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(visualBox.position, new Vector3(widht*2, height*2, 0));
    }
}
