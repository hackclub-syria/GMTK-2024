using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Sprite idleSprite, clickableSprite, pressingClickableSprite;
    private SpriteRenderer spriteRenderer;
    private bool isClickable = false;
    public bool notParalyzed = true; // controlled by insects
    public float minMovableGrass, maxMovableGrass;
    private GameObject clickableObject;
    private Vector2 initialCursorPos;
    private Vector2 initialObjectPos;

    private float normalizedPosition;

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

        if (isClickable && notParalyzed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialCursorPos = cursorPosition;
                initialObjectPos = clickableObject.transform.position;
            }

            if (Input.GetMouseButton(0))
            {
                spriteRenderer.sprite = pressingClickableSprite;

                float deltaX = cursorPosition.x - initialCursorPos.x;
                float newX = Mathf.Clamp(initialObjectPos.x + deltaX, minMovableGrass, maxMovableGrass);

                clickableObject.transform.position = new Vector2(newX, clickableObject.transform.position.y);
                normalizedPosition = (newX - minMovableGrass) / (maxMovableGrass - minMovableGrass);
                Debug.Log("normalized pos: " + normalizedPosition);
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
            clickableObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Clickable"))
        {
            isClickable = false;
            clickableObject = null;
        }
    }
}
