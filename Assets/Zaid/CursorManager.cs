using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Sprite idleSprite, clickableSprite, pressingClickableSprite;
    private SpriteRenderer spriteRenderer;
    private bool isClickable = false;

    public float minMovableGrass, maxMovableGrass;
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Clickable"))
        {
            collision.gameObject.transform.position = new Vector3(0, 0, 0);
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
