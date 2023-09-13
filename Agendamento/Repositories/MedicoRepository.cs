using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Model;
using Agendamento.Data;
using Microsoft.EntityFrameworkCore;
namespace Agendamento.Repositories
{
    public class MedicoRepository
    {
         private readonly AppDbContext _context;

        public MedicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Medico> GetAllMedicos()
        {
            return _context.Medicos.ToList();
        }

        public Medico GetMedicoById(int id)
        {
            return _context.Medicos.FirstOrDefault(m => m.IdMedico == id);
        }

        public void AddMedico(Medico médico)
        {
            _context.Medicos.Add(médico);
            _context.SaveChanges();
        }

        public void UpdateMedico(Medico médico)
        {
            _context.Entry(médico).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMedico(int id)
        {
            var médico = _context.Medicos.Find(id);
            if (médico != null)
            {
                _context.Medicos.Remove(médico);
                _context.SaveChanges();
            }
        }

    }

}
