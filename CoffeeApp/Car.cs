﻿using System;

namespace CoffeeApp
{
    public class Car
    {
        private int speed;
        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int newSpeed)
        {
            if (newSpeed > 180) speed = 180;
            speed = newSpeed;
        }

        //private string color;
        //public string GetColor()
        //{
        //    return color;
        //}
        //public void SetColor(string vcolor)
        //{
        //    color = vcolor;
        //}

        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        //private int make;
        //public int Make
        //{
        //    get { return make; }
        //    set { make = value; }
        //}

        public int Make { get; set; }
        public Model CarModel { get; set; }

        public int Age()
        {
            return DateTime.Now.Year - Make;
        }

        public int Age2
        {
            get
            {
                return DateTime.Now.Year - Make;
            }
        }


    }

  
}



//int i = 1;
//bool b = false;
//String s = "helo";
//string s1 = "firas";
//int ii = 0;

//var x = 8;

//StringBuilder sb = new StringBuilder();



//// int x = 8;

//DateTime dt = DateTime.Now;
//int thisYear = dt.Year;

//DateTime nextYearSameDay = dt.AddYears(1);
//int nextYear = nextYearSameDay.Year;

//int nextYear2 = dt.AddYears(1).Year;