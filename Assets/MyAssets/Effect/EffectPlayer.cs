using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EffectPlayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            spriteRenderer.color -= new Color(0.0f, 0.0f, 0.0f, Time.deltaTime * 4.0f);
            if (spriteRenderer.color.a < 0.0f)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            spriteRenderer.color += new Color(0.0f, 0.0f, 0.0f, Time.deltaTime * 2.0f);
            if (spriteRenderer.color.a > 255.0f)
            {
                spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 255.0f);
                isPlay = true;
            }
        }
    }
}
