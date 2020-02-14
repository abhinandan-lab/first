using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip menu;
    public AudioClip game;

    private void Start()
    {
        print("helloworld");
        AudioManager.instance.PlayMusic(menu, 2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.PlayMusic(game, 3);
        }


    }
}
