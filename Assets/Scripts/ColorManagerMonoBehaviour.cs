using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManagerMonoBehaviour : MonoBehaviour {

    public Color color = Color.green;
	
	void OnColorChange(HSBColor color)
    {
        this.color = color.ToColor();
    }
}
