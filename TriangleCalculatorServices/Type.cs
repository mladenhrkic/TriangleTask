using Domain.Models;
using TriangleServices.Models;

namespace TriangleServices
{
    public static class Type
    {
        public static TypeBySideResult TriangleTypeBySide(Triangle sideValues, double gamma, double alpha, double beta)
        {
            if (sideValues.SideA == sideValues.SideB && sideValues.SideB == sideValues.SideC &&
                (gamma == alpha && alpha == beta))
            {
                return new TypeBySideResult{ Id = 2, Description = "jednakostranični" };
            }
            else if ((sideValues.SideA == sideValues.SideB || sideValues.SideA == sideValues.SideC || sideValues.SideB == sideValues.SideC) &&
                (gamma == alpha || gamma == beta || alpha == beta))
            {
                return new TypeBySideResult { Id = 1, Description = "jednakokračni" };
            }
            else
            {
                return new TypeBySideResult { Id = 3, Description = "raznostranični" };
            }
        }

        public static TypeByAngleResult TriangleTypeByAngle(double gamma, double alpha, double beta)
        {
            if (gamma == 90 || alpha == 90 || beta == 90)
            {
                return new TypeByAngleResult { Id = 4, Description = "pravokutni" };
            }
            else if (gamma < 90 && alpha < 90 && beta < 90)
            {
                return new TypeByAngleResult { Id = 5, Description = "šiljastokutni" };
            }
            else if (gamma > 90 || alpha > 90 || beta > 90)
            {
                return new TypeByAngleResult { Id = 6, Description = "tupokuti" };
            }

            return new TypeByAngleResult();
        }
    }
}