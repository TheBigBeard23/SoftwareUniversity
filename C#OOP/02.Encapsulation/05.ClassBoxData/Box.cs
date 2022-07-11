using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public double GetSurfaceArea()
        {
            return 2 * (Width * Height + Length * Height + Width * Length);
        }
        public double GetLateralSurfaceArea()
        {
            return 2 * (Width * Height + Length * Height);
        }
        public double GetVolume()
        {
            return Width * Length * Height;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {GetSurfaceArea():F2}");
            sb.AppendLine($"Lateral Surface Area - {GetLateralSurfaceArea():F2}");
            sb.AppendLine($"Volume - {GetVolume():F2}");

            return sb.ToString().TrimEnd();
        }
    }
}
