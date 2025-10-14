using Domain.Model;
using Data;
using DTOs;

namespace Application.Services
{
    public class PlanService
    {
        public PlanDTO Add(PlanDTO dto)
        {
            var repo = new PlanRepository();

            var plan = new Plan(dto.DescPlan, dto.IDEspecialidad);
            repo.Add(plan);

            dto.IDPlan = plan.IDPlan;
            return dto;
        }

        public bool Delete(int id)
        {
            var planRepository = new PlanRepository();
            var comiRepo = new ComisionRepository();
            var comisionesAsociadas = comiRepo.GetByPlan(id);
            if (comisionesAsociadas.Any())
            {
                throw new InvalidOperationException("No se puede eliminar el plan porque tiene comisiones asociadas.");
            }
            return planRepository.Delete(id);
        }

        public PlanDTO? Get(int id)
        {
            var repo = new PlanRepository();
            var plan = repo.Get(id);

            if (plan == null)
                return null;

            return new PlanDTO
            {
                IDPlan = plan.IDPlan,
                DescPlan = plan.DescPlan,
                IDEspecialidad = plan.IDEspecialidad
            };
        }

        public IEnumerable<PlanDTO> GetAll()
        {
            var repo = new PlanRepository();
            return repo.GetAll().Select(p => new PlanDTO
            {
                IDPlan = p.IDPlan,
                DescPlan = p.DescPlan,
                IDEspecialidad = p.IDEspecialidad
            }).ToList();
        }

        public bool Update(PlanDTO dto)
        {
            var repo = new PlanRepository();
            var plan = repo.Get(dto.IDPlan);
            if (plan == null) return false;

            plan.SetDescripcion(dto.DescPlan);
            plan.SetIDEspecialidad(dto.IDEspecialidad);

            return repo.Update(plan);
        }
    }
}
