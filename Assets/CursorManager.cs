using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Sprite idleSprite, clickableSprite, pressingClickableSprite;
    private SpriteRenderer spriteRenderer;
    private bool isClickable = false;

    void Start()
    {
        Cursor.visible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = idleSprite;
    }

    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;
        if (isClickable)
        {
            if (Input.GetMouseButton(0))
            {
                spriteRenderer.sprite = pressingClickableSprite;
            }
            else
            {
                spriteRenderer.sprite = clickableSprite;
            }
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Clickable"))
        {
            isClickable = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Clickable"))
        {
            isClickable = false;
        }
    }
}
