using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour
{

    private CursorControl cursor;
    private SpriteRenderer spriteRenderer;

    void Awake ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start ()
    {
        cursor = transform.parent.GetComponent<CursorControl>();
        spriteRenderer.color = cursor.playerColor;
    }
}
