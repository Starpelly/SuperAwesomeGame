using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Uween;

[RequireComponent(typeof(AudioSource))]
public class Conductor : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject square;

    public List<float> events = new List<float>();

    int currentEvent = 0;

    public bool isDone;

    void Start()
    {
        events.Sort();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.Stop();
            audioSource.Play();
            currentEvent = 0;
        }

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            Debug.Log(audioSource.time);
            events.Add(audioSource.time);
        }

        if (!isDone) return;
        if (currentEvent < events.Count)
        {
            if (audioSource.time >= events[currentEvent] - 0.021315f)
            {
                currentEvent++;
                // Debug.Log(audioSource.time);
                GameObject squarePrefab = Instantiate(square);
                squarePrefab.transform.position = new Vector2(8.644f, Random.Range(-4.76f, 4.76f));
                squarePrefab.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                TweenSXY.Add(squarePrefab, 0.25f, new Vector2(0.85f, 0.85f)).EaseOutBounce();
                TweenX.Add(squarePrefab, 1.4f, -10.16f).EaseInSine();
                TweenRZ.Add(squarePrefab, 1.4f, Random.Range(0, 360));
                Destroy(squarePrefab, 1.6f);

                // events.RemoveAt(currentEvent);
            }
        }

        if (audioSource.time >= 84f)
        {
            Application.Quit();
            Debug.Log("quit");
        }

        //Debug.Log(audioSource.time);
    }
}
