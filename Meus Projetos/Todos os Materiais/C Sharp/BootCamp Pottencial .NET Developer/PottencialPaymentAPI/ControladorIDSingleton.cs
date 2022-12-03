namespace PottencialPaymentAPI

{
    public class ControladorIDSingleton
    {
        private ControladorIDSingleton()
        {

        }

        private int _idPedido = 0;

        private Mutex idPedidoMutex = new Mutex();
        public int IdPedido
        {
            get
            {
                int temp;
                idPedidoMutex.WaitOne();
                temp = _idPedido++;
                idPedidoMutex.ReleaseMutex();

                return _idPedido;
            }
        }
        private int _idVendedor = 0;

        private Mutex idVendedorMutex = new Mutex();
        public int IdVendedor
        {
            get
            {
                int temp;
                idVendedorMutex.WaitOne();
                temp = _idVendedor++;
                idVendedorMutex.ReleaseMutex();

                return temp;
            }
        }

        private static ControladorIDSingleton _instancia = null;
        private static Mutex InstanciaMutex = new Mutex();
        public static ControladorIDSingleton Instancia
        {
            get
            {
                InstanciaMutex.WaitOne();

                if (_instancia == null) _instancia = new ControladorIDSingleton();

                InstanciaMutex.ReleaseMutex();

                return _instancia;
            }
        }
    }
}