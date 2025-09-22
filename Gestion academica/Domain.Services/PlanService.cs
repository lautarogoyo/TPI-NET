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
            var repo = new PlanRepository();
            return repo.Delete(id);
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
            var plan = new Plan(dto.DescPlan, dto.IDEspecialidad);

            typeof(Plan).GetProperty(nameof(Plan.IDPlan))!
                        .SetValue(plan, dto.IDPlan);

            return repo.Update(plan);
        }
    }
}
