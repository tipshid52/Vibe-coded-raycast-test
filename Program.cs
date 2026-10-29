using System;
using System.Numerics;
using Raylib_cs;

internal class Program
{
    static void Main()
    {
        Raylib.InitWindow(1280, 720, "RayCasting Test");
        Raylib.SetTargetFPS(60);

        Camera3D camera = new Camera3D
        {
            Position = new Vector3(5, 4, 5),
            Target = Vector3.Zero,
            Up = Vector3.UnitY,
            FovY = 45,
            Projection = CameraProjection.Perspective
        };

        float angle = 0f;

	Color background = new(235, 235, 235, 255);
	Color cubeColor = new(160, 160, 160, 255);
	Color outlineColor = new(25, 25, 25, 255);
	Color textColor = new(45, 45, 45, 255);
        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();
            angle += dt * 0.8f;

            // Orbit the camera around the cube
            float radius = 7f;

            camera.Position = new Vector3(
                MathF.Sin(angle) * radius,
                3.5f,
                MathF.Cos(angle) * radius
            );

            Raylib.BeginDrawing();

            Raylib.ClearBackground(background);

            Raylib.BeginMode3D(camera);

            Raylib.DrawCube(
                Vector3.Zero,
                2f, 2f, 2f,
                cubeColor
            );

            Raylib.DrawCubeWires(
                Vector3.Zero,
                2f, 2f, 2f,
                outlineColor
            );

            Raylib.EndMode3D();

            Raylib.DrawText(
                "PASTEL CUBE",
                24, 24, 28,
                textColor
            );

            Raylib.DrawText(
                "Vibe coded!! dont assume i made it myself im a beginner // 3D",
                26, 60, 15,
                textColor
            );

            Raylib.DrawFPS(24, 90);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
