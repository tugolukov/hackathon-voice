using System;
using System.Threading.Tasks;
using hackathonvoice.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace hackathonvoice.API.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IDatabaseService _database;

        public PatientsController(IDatabaseService database)
        {
            _database = database;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetPatients()
        {
            var result = await _database.GetAllPatients();
            return View(result);
        }

        [HttpGet("list/{guid}")]
        public async Task<IActionResult> GetVisits([FromRoute] Guid guid)
        {
            var patient = await _database.GetPatient(guid);
            ViewBag.patientName = patient.FullName;

            var result = await _database.GetAllVisits(guid);
            return View(result);
        }
    }
}