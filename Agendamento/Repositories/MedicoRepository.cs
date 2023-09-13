/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Model;

namespace Agendamento.Repositories
{
    public class MedicoRepository
    {
         private readonly ApplicationDbContext _context;

        public MedicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Medico> GetAllMédicos()
        {
            return _context.Médicos.ToList();
        }

        public Medico GetMédicoById(int id)
        {
            return _context.Médicos.FirstOrDefault(m => m.Id == id);
        }

        public void AddMédico(Medico médico)
        {
            _context.Médicos.Add(médico);
            _context.SaveChanges();
        }

        public void UpdateMédico(Medico médico)
        {
            _context.Entry(médico).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMédico(int id)
        {
            var médico = _context.Médicos.Find(id);
            if (médico != null)
            {
                _context.Médicos.Remove(médico);
                _context.SaveChanges();
            }
        }

    }
}
*/