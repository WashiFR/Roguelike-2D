using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;

    public static DontDestroyOnLoadScene instance;

    // permet d'utiliser les fonctions de la classe dans les autres classe
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de DontDestroyOnLoadScene dans la scène");
            return;
        }

        instance = this;

        foreach (var item in objects)
        {
            DontDestroyOnLoad(item);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var item in objects)
        {
            SceneManager.MoveGameObjectToScene(item, SceneManager.GetActiveScene());
        }
    }
}
