using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 800, "Red Light, Green Light");
Raylib.SetTargetFPS(60);

while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.Beige);
    Raylib.DrawLine(800, 100, 0, 100, Color.Pink);

    Raylib.EndDrawing();
}