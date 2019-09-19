using System;
using System.Collections.Generic;
using System.Text;

namespace Class6
{
    public class Car
    {
        public event EventHandler OverSpeed;
        const int MaxSpeed = 100;

        private int speed;
        public string Plate { get; set; }

        public void IncreaseSpeed(int speed)
        {
            this.speed += speed;
            if (this.speed > MaxSpeed)
            {
                if (OverSpeed != null)
                {
                    OverSpeed(this, new EventArgs());
                }
            }
        }
    }

    public class SpeedTicket
    {
        private  Car car;

        public SpeedTicket(Car car)
        {
            this.car = car;
            this.car.OverSpeed += Car_OverSpeed;
        }

        private void Car_OverSpeed(object sender, EventArgs e)
        {
            Console.WriteLine("The car {0} overspeed", ((Car)sender).Plate);
        }
    }
}
