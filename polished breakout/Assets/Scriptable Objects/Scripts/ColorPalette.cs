using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Color Palette", menuName = "Breakout/Color Palette", order = 0)]
public class ColorPalette : ScriptableObject
{
    public Color walls, paddle, bricks, ball, background;
}
