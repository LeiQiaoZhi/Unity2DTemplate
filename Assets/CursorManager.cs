using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Sprite cursorSprite;
    SpriteRenderer _cursorSpriteRenderer;
    private Camera _cam;
    
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        Cursor.visible = false;
        _cursorSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _cursorSpriteRenderer.sprite = cursorSprite;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        _cursorSpriteRenderer.transform.position = mousePos;
    }
}
