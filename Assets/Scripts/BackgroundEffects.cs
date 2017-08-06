using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEffects : MonoBehaviour {
    SpriteRenderer rend;
    //The R value bounds in the RGB color value of the background.
    const float leftColorBound = 63f;
    const float rightColorBound = 255f;
    //Vertical transform to be applied to sin result.
    const float oscilationRange = (rightColorBound - leftColorBound) / 2;
    float oscilationOffset;

    // Use this for initialization
    void Start () {
        //Offset init since I'm using range field in calc.
        oscilationOffset = oscilationRange + leftColorBound;
         
        rend = GetComponent<SpriteRenderer>();
        if(rend == null) { return; }

        transform.localScale = Vector3.one;

        float spriteWidth = rend.sprite.bounds.size.x;
        float spriteHeight = rend.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector2(worldScreenWidth / spriteWidth, worldScreenHeight / spriteHeight);
	}

    void Update() {
        byte r = (byte)(oscilationOffset + Mathf.Sin(Time.time * 2) * oscilationRange);
        rend.color = new Color32(r, 141, 205, 255);
    }
}
