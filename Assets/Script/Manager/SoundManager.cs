using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(audioClips[0]);
    }
    public void DoorSound()
    {
        audioSource.PlayOneShot(audioClips[1]);
    }
    public void FinishLine()
    {
        audioSource.PlayOneShot(audioClips[2]);
    }

}
