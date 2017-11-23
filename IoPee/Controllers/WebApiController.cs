using IoPee.Data;
using System;
using System.Linq;
using System.Web.Http;

namespace IoPee.Controllers
{
    public class WebApiController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SendNewMac(string mac)
        {
            try
            {
                if (StaticData.Macs.Where(m => m.Code == mac).ToList().Count == 0)
                    StaticData.Macs.Add(new Entities.Mac
                    {
                        Id = 0,
                        Code = mac
                    });
                else
                    return Ok("MAC already exists in database.");
            }
            catch(Exception e)
            {
                return BadRequest("An exception occurs: " + e.Message);
            }
            return Ok("MAC registered with success!");
        }

        [HttpGet]
        public IHttpActionResult SendData(string mac, int humidity)
        {
            try
            {
                var device = StaticData.Devices.Where(d => d.Mac.Code == mac && d.Mac.Id > 0).FirstOrDefault();
                
                if(device != null)
                {
                    device.Humidity = humidity;
                    device.Active = humidity >= device.Diaper.Humidity ? true : false;
                }
            }
            catch (Exception e)
            {
                return BadRequest("Data sent with success, but an exception occured: " + e.Message);
            }
            return Ok("Devices updated with success!");
        }
    }
}