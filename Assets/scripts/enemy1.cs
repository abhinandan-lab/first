using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class enemy1 : LivingEntity
{
    EnemyController enemyC;
    Transform firePoint;

    public GameObject myBullet;

    [Range(.05f, 4f)]//movementspeed
    public float rotationmovement = 3.02f;
    [Range(0, 1.5f)]// this is runspeed
    public float waittime = 0.931f;

    public float runScale = 0.4f;
    public float bulletFireRate = 0.5f;
    public float bulletSpeed = 4f;

    protected override void Start()
    {
        base.Start();
        enemyC = GetComponent<EnemyController>();
        firePoint = transform.GetChild(0).transform;
    }
    private void Update()
    {
        // particular enemy movements bases on the given inputs to this funcion...
        enemyC.RandomMovement(rotationmovement, runScale, waittime);

        // enemy firing pattern specific to this enemy...
        enemyC.firingBullets(myBullet,firePoint,bulletFireRate,bulletSpeed);
        
    }

}
