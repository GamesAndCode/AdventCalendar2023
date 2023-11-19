using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip[] music;
    [SerializeField] private Button muteToogle;
    [SerializeField] private Sprite mute;
    [SerializeField] private Sprite unmute;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music[Random.Range(0, music.Length)];
        audioSource.loop = true;
        StartCoroutine(FadeIn());
        muteToogle.onClick.AddListener(() => Mute());
    }

    public void Mute()
    {
        audioSource.mute = !audioSource.mute;
        muteToogle.GetComponent<Image>().sprite = audioSource.mute ? mute : unmute;
    }

    IEnumerator FadeIn()
    {
        audioSource.volume = 0f;
        audioSource.Play();
        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += Time.deltaTime * 0.5f;
            yield return null;
        }
    }


}
