using UnityEngine;

public class enemy2 : LivingEntity
{
    EnemyController enemyC;
    Transform firePoint;
    Transform playerTarget;

    public GameObject myBullet;

    [Range(.05f, 4f)]//movementspeed
    public float rotationmovement = 1f;
    [Range(0, 1.5f)]// this is runspeed
    public float waittime = 4f;

    public float runScale = 0.4f;
    public float bulletFireRate = 0.5f;
    public float bulletSpeed = 10f;
    public float EnemyLookRange = 1.5f;


    //bool canSeePlayer = false;

    protected override void Start()
    {
        base.Start();
        enemyC = GetComponent<EnemyController>();
        firePoint = transform.GetChild(0).transform;
        playerTarget = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    private void Update()
    {
        if (playerTarget != null)
        {
            if (!(enemyC.checkCanSeePlayer(playerTarget.position, EnemyLookRange)))
            {
                // particular enemy movements bases on the given inputs to this funcion...
                enemyC.RandomMovement(rotationmovement, runScale, waittime);
            }

            //enmey looking range to shoot player...
            if ((enemyC.checkCanSeePlayer(playerTarget.position, EnemyLookRange)))
            {
                enemyC.LookToTarget(playerTarget.position);
            }
        }

        // enemy firing pattern specific to this enemy...
        enemyC.firingBullets(myBullet, firePoint, bulletFireRate, bulletSpeed);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, EnemyLookRange);
    }

}
