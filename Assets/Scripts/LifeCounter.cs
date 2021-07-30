using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    public static LifeCounter Instance { get; set; }

    public int counter = 3;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
