using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Diagnostics;
using MathLibrary;
using System.Xml.Linq;

namespace MathForGames_Demo
{
    internal class Game
    {
        private static List<Scene> _scenes;

        private static Scene _currentScene;

        public static Scene CurrentScene
        {
            get => _currentScene;
            set
            {
                if (_currentScene != null)
                    _currentScene.End();
                _currentScene = value;
                _currentScene.Start();
            }
        }

        public Game()
        {
            _scenes = new List<Scene>();
        }

        public static void AddScene(Scene scene)
        {
            if (!_scenes.Contains(scene))
                _scenes.Add(scene);

            if (_currentScene == null)
                CurrentScene = scene;
        }

        public static Scene GetScene(int index)
        {
            if (_scenes.Count <= 0 || _scenes.Count <= index || index < 0)
                return null;

            return _scenes[index];
        }

        public static bool RemoveScene(Scene scene)
        {
            bool removed = _scenes.Remove(scene);
            if (_currentScene == scene)
                CurrentScene = GetScene(0);

            return removed;
        }

        public void Run()
        {

            //setup for Timing
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long currentTime = 0;
            double deltaTime = 1;
            long lastTime = 0;


            Raylib.InitWindow(Raylib.GetMonitorWidth(0), Raylib.GetMonitorHeight(0), "raylib [core] example - basic window");
            Raylib.ToggleFullscreen();
            Raylib.SetExitKey(KeyboardKey.Escape);

            
            Game.AddScene(new TestScene());
            Actor playerActor = new PlayerActor();
            Actor.Instantiate(playerActor);
            Component rotationComponent = new RotationComponent(playerActor);
            playerActor.AddComponent(rotationComponent);


            while (!Raylib.WindowShouldClose())
            {
                currentTime = stopwatch.ElapsedMilliseconds;



                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);


                CurrentScene.Update(deltaTime);

                



                Raylib.EndDrawing();

                deltaTime = (currentTime - lastTime) / 1000.0;
                lastTime = currentTime;
            }

            CurrentScene.End();
            
            Raylib.CloseWindow();

            
        }
    }
}
