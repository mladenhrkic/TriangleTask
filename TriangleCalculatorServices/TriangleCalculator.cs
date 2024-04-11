using Application.Categories.Queries;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace TriangleServices
{
    public class TriangleCalculator : ITriangleCalculator
    {
        private readonly IMediator _mediator;
        private readonly GetAllImages _getAllImages;

        public TriangleCalculator(IMediator mediator)
        {
            _mediator = mediator;
            _getAllImages = new GetAllImages();
        }

        public async Task<Triangle> Result(Triangle sideValues)
        {
            var perimeter = Calculate.Perimeter(sideValues);
            var gamma = Calculate.GammaAngle(sideValues);
            var alpha = Calculate.AlphaAngle(sideValues);
            var beta = Calculate.BetaAngle(alpha, gamma);
            var area = Calculate.Area(sideValues, gamma);
            var triangleBySide = Type.TriangleTypeBySide(sideValues, gamma, alpha, beta);
            var triangleByAngle = Type.TriangleTypeByAngle(gamma, alpha, beta);

            var result = await _mediator.Send(_getAllImages);

            var bySide = result.FirstOrDefault(x => x.Id == triangleBySide.Id);
            var byAngle = result.FirstOrDefault(x => x.Id == triangleByAngle.Id);

            sideValues.Perimeter = perimeter;
            sideValues.GammaAngle = gamma;
            sideValues.AlphaAngle = alpha;
            sideValues.BetaAngle = beta;
            sideValues.Area = area;
            sideValues.TriangleBySide = triangleBySide.Description;
            sideValues.TriangleByAngle = triangleByAngle.Description;
            sideValues.Image = bySide.Image;
            sideValues.Image_2 = byAngle.Image;

            return sideValues;
        }
    }
}