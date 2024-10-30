using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Diagnostics;

namespace MathForGames_Demo
{
    internal class Game
    {
        public void Run()
        {

            //setup for Timing
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long currentTime = 0;
            double deltaTime = 1;
            long lastTime = 0;


            Scene testScene = new Scene();
            testScene.Start();


            Raylib.InitWindow(800, 450, "raylib [core] example - basic window");

            while (!Raylib.WindowShouldClose())
            {
                currentTime = stopwatch.ElapsedMilliseconds;

;

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);
                Raylib.DrawText("Congrats! You created your first window!", 190, 200, 20, Color.Gray);
                Raylib.EndDrawing();

                deltaTime = (currentTime - lastTime) / 1000.0;
                lastTime = currentTime;
            }



            Raylib.CloseWindow();
            testScene.End();
            
        }
    }
}
