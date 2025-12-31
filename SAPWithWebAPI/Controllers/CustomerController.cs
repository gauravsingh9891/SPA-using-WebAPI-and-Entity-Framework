using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SAPWithWebAPI.Models;
using System.Data.Entity;
using System.Web.Http.Cors;

namespace SAPWithWebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class CustomerController : ApiController
    {
        MVCDBEntities dc = new MVCDBEntities();

        //GET Request (It will show all customer records)
        public List<Customer> Get()
        {
            return dc.Customers.ToList();
        }

        //GET Request (It will show a customer record based on customer id passed)
        public Customer Get(int id)
        {
            return dc.Customers.Find(id);
        }

        //POST Request (It will insert the record)
        public HttpResponseMessage Post(Customer C)
        {
            try
            {
                C.Status = true;
                dc.Customers.Add(C);
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created); //201 status code if record is inserted
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError); //500 status code if any exception occured.
            }
        }

        //PUT Request (It will perform Update operation in customer record based on Customer id)
        public HttpResponseMessage Put(Customer C)
        {
            try
            {
                Customer obj = dc.Customers.Find(C.Custid);
                if(obj==null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);    //404 Status code
                }
                obj.Name = C.Name;
                obj.Balance = C.Balance;
                obj.City = C.City;
                dc.Entry(obj).State = EntityState.Modified;
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);  //200 Status code
            }
            catch(Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        //DELETE REquest (It will perform Delete Operation)
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Customer obj = dc.Customers.Find(id);
                if(obj==null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                obj.Status = false;
                dc.Entry(obj).State = EntityState.Modified;
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch(Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
    }
}
