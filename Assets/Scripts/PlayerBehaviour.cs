using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(PlatformPlayerController2D))]
public class PlayerBehaviour : MonoBehaviour
{
    [Header("Required")]
    [SerializeField] AudioClip jumpAudio = null;
    [SerializeField] AudioClip landAudio = null;
    [SerializeField] AudioClip coinAudio = null;
    [SerializeField] AudioClip fallAudio = null;
    [SerializeField] AudioClip clearAudio = null;

    [SerializeField] Transform respawnPoint = null;

    AudioSource audioSource;
    PlatformPlayerController2D player;

    public Action OnFall;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<PlatformPlayerController2D>();

        player.OnJump += () => audioSource.PlayOneShot(jumpAudio);
        player.OnLand += () => audioSource.PlayOneShot(landAudio);
        OnFall += () => { };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!player.IsMovable) return;

        if (other.gameObject.CompareTag("Coin") && other.gameObject.activeInHierarchy)
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.OnCoinEarned();

            audioSource.PlayOneShot(coinAudio);
        }

        if (other.gameObject.CompareTag("Chest") && !GameManager.Instance.isCleared)
        {
            other.GetComponent<Animator>().SetTrigger("ChestOpen");
            GameManager.Instance.OnClear();

            audioSource.PlayOneShot(clearAudio);
        }

        if (other.gameObject.CompareTag("Fall"))
        {
            audioSource.PlayOneShot(fallAudio);
            player.IsMovable = false;
            OnFall();

            Invoke(nameof(Respawn), 3);
        }
    }

    private void Respawn()
    {
        player.IsMovable = true;
        transform.position = respawnPoint.position;
    }


}
