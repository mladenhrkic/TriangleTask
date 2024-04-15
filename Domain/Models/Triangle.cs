namespace Domain.Models
{
    public class Triangle
    {
        public int TriangleId { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public double GammaAngle { get; set; }
        public double AlphaAngle { get; set; }
        public double BetaAngle { get; set; }
        public double Perimeter { get; set; }
        public double Area { get; set; }
        public string? UserId { get; set; }
        public string? TriangleBySide { get; set; }
        public string? TriangleByAngle { get; set; }
        public string? Image { get; set; }
        public string? Image_2 { get; set; }
    }
}
