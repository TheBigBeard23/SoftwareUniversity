namespace BoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }

        public double GetSurfaceArea()
        {
            return (this.width * this.height) * 2 + (this.width * this.length) * 2 + (this.height * this.length) * 2;
        }
        public double GetLateralSurfaceArea()
        {
            return (this.width * this.height) * 2 + (this.length * this.height) * 2;
        }
        public double GetVolume()
        {
            return (this.length * this.height * this.width);
        }
    }

}
