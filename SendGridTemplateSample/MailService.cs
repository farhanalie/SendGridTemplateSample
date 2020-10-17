using System;
using System.IO;
using System.Net;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGridTemplateSample.Models;

namespace SendGridTemplateSample
{
    public class MailService
    {
        // Todo: Add your email id from which you will send an email
        private const string FromEmail = "noreply@yourdomain.com";
        // Todo: Add your company name 
        private const string FromName = "Your Company Name";
        // Todo: replace with your send grid api key
        private const string SendGridApiKey = "YourApiKeyHere";
        private readonly string _basePath;
        private readonly SendGridClient _client;

        public MailService()
        {
            _client = new SendGridClient(SendGridApiKey);
            _basePath = AppDomain.CurrentDomain.RelativeSearchPath ?? System.AppDomain.CurrentDomain.BaseDirectory;
        }

        public void SendSample1(Sample1Model model)
        {
            const string subject = "Sample 1";
            var template = File.ReadAllText(Path.Combine(_basePath, "Templates", "sample1.html"));

            var htmlBody = template.Replace("{{Name}}", model.Name)
                .Replace("{{ConfirmLink}}", model.ConfirmLink);

            Send(model.EmailTo, subject, htmlBody);
        }

        public void SendSample2(Sample2Model model)
        {
            const string subject = "Sample 2";
            var template = File.ReadAllText(Path.Combine(_basePath, "Templates", "sample2.html"));

            var htmlBody = template.Replace("{{ArticleName}}", model.ArticleName)
                .Replace("{{Date}}", model.Date)
                .Replace("{{Description}}", model.Description)
                .Replace("{{ImageUrl}}", model.ImageUrl)
                .Replace("{{Link}}", model.Link);

            Send(model.EmailTo, subject, htmlBody);
        }
        public void SendSample3(Sample3Model model)
        {
            const string subject = "Sample 3";
            var template = File.ReadAllText(Path.Combine(_basePath, "Templates", "sample3.html"));

            var htmlBody = template.Replace("{{c_name}}", model.SenderName)
                .Replace("{{c_transactionNumber}}", model.TransactionId)
                .
                Replace("{{c_destinationCountry}}", model.DestinationCountry)
                .Replace("{{c_receiverName}}", model.ReceiverName)
                .Replace("{{c_telephone}}", model.DestinationNumber)
                .Replace("{{c_sendingAmount}}", model.SendingAmount)
                .Replace("{{c_exchangeRate}}", model.ExchangeRate)
                .Replace("{{c_feeCharged}}", model.FeeCharged)
                .Replace("{{c_totalPaid}}", model.ChargedAmount)
                .Replace("{{c_amountReceived}}", model.CreditedAmount);

            Send(model.EmailTo, subject, htmlBody);
        }


        #region Send Grid Send Methods

        /// <summary>
        /// use this method if you have html templates in your project
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="htmlContent"></param>
        private void Send(string toEmail, string subject, string htmlContent)
        {
            try
            {
                var from = new EmailAddress(FromEmail, FromName);
                var to = new EmailAddress(toEmail);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
                var response = _client.SendEmailAsync(msg).GetAwaiter().GetResult();

                Console.WriteLine(response.StatusCode == HttpStatusCode.Accepted
                    ? "Email sent"
                    : "Failed to send Email");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Use this method if you have templates in send grid portal
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="templateId"></param>
        /// <param name="model"></param>
        private void Send(string toEmail, string subject, string templateId, object model)
        {
            try
            {
                var msg = new SendGridMessage();
                msg.SetFrom(FromEmail, FromName);
                msg.AddTo(toEmail);
                msg.SetSubject(subject);
                msg.SetTemplateId(templateId);
                msg.SetTemplateData(model);
                var response = _client.SendEmailAsync(msg).GetAwaiter().GetResult();

                Console.WriteLine(response.StatusCode == HttpStatusCode.Accepted
                    ? "Email sent"
                    : "Failed to send Email");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion


    }
}
