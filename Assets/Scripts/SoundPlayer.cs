using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _jumpSFX;
    [SerializeField] private AudioClip[] _attackSFX;
    [SerializeField] private AudioClip[] _groundSFX;
    [SerializeField] private AudioClip _openInventory;
    [SerializeField] private AudioClip _closeInventory;

    private AudioSource _audio;
    public static SoundPlayer Instance;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();

        Instance = null;

        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayJumpSound()
    {
        int index = Random.Range(0, _jumpSFX.Length);
        _audio.PlayOneShot(_jumpSFX[index]);
    }

    public void PlayAttackSound()
    {
        int index = Random.Range(0, _attackSFX.Length);
        _audio.PlayOneShot(_attackSFX[index]);
    }

    public void PlayOtherSound(AudioClip clip)
    {
        _audio.PlayOneShot(clip);
    }

    public void PlayEnemySound(AudioClip[] clip)
    {
        int index = Random.Range(0, clip.Length);
        _audio.PlayOneShot(clip[index]);
    }

    public void PlayCloseSFX()
    {
        _audio.PlayOneShot(_closeInventory);
    }
    public void PlayOpenSFX()
    {
        _audio.PlayOneShot(_openInventory);
    }
}
