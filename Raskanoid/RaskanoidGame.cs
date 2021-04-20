﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using uEngine;

using RaskanoidGame.model;



namespace RaskanoidGame
{
    class RaskanoidGame : uGame
    {
        private Raskanoid Model;

        private Point MouseLocation;
        private int MouseButton;

        private bool LeftKey;
        private bool RightKey;
        private bool SpaceKey;

        public RaskanoidGame(int width, int height, int targetFPS) : base(width, height, targetFPS)
        {
            Model = new model.Raskanoid(width, height);
            MouseButton = -1;

            LeftKey = false;
            RightKey = false;
            SpaceKey = false;
        }

        public override void GameUpdate()
        {
            Model.Update(MouseLocation, (int)DeltaTime, LeftKey, RightKey,SpaceKey);
            if( MouseButton == 1 )
            {
                Model.Start();
            }
        }

        public override void ProcessInput()
        {
            MouseLocation = InputManager.MouseLocation();
            MouseButton = InputManager.MouseButton();

            LeftKey = InputManager.IsKeyPressed("Left");
            RightKey = InputManager.IsKeyPressed("Right");
            SpaceKey = InputManager.IsKeyPressed("Space");
            SpaceKey = InputManager.IsKeyPressed("peo");

        }

        public override void Render(Graphics dc)
        {
            Model.Paint(dc);
        }
    }
}
