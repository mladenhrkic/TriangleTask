using Domain.Models;

namespace TriangleServices
{
    public static class Calculate
    {
        public static double Perimeter(Triangle sideValues)
        {
            return Math.Round(sideValues.SideA + sideValues.SideB + sideValues.SideC, 2);
        }

        public static double Area(Triangle sideValues, double gamma)
        {
            var radians = gamma * Math.PI / 180;
            var sin = Math.Sin(radians);

            return Math.Round((sideValues.SideA * sideValues.SideB * sin) / 2, 2);
        }

        public static double GammaAngle(Triangle sideValues)
        {
            var a = Math.Round(Math.Pow(sideValues.SideA, 2), 2);
            var b = Math.Round(Math.Pow(sideValues.SideB, 2), 2);
            var c = Math.Round(Math.Pow(sideValues.SideC, 2), 2);

            var numerator = Math.Round(a + b - c, 2);
            var denominator = Math.Round(2 * sideValues.SideA * sideValues.SideB, 2);

            return GetDegree(numerator, denominator);
        }

        public static double AlphaAngle(Triangle sideValues)
        {
            var a = Math.Round(Math.Pow(sideValues.SideA, 2), 2);
            var b = Math.Round(Math.Pow(sideValues.SideB, 2), 2);
            var c = Math.Round(Math.Pow(sideValues.SideC, 2), 2);

            var numerator = Math.Round(b + c - a, 2);
            var denominator = Math.Round(2 * sideValues.SideB * sideValues.SideC, 2);

            return GetDegree(numerator, denominator);
        }

        public static double BetaAngle(double alpha, double gamma)
        {
            return Math.Round(180 - alpha - gamma, 2);
        }

        private static double GetDegree(double numerator, double denominator)
        {
            var gamma = Math.Round(numerator / denominator, 2);
            var result = Math.Acos(gamma);

            return Math.Round((180 / Math.PI) * result, 2);
        }
    }
}