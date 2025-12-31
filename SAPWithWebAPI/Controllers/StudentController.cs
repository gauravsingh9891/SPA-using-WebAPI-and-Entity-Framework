using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SAPWithWebAPI.Models;
using System.Data.Entity;

namespace SAPWithWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        MVCDBEntities dc = new MVCDBEntities();

        //GET Request (SELECT operation performed to display all students records)
        public List<Student> Get()
        {
            return dc.Students.ToList();
        }

        //GET Request (SELECT operation performed to display single student details based on Id passed)
        public Student Get(int Id)
        {
            return dc.Students.Find(Id);
        }

        //POST Request (INSERT operation performed to add a new student record)
        public HttpResponseMessage Post(Student student)
        {
            try
            {
                student.Status = true;
                dc.Students.Add(student);
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);     //201 Created (Record is inserted)
            }
            catch(Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);    //500 Internal Server Error
            }
        }
    
        //PUT Request (UPDATE operation performed on customer record)
        public HttpResponseMessage Put(Student student)
        {
            try
            {
                Student obj = dc.Students.Find(student.Id);
                if (obj == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);    //404 Not Found (If Student id is not exsist)
                }
                obj.Name = student.Name;
                obj.Photo = student.Photo;
                obj.Status = true;
                dc.Entry(obj).State = EntityState.Modified;
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);      //200 Success (Record is updated)
            }
            catch(Exception)
            {
                throw new HttpResponseException(HttpStatusCode.OK); //200 Ok (Record is updated)
            }
        }

        //DELETE Request (DELETE operation performed to delete customer record)
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                Student obj = dc.Students.Find(Id);
                if (obj == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                obj.Status = false;
                dc.Entry(obj).State= EntityState.Modified;
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
