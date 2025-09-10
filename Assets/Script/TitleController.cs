using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void onClickStartButton()
    {
        if (sound != null && audioSource != null)
        {
            audioSource.PlayOneShot(sound);
        }

        Invoke("GoMainGame", 1f);
    }

    void GoMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
