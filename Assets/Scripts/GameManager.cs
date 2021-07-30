using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public AudioSource musicSrc, audioSrc;
    public AudioClip death;

    public GameObject player, explosion;

    private void Start()
    {
        Instance = this;
    }

    public void DeathTrigger()
    {
        StartCoroutine(Die());
    }

    public IEnumerator Die()
    {
        EZCameraShake.CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        LifeCounter.Instance.counter -= 1;
        Destroy(player);
        GameObject explosionPrefab = Instantiate(explosion);
        explosionPrefab.transform.position = player.transform.position;
        musicSrc.Stop();
        audioSrc.PlayOneShot(death);
        yield return new WaitWhile(() => audioSrc.isPlaying);
        SceneManager.LoadScene(1);
    }
}
