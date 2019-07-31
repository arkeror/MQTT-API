using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace MQTT_API
{
    public class MQTT
    {
        private static MqttClient IotClient;

        public static void Init()
        {
            string IotEndPoint = "*********-ats.iot.us-east-2.amazonaws.com"; //AWS Endpoint
            X509Certificate CaCert = X509Certificate.CreateFromCertFile(@"C:\Location\root-CA.crt"); //Directory of AWS Root Certificate
            X509Certificate ClientCert = new X509Certificate2(@"C:\Location\Cert.pfx", "PasswordOfPFXFile"); //Directory of Device Certificate in pfx format and password for the pfx file

            string ClientId = Guid.NewGuid().ToString();
            IotClient = new MqttClient(IotEndPoint, 8883, true, CaCert, ClientCert, MqttSslProtocols.TLSv1_2);
            IotClient.Connect(ClientId);
            //while (!IotClient.IsConnected) { }
        }

        //Default Message when no message is specified 
        public static void Publish()
        {
            string Topic = "***************"; //MQTT Topic
            string Message = "****"; //Message
            IotClient.Publish(Topic, Encoding.UTF8.GetBytes(Message));
        }

        public static void Publish(string Message)
        {
            string Topic = "***************"; //MQTT Topic
            IotClient.Publish(Topic, Encoding.UTF8.GetBytes(Message));
        }
    }
}
