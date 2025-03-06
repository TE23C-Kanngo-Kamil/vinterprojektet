using System.Numerics;
using Raylib_cs;

/* 

Om spelaren rör sig medan lampan är röd förlorar man och skärmen blir svart och en röd text ska visas där det står "GAME OVER"
Om spelaren klarar sig fram till mållinjen vinner man och skärmen blir grön och en vit text ska visas där det står "YOU WIN"
Jag *kanske* lägger till en timer, och om spelaren inte kommer fram till mållinjen innan tiden är slut förlorar spelaren

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

bool gameOver = false;
bool gameWon = false;

// Ny variabel tidpunkten då ljuset blir rött
double redLightStartTime = 0;
double reactionTime = 0.30; 

// Spelets loop
while (Raylib.WindowShouldClose() == false)
{
    // Om spelet är över, visa slutskärmen
    if (gameOver)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawText("GAME OVER", 250, 500, 50, Color.Red);
        Raylib.EndDrawing();
        continue;
    }

    if (gameWon)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Green);
        int textWidth = Raylib.MeasureText("YOU WIN", 50);
        Raylib.DrawText("YOU WIN", (screenWidth - textWidth) / 2, (screenHeight - 50) / 2, 50, Color.White);
        Raylib.EndDrawing();
        continue;
    }

    // Skiftande ljus
    double currentTime = Raylib.GetTime();
    if (currentTime - lastChangeTime >= nextChangeTime)
    {
        GreenLight = !GreenLight; // Växla färg
        lastChangeTime = currentTime;
        nextChangeTime = random.Next(2, 3);

        // Om ljuset blir rött, spara tiden
        if (!GreenLight)
        {
            redLightStartTime = currentTime;
        }
    }

    Color lightColor = GreenLight ? Color.Green : Color.Red;
    Raylib.DrawCircle(400, 50, 50, lightColor); // Ljus

    // Rörelsekontroller
    bool isMoving = false;
    if (Raylib.IsKeyDown(KeyboardKey.Right) && (circleX + circleRadius + speed) < screenWidth)
    {
        circleX += speed;
        isMoving = true;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Left) && (circleX - circleRadius - speed) > 0)
    {
        circleX -= speed;
        isMoving = true;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Down) && (circleY + rectangleHeight + circleRadius + speed) < screenHeight)
    {
        circleY += speed;
        isMoving = true;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Up) && (circleY - circleRadius - speed) > 0)
    {
        circleY -= speed;
        isMoving = true;
    }

    // Förlora bara om spelaren rör sig efter reactionTime har passerat
    if (!GreenLight && isMoving && (currentTime - redLightStartTime > reactionTime))
    {
        gameOver = true;
    }

    // Om spelaren mår mållinjen, vinn
    if (circleY <= 150) // Mållinjen är vid y = 125
    {
        gameWon = true;
    }

    // Ritar mappen
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Beige); // Sand
    Raylib.DrawRectangle(0, 125, 800, 25, Color.Pink); // Mållinje

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