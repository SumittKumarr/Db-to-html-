using FromDatabaseToTemplate.DAL.Repository.Interfaces;
using FromDatabaseToTemplate.Entities;
using FromDatabaseToTemplate.Extention.cs;
using PuppeteerSharp;
using System.Collections.Generic;
using System.Reflection;

namespace FromDatabaseToTemplate.Services.Implementations
{
    public class UserServices : Interfaces.IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> GetUser(string policyNumber, string productCode)
        {

            var userDetail = await _userRepository.GetUserDetailsByPolicyNoAndProductCode(policyNumber, productCode);
            if (userDetail == null)
                throw new Exception("Enter valid policy number or product code");

           
            


            var code = "User Template";
            Template userTemplate = await _userRepository.GetTemplateFromDatabaseAsync(code);

            string htmlContent = userTemplate.Content.FillDataInHtmlTemplateForOneUser(userDetail);

            GeneratePdf(htmlContent);
            return htmlContent;
           
        }

        public async Task<string> GetUsers()
        {
            var usersList = await _userRepository.GetUsers();
 
            var code = "User Template";
            Template userTemplate = await _userRepository.GetTemplateFromDatabaseAsync(code);



            string htmlContent = userTemplate.Content.FillDataInHtmlTemplateForMultipleUsers(usersList);

            GeneratePdf(htmlContent);
            return htmlContent;           
        }

        private async void GeneratePdf(string content)
        {

            string currentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync(BrowserFetcher.DefaultRevision);
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            await using var page = await browser.NewPageAsync();
            await page.SetContentAsync(content);
            await page.PdfAsync(currentPath + "\\page1.pdf");

        }

    }
}
