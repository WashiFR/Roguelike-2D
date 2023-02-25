using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D cursorMenu;
    public Texture2D cursorGame;

    // Update is called once per frame
    void Update()
    {
        if (!GameOverMenu.instance.isGameOver && !PauseMenu.instance.isGamePaused)
        {
            Cursor.SetCursor(cursorGame, new Vector2(cursorGame.width / 2, cursorGame.height / 2), CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(cursorMenu, Vector2.zero, CursorMode.Auto);
        }
    }
}
