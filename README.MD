


publicado: http://geekburger-ui-15net.azurewebsites.net/
github: https://github.com/titoluco/geekburger-ui-15net

namespace GeekBurger.UI.Service

Class ReadStoreCatalog 
void CatalogVerify()
//Utilizado para buscar o catálogo quando o serviço sobre

Class ShowDisplayService
void SendMessagesAsync(Topics topic);
void AddToMessageList(IEnumerable<EntityEntry<FaceModel>> changes)
void AddMessage(ShowDisplayMessage showDisplayMessage)
//metodos responsáveis pela publicação da mensagem no service bus (topics newOrder e uicommand)
		
		
Class ReceiveMessagesService		
Task HandleStoreCatalogReady(Message message, CancellationToken arg2)
//método que escuta o subscriber UI do topics StoreCatalogReady

Task HandleUserRetrieved(Message message, CancellationToken arg2)
//método que escuta o subscriber UI do topics UserRetrieved