using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarkpenDefinitivo.Data;
using MarkpenDefinitivo.Model;

namespace MarkpenDefinitivo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly Context _context;

        public PublicacionesController(Context context)
        {
            _context = context;
        }

        // GET: api/Publicaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publicacion>>> GetPublicacion()
        {
            return await _context.Publicacion.ToListAsync();
        }

        [HttpGet ("[action]")]
        public async Task<dynamic> GetPubliLugar()
        {
            //return await _context.Publicacion.ToListAsync();
            var resultado = (from Publicacion in _context.Publicacion
                             join Lugar in _context.Lugar
                             on Publicacion.idLugar equals Lugar.IdLugar
                             select new
                             {
                                 Publicacion.IdPublicacion,
                                 Publicacion.UrlImagen,
                                 Publicacion.DescripcionPublicacion,
                                 Publicacion.FechaPublicacion,
                                 Lugar.IdLugar,
                                 Lugar.DireccionLugar,
                                 Lugar.NombreLugar,
                                 Lugar.DescripcionLugar
                                 


                             }
                             );
            return resultado;



        }

        // GET: api/Publicaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publicacion>> GetPublicacion(int id)
        {
            var publicacion = await _context.Publicacion.FindAsync(id);

            if (publicacion == null)
            {
                return NotFound();
            }

            return publicacion;
        }

        // PUT: api/Publicaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicacion(int id, Publicacion publicacion)
        {
            if (id != publicacion.IdPublicacion)
            {
                return BadRequest();
            }

            _context.Entry(publicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionExists(id))
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

        // POST: api/Publicaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publicacion>> PostPublicacion(Publicacion publicacion)
        {
            _context.Publicacion.Add(publicacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublicacion", new { id = publicacion.IdPublicacion }, publicacion);
        }

        // DELETE: api/Publicaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublicacion(int id)
        {
            var publicacion = await _context.Publicacion.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }

            _context.Publicacion.Remove(publicacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicacionExists(int id)
        {
            return _context.Publicacion.Any(e => e.IdPublicacion == id);
        }
    }
}
