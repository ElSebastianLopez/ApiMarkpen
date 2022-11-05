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
    public class LugaresController : ControllerBase
    {
        private readonly Context _context;

        public LugaresController(Context context)
        {
            _context = context;
        }

        // GET: api/Lugares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lugar>>> GetLugar()
        {
            return await _context.Lugar.ToListAsync();
        }

        // GET: api/Lugares/5
        [HttpPost("[action]")]
        public async Task<dynamic> GetLugar(string idd)
        {
            var id = Int32.Parse(idd);
            var lugar = await _context.Lugar.FindAsync(id);
           

            if (lugar == null)
            {
                return new {result="No se encontro el id"};
            }

            return new { result = "encontre algo",Lugar=lugar.NombreLugar }; 
        }

        // PUT: api/Lugares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLugar(int id, Lugar lugar)
        {
            if (id != lugar.IdLugar)
            {
                return BadRequest();
            }

            _context.Entry(lugar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LugarExists(id))
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

        // POST: api/Lugares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lugar>> PostLugar(Lugar lugar)
        {
            _context.Lugar.Add(lugar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLugar", new { id = lugar.IdLugar }, lugar);
        }

        // DELETE: api/Lugares/5
        [HttpPost("[action]")]
        public async Task<dynamic> DeleteLugar(GetLugar lugar1)
        {
            var id = Int32.Parse(lugar1.IdLugar);
            var lugar = await _context.Lugar.FindAsync(id);
            if (lugar == null)
            {
                return new {result="No se pudo eliminar"};
            }

            _context.Lugar.Remove(lugar);
            await _context.SaveChangesAsync();

            return new { result = "Borrado correctamente" };
        }

        private bool LugarExists(int id)
        {
            return _context.Lugar.Any(e => e.IdLugar == id);
        }
    }
}
