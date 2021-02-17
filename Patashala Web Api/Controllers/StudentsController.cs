using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Patashala_Web_Api.DTO;
using Patashala_Web_Api.Models;
using Patashala_Web_Api.PatashalaGlobalRepository;

namespace Patashala_Web_Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
    {
        private PatashalaUnitOfWork db = new PatashalaUnitOfWork();

        // GET: api/Students
        public IHttpActionResult Get_Students()
        {
            var Student = db.StudentRepository.Get().Select(i => new StudentsDTO
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                DOB = i.DOB,
                IdentityNumber = i.IdentityNumber,
                IdentityType = (DTO.IdentityType)i.IdentityType,
                DOE = i.DOE,
                Class = i.Class
            });
            return Ok(Student.ToList());
        }

        /// <summary>
        /// Get All Students Details along with Address
        /// https://{{Host}}/api/Student/entity/entityName
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        // GET: api/Students with filter orderby entity

        [Route("{entity:EntityConstraint}")]
        public IHttpActionResult Get_StudentsAddress(string entity)
        {
            var Student = db.StudentRepository.Get(includeProperties: entity);
            return Ok(Student.ToList());
        }

        // GET: api/Students/5
        [Route("{id:int}")]
        [ResponseType(typeof(Students))]
        public IHttpActionResult Get_Students(int id)
        {
            Students students =  db.StudentRepository.GetByID(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put_Students(int id, Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != students.Id)
            {
                return BadRequest();
            }

            db.StudentRepository.Update(students);

            try
            {
                 db.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Students))]
        public IHttpActionResult Post_Students(Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentRepository.Insert(students);
            db.Save();

            return CreatedAtRoute("DefaultApi", new { id = students.Id }, students);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Students))]
        public IHttpActionResult Delete_Students(int id)
        {
            Students students = db.StudentRepository.GetByID(id);
            if (students == null)
            {
                return NotFound();
            }

            db.StudentRepository.Delete(id);
            db.Save();

            return Ok(students);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentsExists(int id)
        {
            return db.StudentRepository.Get().Any(e => e.Id == id);
        }
    }
}