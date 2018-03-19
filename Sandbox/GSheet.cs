using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sandbox
{
    class GSheet
    {
        UserCredential credential;
        SheetsService service;
        string sheetId = "1jquubXWVirAV0NEKCQ2T3He1xOPYsTfG8iK1myuIwfI";

        public ValueRange Get(string src)
        {
            return service.Spreadsheets.Values.Get(sheetId, src).Execute();
        }

        public GSheet()
        {
            LoadCredential();
            InitService();
        }

        void LoadCredential()
        {

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                //string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                //credPath = Path.Combine(credPath, ".credentials/magus.json");
                string credPath = ".credentials/magus.json";

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new string[] { SheetsService.Scope.SpreadsheetsReadonly },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
        }

        void InitService()
        {
            // Create Google Sheets API service.
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "magus"
            });
        }
    }
}
