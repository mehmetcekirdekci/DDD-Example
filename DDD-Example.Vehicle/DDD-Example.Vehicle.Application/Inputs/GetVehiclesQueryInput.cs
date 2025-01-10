using DDD_Example.Vehicle.Application.Outputs;
using MediatR;

namespace DDD_Example.Vehicle.Application.Inputs;

public class GetVehiclesQueryInput : IRequest<GetVehiclesQueryOutput>;