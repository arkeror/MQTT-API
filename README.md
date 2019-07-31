# MQTT API
 Using ASP .Net Core as an API to transmit MQTT Messages using AWS as a broker.


# Setup
To get this API to work, you will need to set your MQTT client in the "MQTT API/MQTT.cs" file.
 1. Configure the "IotEndPoint" string to your AWS REST API Endpoint (AWS IoT Core)
 2. Specify the location of the AWS root certificate at line 18 of MQTT.cs
 3. Create a .pfx file using your device certificate and private key and specify the location at line 19 of MQTT.cs
 4. Configure the MQTT Topic you would like your message to be sent to at line 30 and 37
