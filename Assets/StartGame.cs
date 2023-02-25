using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string loadScene;
    public GameObject keyE;
    public bool canStartTheGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            keyE.SetActive(true);
            canStartTheGame = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("FootPlayer"))
        {
            keyE.SetActive(false);
            canStartTheGame = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canStartTheGame)
        {
            SceneManager.LoadScene(loadScene);
        }
    }
}
