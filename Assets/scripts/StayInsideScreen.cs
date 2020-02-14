using UnityEngine;

public class StayInsideScreen : MonoBehaviour
{
    float shw;
    float shh;

    private void Start()
    {
        float hpw = 0;
        float hph = 0;
        shw = Camera.main.aspect * Camera.main.orthographicSize + hpw;
        shh = Camera.main.orthographicSize + hph;
    }
    private void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -shw, shw), Mathf.Clamp(transform.position.y, -shh, shh));
    }
}
