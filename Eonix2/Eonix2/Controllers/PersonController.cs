using Data.DAO;
using Eonix2.Helpers;
using Eonix2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eonix2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly EonixContext _context;

        public PersonController(EonixContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Person>>> Get([FromQuery] string? nom, [FromQuery] string? prenom)
        {
            RequestLevel level = RequestLevelAggregator.GetRequestLevel(nom, prenom);

            List<Person> persons = level switch
            {
                RequestLevel.NoFilter =>
                    await _context.Persons.ToListAsync(),
                RequestLevel.Nom =>
                    await _context.Persons.Where(person => person.Nom.Contains(nom.ToLower())).ToListAsync(),
                RequestLevel.Prenom =>
                    await _context.Persons.Where(person => person.Prenom.Contains(prenom.ToLower())).ToListAsync(),
                RequestLevel.NomPrenom =>
                    await _context.Persons.Where(person => person.Nom.Contains(nom.ToLower())
                            && person.Prenom.Contains(prenom.ToLower())).ToListAsync(),
                _ => throw new NotImplementedException()
            };

            if (persons.Count == 0)
                return NotFound();

            return Ok(persons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Person>> Get([FromRoute] int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> Post([FromBody] Person p)
        {
            var person = new Person { Nom = p.Nom, Prenom = p.Prenom };

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Person>> Put(int id, [FromBody] Person p)
        {
            if (id != p.Id)
                return BadRequest("Not a valid Id");

            _context.Entry(p).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return BadRequest();
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            var person = _context.Persons.Find(id);

            return person != null;
        }
    }
}