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
                ValidateSide(value, "Length");
                length = value;
            }
        }
        public double Width
        {
            get => width;
            private set
            {
                ValidateSide(value, "Width");
                width = value;
            }
        }
        public double Height
        {
            get => height;
            private set
            {
                ValidateSide(value, "Height");
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
        private void ValidateSide(double value, string sideName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{sideName} cannot be zero or negative.");
            }
        }
    }
}
