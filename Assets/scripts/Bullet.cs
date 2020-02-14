using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameRecords gr;
    public LayerMask enemyLayer;
    public ParticleSystem deathEffect;
    float Bspeed;
    float damage = 1f;

    private void Start()
    {
        gr = FindObjectOfType<GameRecords>();
        Destroy(gameObject, 3f);
    }
    public void setSpeed(float speed)
    {
        Bspeed = speed;
    }

    void Update()
    {
        float movedDistance = Bspeed * Time.deltaTime;
        checkCollisions(movedDistance);
        transform.Translate(Vector3.up*movedDistance);

        //Debug.DrawLine(transform.position, (transform.up).normalized / 16 + transform.position);
    }

    void checkCollisions(float distanceMoved)
    {
        string myname = transform.name;
        Vector2 rayorigin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distanceMoved);
        if (hit.collider!=null)
        {
            onHitObject(hit);
            //print(hit.collider.gameObject.name + " :collides with: " + myname);
        }
    }

    void onHitObject(RaycastHit2D hit)
    {
        DamagableInterface damagableEntity = hit.collider.gameObject.GetComponent<DamagableInterface>();
        if (damagableEntity != null && transform.gameObject.layer!=hit.collider.gameObject.layer)
        {
            // bullet hit soundfx
            AudioManager.instance.PlaySound2D("playerbulletHit");

            GameObject pe = Instantiate(deathEffect.gameObject, hit.point, Quaternion.Euler(Vector3.forward));
            float lifetime = deathEffect.main.startLifetimeMultiplier;
            Destroy(pe, lifetime);
            damagableEntity.takeDamage(damage);
            if (pe.tag == "Player" && pe!=null)
            {
                gr.playerHealth(damage);
            }
        }
        //print("destroyed..");
        Destroy(gameObject);
    }
}
