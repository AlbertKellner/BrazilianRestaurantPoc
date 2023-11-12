using System.Net;
using System.Net.Mail;
using BrazilianRestaurant.Application.Shared.ExternalServices.Interfaces;

namespace BrazilianRestaurant.Application.Shared.ExternalServices
{
    public class NewEmailSender : INewEmailSender
    {
        const string userName = "brazilian.restaurant.poc@gmail.com";
        const string password = "zjlp lqmu frvw uhou";

        public void NewSendEmail(string email, string name, string contact, string reservationCode, string table, string date)
        {
            var fromAddress = new MailAddress(userName, "Brazilian Restaurant");
            var toAddress = new MailAddress(email, name);
            const string subject = "Reservation Confirmation";
            string body = $"Dear {name},\n\nYour reservation is confirmed.\nContact: {contact}\nReservation Code: {reservationCode}\nTable: {table}\nDate: {date}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, password)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
