using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sharp2HW
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BaseObject[] _objArray;
       
        
        static Game(){ }


        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;


            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            Timer timer = new Timer {Interval = 100};
            timer.Start();
            timer.Tick += Timer_Tick;
        }


        /// <summary>
        /// Перебор объектов и отобразить объект
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject baseObject in _objArray)
            {
                baseObject.Draw();
            }

            Buffer.Render();
        }

        /// <summary>
        /// Изменение направления для объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject baseObject in _objArray)
            {
                baseObject.Update();
            }
        }

        /// <summary>
        /// Создание массива объектов
        /// </summary>
        public static void Load()
        {
            Buffer.Graphics.Clear(Color.Black);
            _objArray = new BaseObject[30];
            for (int i = 0; i < _objArray.Length / 2; i++)
                _objArray[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(10, 10));
            for (int i = _objArray.Length / 2; i < _objArray.Length; i++)
                _objArray[i] = new Star(new Point(600, i * 20), new Point(i, i), new Size(10, 10));
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
