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
        SetPalette();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentPaletteIndex--;

            if (currentPaletteIndex < 0)
                currentPaletteIndex = colorPalettes.Count - 1;

            SetPalette();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentPaletteIndex++;

            if (currentPaletteIndex >= colorPalettes.Count)
                currentPaletteIndex = 0;

            SetPalette();
        }
    }

    private void SetPalette()
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
