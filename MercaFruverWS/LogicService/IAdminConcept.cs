using ModelService;
using System.Collections.Generic;

namespace LogicService
{
    public interface IAdminConcept
    {
        void AddConcept(Concept_Sale concept);

        Concept_Sale GetConcept(int id);

        void UpdateConcept(Concept_Sale concept);

        void DeleteConcept(int id);

        List<vw_Concept> GetAllConcepts();
    }
}
