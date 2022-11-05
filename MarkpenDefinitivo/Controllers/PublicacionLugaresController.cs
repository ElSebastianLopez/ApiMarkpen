using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarkpenDefinitivo.Data;
using MarkpenDefinitivo.Model;
using MarkpenDefinitivo.Adicionales;

namespace MarkpenDefinitivo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionLugaresController : ControllerBase
    {
        private readonly Context _context;

        public PublicacionLugaresController(Context context)
        {
            _context = context;
        }

        // GET: api/PublicacionLugares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicacionLugares>>> GetPublicacionLugares()
        {
            return await _context.PublicacionLugares.ToListAsync();
        }

        // GET: api/PublicacionLugares/5
        [HttpGet("porId/{id}")]
        public async Task<ActionResult<PublicacionLugares>> GetPublicacionLugares(int id)
        {
            var publicacionLugares = await _context.PublicacionLugares.FindAsync(id);

            if (publicacionLugares == null)
            {
                return NotFound();
            }

            return publicacionLugares;
        }

        // PUT: api/PublicacionLugares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicacionLugares(int id, PublicacionLugares publicacionLugares)
        {
            if (id != publicacionLugares.idPublicacionLugares)
            {
                return BadRequest();
            }

            _context.Entry(publicacionLugares).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionLugaresExists(id))
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

        // POST: api/PublicacionLugares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<dynamic> PostPublicacionLugares(PublicacionLugares publicacionLugares)
        {
            publicacionLugares.FechaPublicacion = DateTime.Now;
            _context.PublicacionLugares.Add(publicacionLugares);
            var nuevo= await _context.SaveChangesAsync();

            if (nuevo!=0)
            {
                return new { result = "Registro Creado Correctamente " };
            }
            return new { result = "no se a podido crear el registro" };


            //return CreatedAtAction("GetPublicacionLugares", new { id = publicacionLugares.idPublicacionLugares }, publicacionLugares);
        }

        // DELETE: api/PublicacionLugares/5
        [HttpPost("[action]")]
        public async Task<dynamic> DeletePublicacionLugares(GetPublicaLugar lugar1)
        {
           
            var lugar = await _context.PublicacionLugares.FindAsync(lugar1.idPublicacionLugares);

            if (lugar == null)
            {
                return new { result = "No se pudo eliminar" };
            }

            _context.PublicacionLugares.Remove(lugar);
            await _context.SaveChangesAsync();

            return new { result = "Borrado correctamente" };
        }

        private bool PublicacionLugaresExists(int id)
        {
            return _context.PublicacionLugares.Any(e => e.idPublicacionLugares == id);
        }
    }
}
