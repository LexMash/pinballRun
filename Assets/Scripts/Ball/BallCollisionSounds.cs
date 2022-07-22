using System.Collections.Generic;
using UnityEngine;

public class BallCollisionSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _bounceSound;
    [SerializeField] private AudioSource _damageSound;
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _starCollectSound;
    [SerializeField] private AudioSource _multiply;

    [SerializeField] private BallCollision _collision;
    [SerializeField] private float _collectTimeout;
    [SerializeField] private BallMovement _ball;

    [SerializeField] private List<AudioSource> _flipperSounds;

    private float _oldCollectTime;
    private float _newCollectTime;

    private void OnEnable()
    {
        _collision.Bounced += Bounced;
        _collision.Damaged += Damaged;
        _collision.Hited += Hited;
        _collision.ScoreCollected += ScoreCollected;
        _collision.Multiplied += Multiplied;

        _ball.PlayPushSound += MakePushSound;
    }

    private void OnDisable()
    {
        _collision.Bounced -= Bounced;
        _collision.Damaged -= Damaged;
        _collision.Hited -= Hited;
        _collision.ScoreCollected -= ScoreCollected;
        _collision.Multiplied -= Multiplied;

        _ball.PlayPushSound -= MakePushSound;
    }

    private void Multiplied()
    {
        _multiply.Play();
    }
    private void MakePushSound()
    {
        var index = Random.Range(0, _flipperSounds.Count);
        _flipperSounds[index].Play();
    }

    private void Hited(float force)
    {
        _hitSound.volume = force * 0.05f;
        _hitSound.volume = Mathf.Clamp(_hitSound.volume, 0.1f, 1.5f);
        _hitSound.Play();
    }

    private void Damaged()
    {
        _damageSound.Play();
    }

    private void Bounced()
    {
        _bounceSound.Play();
    }

    private void ScoreCollected()
    {       
        PlayCollect();
    }

    private void PlayCollect()
    {
        _newCollectTime = Time.time;
        Pitch(_starCollectSound, _oldCollectTime, _newCollectTime);
        _starCollectSound.Play();
        _oldCollectTime = _newCollectTime;
    }

    private void Pitch(AudioSource audioSource, float oldTime, float newTime)
    {
        if (_newCollectTime - _oldCollectTime > _collectTimeout)
        {
            audioSource.pitch = 0.5f;
        }
        else
        {
            audioSource.pitch += 0.1f;
        }      
    }
}
