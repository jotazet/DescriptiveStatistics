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
        public double[] Fi { get; init; }
        public string[] IntervalXi { get; init; }

        public Calculations(double[] xi)
        {
            Xi = xi;
        }
        public Calculations(double[] xi, double[] fi)
        {
            Xi = xi;
            Fi = fi;
        }
        public Calculations(string[] xi, double[] fi)
        {
            IntervalXi = xi;
            Fi = fi;
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

        public static double DiscreteWeightedArithmeticMean(double[] Xi, double[] Fi)
        {
            if (Xi == null || Xi.Length == 0)
            {
                throw new InvalidOperationException("Xi column is empty or not initialized.");
            }
            if (Fi == null || Fi.Length == 0)
            {
                throw new InvalidOperationException("Fi column is empty or not initialized.");
            }
            if (Fi.Length != Xi.Length)
            {
                throw new InvalidOperationException("Not enough data in Xi or Fi column.");
            }

            double FiSumXiSum = 0;
            double FiSum = 0;

            for (int i = 0; i < Xi.Length; i++)
            {
                FiSumXiSum += Xi[i] * Fi[i];
                FiSum += Fi[i];
            }

            if (FiSum != 0)
            {
                return FiSumXiSum / FiSum;
            }
            else
            {
                throw new InvalidOperationException("Sum of Fi cannot be zero.");
            }
        }

        public static double IntervalWeightedArithmeticMean(string[] IntervalXi, double[] Fi)
        {
            if (IntervalXi == null || IntervalXi.Length == 0)
            {
                throw new InvalidOperationException("Xi column is empty or not initialized.");
            }
            if (Fi == null || Fi.Length == 0)
            {
                throw new InvalidOperationException("Fi column is empty or not initialized.");
            }
            if (Fi.Length != IntervalXi.Length)
            {
                throw new InvalidOperationException("Not enough data in Xi or Fi column.");
            }

            double FiSumXiSum = 0;
            double FiSum = 0;
            
            for (int i = 0; i < IntervalXi.Length; i++)
            {
                var ClassLimits = IntervalXi[i].Split('-');
                if (ClassLimits.Length != 2 ||
                    !double.TryParse(ClassLimits[0], out double LowerClassLimit) ||
                    !double.TryParse(ClassLimits[1], out double UpperClassLimit))
                {
                    throw new InvalidOperationException($"Invalid interval format: {IntervalXi[i]}");
                }


                double IntervalMean = (LowerClassLimit + UpperClassLimit) / 2;

                FiSumXiSum += IntervalMean * Fi[i];
                FiSum += Fi[i];
            }

            if (FiSum != 0)
            {
                return FiSumXiSum / FiSum;
            }
            else
            {
                throw new InvalidOperationException("Sum of Fi cannot be zero.");
            }
        }
    }
}
