using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlaylsit : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    [SerializeField] private Slider volumeSlider;
    private AudioSource audioSource;

    
    private void Awake()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic(clips[Random.Range(0, clips.Length)]));
    }

    private void OnVolumeChanged(float value)
    {
        audioSource.volume = value;
    }
    private IEnumerator PlayMusic(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        audioSource.clip = clip;
        AudioClip newClip = clips[Random.Range(0, clips.Length)];
        while (clip == newClip)
        {
            newClip = clips[Random.Range(0, clips.Length)];
        }
        StartCoroutine(PlayMusic(newClip));
    }
    
}
