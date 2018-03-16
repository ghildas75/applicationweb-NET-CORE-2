using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Projet.Services;
using Microsoft.AspNetCore.Http;

namespace Projet.Services
{
    public static class EmailSenderExtensions
    {

        public static ISession _session;

        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {

            string MesssageReg = "Bienvenue a notre compgnie (M/Mr) "
                + _session.GetString("Nom") + "\n"
                + "Votre Numero client est: " + _session.GetInt32("NumeroClient") + ",\n"
                + "Votre courriel est: " + _session.GetString("Email") + ",\n"
                + "Votre Mot de passe est: " + _session.GetString("Password") + ".\n\n\n\n";
               

            return emailSender.SendEmailAsync(email, "Confirm your email",
                MesssageReg + $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
