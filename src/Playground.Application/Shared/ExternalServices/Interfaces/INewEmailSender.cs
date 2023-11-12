namespace BrazilianRestaurant.Application.Shared.ExternalServices.Interfaces
{
    public interface INewEmailSender
    {
        public void NewSendEmail(string email, string name, string contact, string reservationCode, string table, string date);
    }
}
