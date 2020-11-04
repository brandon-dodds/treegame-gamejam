using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changesprite : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    public void ChangeSprite(int i)
    {
        spriteRenderer.sprite = spriteArray[i];
    }
}
