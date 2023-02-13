namespace ConfirmCoords.App.Commands.CreateCoord
{
    public record CreatingCoordCommandResult(bool IsCreated, int? Id, string? ErrorMessage);
}
