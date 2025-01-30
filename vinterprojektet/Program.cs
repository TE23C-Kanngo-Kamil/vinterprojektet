using System.Numerics;
using Raylib_cs;

// Skärmdimensioner
const int screenWidth = 800;
const int screenHeight = 1000;

Raylib.InitWindow(screenWidth, screenHeight, "Red Light, Green Light");
Raylib.SetTargetFPS(60);

// Karaktärens egenskaper
float circleRadius = 20;
float rectangleWidth = 40;
float rectangleHeight = 60;
float speed = 2f;

// Börja längst ner
float circleX = screenWidth / 2f;
float circleY = screenHeight - rectangleHeight - circleRadius;

while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.Beige);
    Raylib.DrawRectangle(0, 125, 800, 25, Color.Pink);
    Raylib.DrawCircle(400, 50, 50, Color.Green);

    if (Raylib.IsKeyDown(KeyboardKey.Right) && (circleX + circleRadius + speed) < screenWidth)
    {
        circleX += speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Left) && (circleX - circleRadius - speed) > 0)
    {
        circleX -= speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Down) && (circleY + rectangleHeight + circleRadius + speed) < screenHeight)
    {
        circleY += speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Up) && (circleY - circleRadius - speed) > 0)
    {
        circleY -= speed;
    }

    float rectangleX = circleX - rectangleWidth / 2;
    float rectangleY = circleY + circleRadius;

    Raylib.DrawCircle((int)circleX, (int)circleY, circleRadius, Color.Yellow);
    Raylib.DrawRectangle((int)rectangleX, (int)rectangleY, (int)rectangleWidth, (int)rectangleHeight, Color.Blue);

    Raylib.DrawRectangle(0, 0, screenWidth, 5, Color.Beige); // Övre kant
    Raylib.DrawRectangle(0, 0, 5, screenHeight, Color.Beige); // Vänster kant
    Raylib.DrawRectangle(screenWidth - 5, 0, 5, screenHeight, Color.Beige); // Höger kant

    Raylib.DrawText("Use arrow keys to move the character", 5, 975, 20, Color.Black);

    Raylib.EndDrawing();
}