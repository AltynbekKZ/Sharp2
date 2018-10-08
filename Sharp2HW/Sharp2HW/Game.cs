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
        public static BaseObject[] _objects;
       
        
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



        public static void Draw()
        {
            
            foreach (BaseObject baseObject in _objects)
            {
                baseObject.Draw();
            }

            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject baseObject in _objects)
            {
                baseObject.Update();
            }
        }

        public static void Load()
        {
            Buffer.Graphics.Clear(Color.Black);
            _objects = new BaseObject[30];
            for (int i = 0; i < _objects.Length; i++)
            {
                _objects[i] = new BaseObject(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
