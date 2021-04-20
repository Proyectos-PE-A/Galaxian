using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaskanoidGame.model
{
    public class Raskanoid
    {
        private Rectangle Bala;
        private Rectangle Player;
        private bool Started;
        private int dx;
        private int dy;
        private int xBala;
        private int yBala;

        //hola OwO 

        private List<Rectangle> Bricks;

        private int Width { set; get; }
        private int Height { set; get; }





        public Raskanoid(int width, int height)
        {
            Width = width;
            Height = height;

            Player = new Rectangle(100, 100, 20, 20);


            Initialize();
            
        }

        private void Initialize()
        {
            Started = false;
            dx = -1;
            dy = -1;
            xBala = Player.X;
            yBala = 650;

            Player = new Rectangle(0, 500, 100, 20);
            Bala = new Rectangle(Width / 2, Player.Y - 20, 20, 20);

            Bricks = new List<Rectangle>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Bricks.Add(new Rectangle(100 + 105 * i, 50 + 25 * j, 100, 20));
                }
            }


        }

        public void Start()
        {
            Started = true;
        }

        public void Paint(Graphics dc)
        {
            dc.FillRectangle(System.Drawing.Brushes.White, Player.X, Player.Y, 15, 30);
            dc.FillRectangle(System.Drawing.Brushes.Red, xBala, yBala,15,30);



            foreach (Rectangle brick in Bricks)
            {
                dc.FillRectangle(System.Drawing.Brushes.White, brick.Parse());

            }
        }
        
        public void Update(Point mouseLocation, int deltaTime, bool LeftKey, bool RightKey, bool SpaceKey)
        {
            Console.WriteLine(deltaTime);

            //UpdatePad(mouseLocation);

            if (LeftKey)
            {
                Player.X -= deltaTime;
                xBala -= deltaTime;
            }

            if (RightKey)
            {
                Player.X += deltaTime;
                xBala -= deltaTime;
            }
            Player.Y = 500;


            if (Player.X <= -10)
            {
                Player.X += deltaTime;
            }
            else if (Player.X + 15 > Width)
            {
                Player.X -= deltaTime;
            }
            if (SpaceKey)
            {
                BalaUpdate(yBala, deltaTime);
            }





            UpdateBricks();

        }
        private void BalaUpdate(int yBala, int deltaTime)
        {
            Bala.Y -= deltaTime;

        }
        private void UpdateBricks()
        {
            List<Rectangle> toRemove = new List<Rectangle>();
            foreach (Rectangle brick in Bricks)
            {
                if (Bala.Intersects(brick))
                {
                    toRemove.Add(brick);
                }
            }

            foreach (Rectangle brick in toRemove)
            {
                Bricks.Remove(brick);
            }

        }


       

        
        
            
        

    }
}
