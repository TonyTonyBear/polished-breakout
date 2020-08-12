using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaletteSetter : MonoBehaviour
{
    [SerializeField] private List<ColorPalette> colorPalettes;
    private int currentPaletteIndex = 0;

    [SerializeField] private SpriteRenderer ball, paddle, background;
    [SerializeField] private List<SpriteRenderer> bricks, walls;

    private void OnEnable()
    {
        ColorPalette currentPalette = colorPalettes[currentPaletteIndex];

        ball.color = currentPalette.ball;
        paddle.color = currentPalette.paddle;
        background.color = currentPalette.background;

        foreach (SpriteRenderer brick in bricks)
            brick.color = currentPalette.bricks;

        foreach (SpriteRenderer wall in walls)
            wall.color = currentPalette.walls;
    }
}
