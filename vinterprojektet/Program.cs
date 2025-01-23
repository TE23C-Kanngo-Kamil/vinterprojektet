using System.Numerics;
using Raylib_cs;

const int screenWidth = 800;
const int screenHeight = 800;
Raylib.InitWindow(screenWidth, screenHeight, "Red Light, Green Light");
Raylib.SetTargetFPS(60);

while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.Beige);
    Raylib.DrawRectangle(0, 125, 800, 25, Color.Pink);
    Raylib.DrawCircle(400, 50, 50, Color.Green);

    float circleX = screenWidth / 2f;
    float circleY = screenHeight / 2f;
    float circleRadius = 20;
    float rectangleWidth = 40;
    float rectangleHeight = 60;
    float rectangleX = circleX - rectangleWidth / 2;
    float rectangleY = circleY + circleRadius;
    float speed = 5f;

    if (Raylib.IsKeyDown(KeyboardKey.Right))
    {
        circleX += speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Left))
    {
        circleX -= speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Down))
    {
        circleY += speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Up))
    {
        circleY -= speed;
    }

    rectangleX = circleX - rectangleWidth / 2;
    rectangleY = circleY + circleRadius;

    Raylib.DrawCircle((int)circleX, (int)circleY, circleRadius, Color.Yellow);
    Raylib.DrawRectangle((int)rectangleX, (int)rectangleY, (int)rectangleWidth, (int)rectangleHeight, Color.Blue);

    Raylib.DrawText("Use arrow keys to move the character", 5, 775, 20, Color.Black);

    Raylib.EndDrawing();
}