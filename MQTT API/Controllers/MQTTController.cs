using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MQTT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MQTTController : ControllerBase
    {
        [HttpGet]
        public string OnlineCheck()
        {
            return "Online";
        }

        //Invoked by a Form JSON
        [HttpPost]
        public Payload MQTTPost([FromForm]Payload FormData)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Payload));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, FormData);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);
            string json = sr.ReadToEnd();

            MQTT.Publish(json);//MQTT Publish

            return FormData;//Return Input Data
        }
    }
    public class Payload
    {
        public string Variable_1 { get; set; }
        public string Variable_2 { get; set; }
        public string Variable_3 { get; set; }
    }
}