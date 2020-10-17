using System;
using SendGridTemplateSample.Models;

namespace SendGridTemplateSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailService = new MailService();

            var sample1 = new Sample1Model
            {
                EmailTo = "farhan.ali.aqu@gmail.com",
                Name = "Farhan",
                ConfirmLink = "https://example.com/registration/123"
            };

            mailService.SendSample1(sample1);

            var sample2 = new Sample2Model
            {
                EmailTo = "farhan.ali.aqu@gmail.com",
                ArticleName = "Tips For Winter Season",
                Date = "FEB 18, 2019",
                Description = "A small river named Duden flows by their place and supplies it with the necessary regelialia.",
                ImageUrl = "https://colorlib.com/etc/email-template/7/images/work-4.jpg",
                Link = "https://example.com/registrat/articleion/123",

            };

            mailService.SendSample2(sample2);
            var sample3 = new Sample3Model
            {
                EmailTo = "farhan.ali.aqu@gmail.com",
                DestinationNumber = "+254634077666",
                ReceiverName = "Mohammed Ali",
                DestinationCountry = "Kenya",
                CreditedAmount = "50000 KES",
                TransactionId = "HS-1DJ74GK3T",
                SenderName = "Farhan Ali",
                SendingAmount = "5000 SEK",
                ExchangeRate = "1 SEK = 9.8927 KES",
                FeeCharged = "100 SEK",
                ChargedAmount = "50100 SEK",
            };

            mailService.SendSample3(sample3);


            Console.ReadLine();
        }
    }
}
