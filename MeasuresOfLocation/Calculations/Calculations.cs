using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuresOfLocation.Calculations
{
    class Calculations
    {
        public double[] Xi { get; init; }

        public Calculations(double[] xi)
        {
            Xi = xi;
        }

        public static double ArithmeticMean(double[] Xi)
        {
            if (Xi == null || Xi.Length == 0)
            {
                throw new InvalidOperationException("Xi column is empty or not initialized.");
            }
                
            double sum = 0;
            foreach (var value in Xi)
            {
                sum += value;
            }
            return sum / Xi.Length;
        }
    }
}
