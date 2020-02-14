using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : LivingEntity
{
    public Transform firePoint;

    public GameObject bulletPrefab;
    PlayerController playerC;

    [Range(0, 1)]
    public float speed = .2f;

    public float fireRate = 1f;
    public float bulletSpeed = 10f;

    float fireCounter;
    protected override void Start()
    {
        base.Start();
        playerC = GetComponent<PlayerController>();
        //bulletPrefab = GameObject.FindGameObjectWithTag("bullet").GetComponent<Bullet>().gameObject;
    }
    private void Update()
    {
        // movement inputs...
        Vector2 inputs = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputs.Normalize();
        float movements = transform.localScale.y / 20f;
        playerC.movePosition(inputs, speed);

        // fire input...
        if (Input.GetMouseButton(0))
            fire();

    }



    void fire()
    {
        if (fireCounter <= 0)
        {
            AudioManager.instance.PlaySound("playerfire", transform.position);
            GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
            b.gameObject.GetComponent<Bullet>().setSpeed(bulletSpeed);
            fireCounter = fireRate;
        }fireCounter -= Time.deltaTime;
    }
}
