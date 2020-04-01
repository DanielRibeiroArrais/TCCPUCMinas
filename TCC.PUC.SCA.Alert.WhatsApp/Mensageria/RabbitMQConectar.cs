using RabbitMQ.Client;
using System;
using System.Configuration;

namespace TCC.PUC.SCA.Alert.WhatsApp.Mensageria
{
    public class RabbitMQConectar
    {
        public abstract class RabbitMQBase : IDisposable
        {
            private static volatile IConnection _connection;
            private static readonly object ConnectionLock = new object();

            protected IConnection Connection
            {
                get
                {
                    if (_connection != null)
                        return _connection;
                    lock (ConnectionLock)
                    {
                        if (_connection != null)
                            return _connection;

                        var connectionFactory = new ConnectionFactory
                        {
                            UserName = ConfigurationManager.AppSettings["RabbitMQUserName"],
                            Password = ConfigurationManager.AppSettings["RabbitMQPassword"],
                            HostName = ConfigurationManager.AppSettings["RabbitMQHostName"],
                            AutomaticRecoveryEnabled = true,
                            RequestedConnectionTimeout = 60000000
                        };

                        _connection = connectionFactory.CreateConnection();

                    }

                    return _connection;
                }
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!disposing)
                    return;
                if (_connection == null)
                    return;
                lock (ConnectionLock)
                {
                    if (_connection == null)
                        return;

                    _connection?.Dispose();
                    _connection = null;
                }
            }
        }
    }
}
