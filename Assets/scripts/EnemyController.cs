using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemyrb;
    Transform enemyTransform;

    bool right = false;
    bool left = false;
    bool up = false;
    bool down = false;

    int direction;

    float timeCounter;
    float fireTimeCounter;

    private void Start()
    {
        enemyTransform = GetComponent<Transform>();
        enemyrb = GetComponent<Rigidbody2D>();
    }

    public void RandomMovement(float rotationMovement,float runSpeed,float waittime)
    {
        if (timeCounter <= 0)
        {
            int pc = 0;
            int choice = Random.Range(0, 2);
            if (choice != pc)
            {
                // rotating...
                StartCoroutine(rotateRandom());
            }
            if (choice != pc)
            {
                // moving...
                StartCoroutine(moveSomeSteps(runSpeed, waittime));
            }
            else
                choice = Random.Range(0, 2);

            timeCounter = rotationMovement;
        }
        timeCounter -= Time.deltaTime;
    }

    public void firingBullets(GameObject specifiedBullet, Transform specifiedFirePoint, float bulletFireRate, float specifiedBulletSpeed)
    {
        if (fireTimeCounter <= 0)
        {
            GameObject b = Instantiate(specifiedBullet, specifiedFirePoint.position, specifiedFirePoint.rotation);
            b.gameObject.GetComponent<Bullet>().setSpeed(specifiedBulletSpeed);
            fireTimeCounter = bulletFireRate;
        }
        fireTimeCounter -= Time.deltaTime;
    }

    public void firingBullets(GameObject specifiedBullet,Transform specifiedFirePoint,float bulletFireRate,float specifiedBulletSpeed, string sfxname)
    {
        if (fireTimeCounter <= 0)
        {
            if (enemyTransform != null)
                callfire(sfxname, transform.position);
            GameObject b = Instantiate(specifiedBullet, specifiedFirePoint.position, specifiedFirePoint.rotation);
            b.gameObject.GetComponent<Bullet>().setSpeed(specifiedBulletSpeed);
            fireTimeCounter = bulletFireRate;
        }fireTimeCounter -= Time.deltaTime;
    }

    public void callfire(string sfxname,Vector2 position)
    {
        AudioManager.instance.PlaySound(sfxname, position);
    }

    public bool checkCanSeePlayer(Vector2 targetposition, float enemyRange)
    {
        float distance = Vector2.Distance(transform.position, targetposition);
        if (distance <= enemyRange)
        {
            //print(distance);
            return true;
        }
        else
            return false;
    }

    public void LookToTarget(Vector3 targetPosition)
    {
        Vector2 direction = targetPosition - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemyrb.rotation = angle+-90;
    }


    // assets kind of methods...//////////////////////////////////////////////////////////////
    IEnumerator rotateRandom()
    {
        direction = Random.Range(0, 4);
        Vector2 position = transform.position;

        switch (direction)
        {
            case 0:
                Right();
                break;
            case 1:
                Left();
                break;
            case 2:
                Up();
                break;
            case 3:
                Down();
                break;
        }
        yield return null;
    }
    IEnumerator moveSomeSteps( float mScale,float waitT)
    {
        int steps = Random.Range(1, 10);
        for(int i = 0; i < steps; i++)
        {
            switch (direction)
            {
                case 0:
                    enemyrb.position = new Vector2(transform.position.x + mScale, transform.position.y);
                    break;
                case 1:
                    enemyrb.position = new Vector2(transform.position.x - mScale, transform.position.y);
                    break;
                case 2:
                    enemyrb.position = new Vector2(transform.position.x, transform.position.y + mScale);
                    break;
                case 3:
                    enemyrb.position = new Vector2(transform.position.x, transform.position.y - mScale);
                    break;
            }
            float waitTime = waitT / Time.deltaTime;
            yield return new WaitForSeconds(waitTime);
        }
        yield return null;
    }
    void Right()
    {
        Quaternion a = transform.rotation;
        if (a.eulerAngles.z != 270f)
        {
            a.eulerAngles = new Vector3(a.eulerAngles.x, a.eulerAngles.y, 270f);
            transform.rotation = a;
            right = true;
            left = false;
            down = false;
            up = false;
        }
    }
    void Left()
    {
        Quaternion a = transform.rotation;
        if (a.eulerAngles.z != 90f)
        {
            a.eulerAngles = new Vector3(a.eulerAngles.x, a.eulerAngles.y, 90f);
            transform.rotation = a;
            right = false;
            left = true;
            down = false;
            up = false;
        }
    }
    void Up()
    {
        Quaternion a = transform.rotation;
        if (a.eulerAngles.z != 0)
        {
            a.eulerAngles = Quaternion.identity.eulerAngles;
            transform.rotation = a;
            right = false;
            left = false;
            down = false;
            up = true;
        }
    }
    void Down()
    {
        Quaternion a = transform.rotation;
        if (a.eulerAngles.z != 180)
        {
            a.eulerAngles = new Vector3(a.eulerAngles.x, a.eulerAngles.y, 180f);
            transform.rotation = a;
            right = false;
            left = false;
            down = true;
            up = false;
        }
    }

}
