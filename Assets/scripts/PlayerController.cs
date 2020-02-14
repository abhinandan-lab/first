using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    bool up = false;
    bool down = false;
    bool left = false;
    bool right = false;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    public void movePosition(Vector2 input, float scaleSize )
    {
        if (input.x > 0)
        {
            //right
            if (right)
            {
                rb.MovePosition(new Vector2(rb.position.x+scaleSize,rb.position.y));
            }
            else
            {// this may be a function called right
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
                else
                    return;
            }

        }

        if (input.x < 0)
        {
            //left
            if (left)
            {
                rb.MovePosition(new Vector2(rb.position.x-scaleSize,rb.position.y));
            }
            else
            {// this may be left function
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
                else
                    return;
            }
        }

        if (input.y > 0)
        {
            //up
            if (up)
            {
                rb.MovePosition(new Vector2(rb.position.x,rb.position.y+scaleSize));
            }
            else
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
                else
                    return;
            }
        }

        if (input.y < 0)
        {
            //down
            if (down)
            {
                rb.MovePosition(new Vector2(rb.position.x,rb.position.y-scaleSize));
            }
            else
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
                else
                    return;
            }

        }
    }




}
