namespace Entities.Exceptions
{
    public class PriceOutOfRangeBadRequestException : BadRequestExceptions
    {
        public PriceOutOfRangeBadRequestException() : base("Maximum price should be less then 100 and greater then 10.")
        {
        }
    }
}
