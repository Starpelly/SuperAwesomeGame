using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomQuotes : MonoBehaviour
{
    public string[] quotes;
    public TMP_Text lifes;
    public GameObject overlay;

    private void Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();
        var index = Random.Range(0, quotes.Length);
        text.text = quotes[index];

        // because im lazy i dont wanna create a whole nother script for this.

        lifes.text = LifeCounter.Instance.counter.ToString();
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(2.6f);
        overlay.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        SceneManager.LoadScene(2);
    }
}
