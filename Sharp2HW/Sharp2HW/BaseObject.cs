using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2HW
{
    /// <summary>
    /// Базовый объект
    /// </summary>
    class BaseObject
    {
        protected Point Position;
        protected Point Direction;
        protected Size Size;

        /// <summary>
        /// Создание базового объекта
        /// </summary>
        /// <param name="position">Начальная позиция</param>
        /// <param name="direction">Направление</param>
        /// <param name="size">Размер</param>
        public BaseObject(Point position, Point direction, Size size)
        {
            Position = position;
            Direction = direction;
            Size = size;
        }

        /// <summary>
        /// Метод для рисования круга
        /// </summary>
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Position.X, Position.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Обновление и изменение направления
        /// </summary>
        public virtual void Update()
        {
            Position.X = Position.X + Direction.X;
            Position.Y = Position.Y + Direction.Y;
            if (Position.X < 0) Direction.X = -Direction.X;
            if (Position.X > Game.Width) Direction.X = -Direction.X;
            if (Position.Y < 0) Direction.Y = -Direction.Y;
            if (Position.Y > Game.Height) Direction.Y = -Direction.Y;

        }
    }
}
