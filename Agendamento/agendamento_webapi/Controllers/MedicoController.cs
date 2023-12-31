﻿using agendamento_webapi.Data;
using ClassModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace agendamento_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        // Simule uma lista de médicos para este exemplo
        private readonly AppDbContext _context;

        public MedicoController(AppDbContext context)
        {
            _context = context;
        }

        // Ação GET para obter todos os médicos
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var medicos = await _context.Medicos!.ToListAsync();
            return Ok(medicos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedico(int id)
        {
            var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.IdMedico == id);

            if (medico == null)
            {
                return NotFound(); // Retorna um status 404 (Not Found) se o médico não for encontrado.
            }

            return Ok(medico); // Retorna o médico encontrado com um status 200 (OK).
        }

        // Ação POST para adicionar um médico
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MedicoModel medico)
        {
            if (medico == null)
            {
                return BadRequest();
            }

            _context.Medicos!.Add(medico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = medico.IdMedico }, medico);
        }
        // Ação PUT para editar um médico
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MedicoModel medico)
        {
            if (id != medico.IdMedico)
            {
                return BadRequest();
            }

            _context.Entry(medico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Medicos!.Any(m => m.IdMedico == id))
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
        public async Task<IActionResult> Delete(int id)
        {
            var medico = await _context.Medicos!.FindAsync(id);
            if (medico == null)
            {
                return NotFound(); 
            }

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }




    }
}
