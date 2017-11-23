
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
                if (ModelData.Macs.Where(m => m.Code == mac).ToList().Count == 0)
                    ModelData.Macs.Add(new Entities.Mac
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
            return Ok("MAC sent with success!");
        }

        [HttpGet]
        public IHttpActionResult SendData(string mac, int humidity, int active)
        {
            try
            {
                if (ModelData.Macs.Where(m => m.Code == mac).ToList().Count == 0)
                    ModelData.Macs.Add(new Entities.Mac
                    {
                        Id = 0,
                        Code = mac
                    });
                else
                    return Ok("MAC already exists in database.");
            }
            catch (Exception e)
            {
                return BadRequest("An exception occurs: " + e.Message);
            }
            return Ok("MAC sent with success!");
        }
    }
}