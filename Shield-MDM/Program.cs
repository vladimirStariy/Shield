using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shield_MDM
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestGraphicForm());
        }
    }

    public class ButtonSettings
    {
        public static int Size = 25;
    }

    public class ArrayMdm
    {
        public static int X { get; set; }
        public static int Y { get; set; }

        public static int[,] array;
    }

    public class GrapficSettings
    {
        public static float X { get; set; }
        public static float Y { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }

    }
}
