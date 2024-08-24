
using Unity.VisualScripting;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private bool isClickable = false;
    public bool notParalyzed = true;
    public bool isInsect=false;
    public float minMovableGrass, maxMovableGrass;
    private GameObject clickableObject;
    private Vector2 initialCursorPos;
    private Vector2 initialObjectPos;
    private GameObject insectTouched;
    private float normalizedPosition;
    public TopDownGlobalScript golfLogicManager;
    public GameObject movableGrassObj;
    void Start()
    {
        movableGrassObj.transform.position = new Vector3((maxMovableGrass + minMovableGrass) / 2, movableGrassObj.transform.position.y, movableGrassObj.transform.position.z);
        Cursor.visible = false;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            Cursor.visible = true;
            return;
        }
        Cursor.visible = false;
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        if (isClickable && notParalyzed && !isInsect)
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialCursorPos = cursorPosition;
                initialObjectPos = clickableObject.transform.position;
            }

            if (Input.GetMouseButton(0))
            {
                float deltaX = cursorPosition.x - initialCursorPos.x;
                float newX = Mathf.Clamp(initialObjectPos.x + deltaX, minMovableGrass, maxMovableGrass);

                clickableObject.transform.position = new Vector2(newX, clickableObject.transform.position.y);
                normalizedPosition = (newX - minMovableGrass) / (maxMovableGrass - minMovableGrass);
                golfLogicManager.holeRadius = normalizedPosition * golfLogicManager.maxHoleRadius;
                UpdateSusAmount(normalizedPosition);
            }
        }
        else if (notParalyzed && isInsect && Input.GetMouseButtonDown(0))
        {
                insectTouched.GetComponent<InsectController>().Killed();
                PlaySound(squash);
        }
    }
    public GameObject sfxObj;
    public AudioClip squash;
    public void PlaySound(AudioClip s)
    {
        GameObject _sound = Instantiate(sfxObj);
        _sound.GetComponent<AudioSource>().clip = s;
        _sound.GetComponent<AudioSource>().Play();
        Destroy(_sound, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Clickable"))
        {
            isClickable = true;
            clickableObject = collision.gameObject;
            if (collision.gameObject.name.Contains("insect"))
            {
                insectTouched = collision.gameObject;
                isInsect = true;
            }
            else
            {
                isInsect = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Clickable"))
        {
            isClickable = false;
            isInsect = false;
            clickableObject = null;
        }
        if (collision.gameObject.name.Contains("insect"))
        {
            isInsect = false;
        }
    }
    public void UpdateSusAmount(float normalizedPosition)
    {
        if (normalizedPosition < 0.4f)
        {
            golfLogicManager.susAmountToAdd = Mathf.Clamp01((0.4f - normalizedPosition) / 0.3f);
        }
        else if (normalizedPosition > 0.6f)
        {
            golfLogicManager.susAmountToAdd = Mathf.Clamp01((normalizedPosition - 0.6f) / 0.3f);
        }
        else
        {
            golfLogicManager.susAmountToAdd = 0f;
        }
    }
}
