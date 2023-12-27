using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UniversityApi.Controllers;

    [Route("api/Universities")]
    [ApiController]
    public class UniversitysController : ControllerBase
    {
        private readonly List<University> _Universitys = new List<University>
        {
            new University { Id = 1, Name = "Harvard University", City="Cambridge", Country="United States America", foundedDate=1636, SuccesOrder=4},
            new University { Id = 2, Name = "Massachusetts Institute of Technology", City="Cambridge", Country="United States America", foundedDate=1861, SuccesOrder=1},
            new University { Id = 3, Name = "University of Cambridge", City="Cambridge", Country="Great Britain", foundedDate=1209, SuccesOrder=2},
            new University { Id = 4, Name = "Boğaziçi University", City="Istanbul", Country="Turkey", foundedDate=1863, SuccesOrder=186},
            new University { Id = 5, Name = "National University of Singapore", City="Singapore", Country="Singapore", foundedDate=1980, SuccesOrder=8},
        };

        // Tüm ürünleri getir
        [HttpGet]
        public ActionResult<IEnumerable<University>> Get()
        {
            return Ok(_Universitys);
        }

        // Belirli bir ürünü getir
        [HttpGet("{id}")]
        public ActionResult<University> Get(int id)
        {
            var University = _Universitys.Find(p => p.Id == id);
            if (University == null)
            {
                return NotFound(); // Ürün bulunamazsa 404 döndür
            }
            return Ok(University);
        }

        // Yeni bir ürün oluştur
        [HttpPost]
        public IActionResult Post(University University)
        {
            _Universitys.Add(University);
            return CreatedAtAction(nameof(Get), new { id = University.Id }, University);
        }

        // Bir ürünü güncelle
        [HttpPut("{id}")]
        public IActionResult Put(int id, University University)
        {
            var existingUniversity = _Universitys.Find(p => p.Id == id);
            if (existingUniversity == null)
            {
                return NotFound();
            }
            existingUniversity.Name = University.Name;
            existingUniversity.SuccesOrder = University.SuccesOrder;
            return NoContent();
        }

        // Bir ürünü sil
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var University = _Universitys.Find(p => p.Id == id);
            if (University == null)
            {
                return NotFound();
            }
            _Universitys.Remove(University);
            return NoContent();
        }
    }

