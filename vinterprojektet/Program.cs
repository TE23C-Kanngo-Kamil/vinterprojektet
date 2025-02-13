using System.Numerics;
using Raylib_cs;

/* 

Jag ska lägga till en funktion där den gröna lampan längst fram blir röd av slump med random.Next
Om spelaren rör sig medan lampan är röd ska skärmen bli svart och en röd text ska visas där det står "GAME OVER"

*/

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

// Börjar längst ner
float circleX = screenWidth / 2f;
float circleY = screenHeight - rectangleHeight - circleRadius;

// Skriftande ljus
Random random = new Random();
double lastChangeTime = Raylib.GetTime();
double nextChangeTime = random.Next(2, 3);
bool GreenLight = true; // Startar med grönt ljus

// Spelets loop
while (Raylib.WindowShouldClose() == false)
{
    // Ritar mappen
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Beige); // Sand
    Raylib.DrawRectangle(0, 125, 800, 25, Color.Pink); // Mållinje

    // Skiftande ljus
    double currentTime = Raylib.GetTime();
    if (currentTime - lastChangeTime >= nextChangeTime)
    {
        GreenLight = !GreenLight; // Växla färg
        lastChangeTime = currentTime;
        nextChangeTime = random.Next(2, 3);
    }
    Color lightColor = GreenLight ? Color.Green : Color.Red;
    Raylib.DrawCircle(400, 50, 50, lightColor); // Ljus

    // Rörelsekontroller
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

    // Ser till att rektangeln stannar under cirkeln
    float rectangleX = circleX - rectangleWidth / 2;
    float rectangleY = circleY + circleRadius;

    // Ritar karaktären
    Raylib.DrawCircle((int)circleX, (int)circleY, circleRadius, Color.Yellow);
    Raylib.DrawRectangle((int)rectangleX, (int)rectangleY, (int)rectangleWidth, (int)rectangleHeight, Color.Blue);

    // Ritar kanterna så att man inte kan gå utanför mappen
    Raylib.DrawRectangle(0, 0, screenWidth, 5, Color.Beige); // Övre kant
    Raylib.DrawRectangle(0, 0, 5, screenHeight, Color.Beige); // Vänster kant
    Raylib.DrawRectangle(screenWidth - 5, 0, 5, screenHeight, Color.Beige); // Höger kant

    Raylib.DrawText("Use arrow keys to move the character", 5, 975, 20, Color.Black);

    Raylib.EndDrawing();
}