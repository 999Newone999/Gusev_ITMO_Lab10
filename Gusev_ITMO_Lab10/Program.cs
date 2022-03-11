using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gusev_ITMO_Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            int buffer=0;
            Console.WriteLine("Перевод значений угла из градусов в радианы.");
            Console.WriteLine("Задаваемые значения угла в градусах должны лежать в пределах от 0 до 360.");
            Console.WriteLine("Задаваемые значения угла в минутах должны лежать в пределах от 0 до 60.");
            Console.WriteLine("Задаваемые значения угла в секундах должны лежать в пределах от 0 до 60.");

            Angle angle= new Angle();

            do
            {
                Console.Write("Введите значение градусов: ");
                try
                {
                    buffer = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                angle.Gradus = buffer;
            } while (angle.Gradus != buffer);

            do
            {
                Console.Write("Введите значение минут: ");
                try
                {
                    buffer = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                angle.Min = buffer;
            } while (angle.Min != buffer);

            do
            {
                Console.Write("Введите значение секунд: ");
                try
                {
                    buffer = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                angle.Sec = buffer;
            } while (angle.Sec != buffer);

            Console.WriteLine("Значение угла в радианах: {0}", angle.ToRadians());
            Console.ReadKey();
        }
    }

    class Angle
    {
        private int sec;
        private int min;
        private int gradus;

        public int Gradus
        {
            set 
            {
                if ((value >= 0) && (value <= 360))
                {
                    gradus = value;
                }
                else 
                {
                    Console.WriteLine("Значения градусов должны находится в пределах от 0 до 360");
                }
            }
            get
            {
                return gradus;
            }
        }


        public int Min
        {
            set
            {
                if ((value >= 0) && (value <= 60))
                {
                    min = value;
                }
                else
                {
                    Console.WriteLine("Значения градусов должны находится в пределах от 0 до 60");
                }
            }
            get
            {
                return min;
            }
        }

        public int Sec
        {
            set
            {
                if ((value >= 0) && (value <= 60))
                {
                    sec = value;
                }
                else
                {
                    Console.WriteLine("Значения градусов должны находится в пределах от 0 до 60");
                }
            }
            get
            {
                return sec;
            }
        }

        public double ToRadians()
        {
            if (((this.gradus >= 360) && (this.min > 0)) || ((this.gradus >= 360) && (this.sec > 0)))
            {
                this.gradus = 0;
            }
            if ((this.gradus == 365) && (this.min >= 59))
            {
                this.min = 0;
            }
            return (((gradus) + (min / 60) + (sec / (60 * 60))) * Math.PI / 180);
        }
    }
}
