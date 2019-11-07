using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.UI.Model;
using StoreCatalog.Contract;

namespace GeekBurger.UI.Service
{
    public class ReadStoreCatalog
    {

        private readonly IShowDisplayService _showDisplayService;


        public ReadStoreCatalog(IShowDisplayService showDisplayService)
        {
            _showDisplayService = showDisplayService;
        }
        public void CatalogVerify()
        {

            //Ready ready = MetodosApi.retornoGet<Ready>("http://localhost:50135/Mock/api/store");
            Ready ready = MetodosApi.retornoGet<Ready>("http://geekburgerstorecatalog.azurewebsites.net/api/store");



        
            ShowDisplayMessage showDisplayMessage = new ShowDisplayMessage();

            showDisplayMessage.Properties = new Dictionary<String, Object>();
            showDisplayMessage.Properties.Add("ServicoEnvio", "GeekBurger.UI");


            if ((bool)ready?.IsReady)
            {
                showDisplayMessage.Label = "showwelcomepage";
                showDisplayMessage.Body = "Exibir página de boas vindas";                
            }
            else
            {
                showDisplayMessage.Label = "storeunavailable";
                showDisplayMessage.Body = "Catálogo não disponível";
            }

            _showDisplayService.AddMessage(showDisplayMessage);
            _showDisplayService.SendMessagesAsync();

        }
    }
}
