namespace ConfirmCoords.Domain.Errors
{
    public static class GetCoordErrors
    {
        public static string IdRequired => "Id is required.";

        public static string IdNegative => "Negative coord id.";
    }
}
