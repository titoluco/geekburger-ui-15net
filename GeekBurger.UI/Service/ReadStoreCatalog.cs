using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekBurger.UI.Helper;
using GeekBurger.UI.Model;
using StoreCatalog.Contract;

namespace GeekBurger.UI.Service
{
    public class ReadStoreCatalog : IReadStoreCatalog
    {

        private readonly IShowDisplayService _showDisplayService;
        private readonly IMetodosApi _metodosApi;

        public ReadStoreCatalog(IShowDisplayService showDisplayService, IMetodosApi metodosApi)
        {
            _showDisplayService = showDisplayService;
            _metodosApi = metodosApi;
            CatalogVerify();
        }
        public void CatalogVerify()
        {

            //Ready ready = _metodosApi.retornoGet<Ready>("http://localhost:50135/Mock/api/store");


            Ready ready = _metodosApi.retornoGet<Ready>("http://geekburgerstorecatalog.azurewebsites.net/api/store");


            ShowDisplayMessage showDisplayMessage = new ShowDisplayMessage();

            showDisplayMessage.Properties = new Dictionary<String, Object>();
            showDisplayMessage.Properties.Add("ServicoEnvio", "GeekBurger.UI");


            if (ready?.IsReady == true)
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
            _showDisplayService.SendMessagesAsync(Topics.uicommand);

        }
    }
}
