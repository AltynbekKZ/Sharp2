using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2HW
{
    class BaseObject
    {
        protected Point Position;
        protected Point Direction;
        protected Size Size;

        public BaseObject(Point position, Point direction, Size size)
        {
            Position = position;
            Direction = direction;
            Size = size;
        }

        public void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Position.X, Position.Y, Size.Width, Size.Height);
            Game.Buffer.Render();
        }

        public void Update()
        {
            Position.X = Position.X + Direction.X;
            Position.Y = Position.Y + Direction.Y;
            if (Position.X < 0)
            {
                Direction.X = -Direction.X;
            }

            if (Position.X > Game.Width)
            {
                Direction.X = -Direction.X;
            }

            if (Position.Y < 0)
            {
                Direction.Y = -Direction.Y;
            }

            if (Position.Y > Game.Height)
            {
                Direction.Y = -Direction.Y;
            }
        }
    }
}
