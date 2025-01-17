using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 800, "Red Light, Green Light");
Raylib.SetTargetFPS(60);

while (Raylib.WindowShouldClose() == false)
{
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.Beige);
    Raylib.DrawRectangle(0, 125, 800, 25, Color.Pink);
    

    Raylib.EndDrawing();
}