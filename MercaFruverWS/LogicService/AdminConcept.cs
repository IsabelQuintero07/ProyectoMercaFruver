using ModelService;
using System.Collections.Generic;
using System.Linq;

namespace LogicService
{
    public class AdminConcept : IAdminConcept
    {
        MercaFruverSVEntities db = new MercaFruverSVEntities();

        public AdminConcept()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }

        public void AddConcept(Concept_Sale concept)
        {
            db.sp_concept_insert(
                concept.conceptProductId,
                concept.conceptSaleId,
                concept.conceptQuantity,
                concept.conceptUnitPrice
            );
            db.SaveChanges();
        }

        public Concept_Sale GetConcept(int id)
        {
            Concept_Sale concept = db.sp_concept_getById(id).FirstOrDefault();
            return concept;
        }

        public void UpdateConcept(Concept_Sale concept)
        {
            db.sp_concept_update(
                concept.conceptId,
                concept.conceptProductId,
                concept.conceptSaleId,
                concept.conceptQuantity,
                concept.conceptUnitPrice
            );
            db.SaveChanges();
        }

        public void DeleteConcept(int id)
        {
            db.sp_concept_deleteSoft(id);
            db.SaveChanges();
        }

        public List<vw_Concept> GetAllConcepts()
        {
            var data = db.sp_concept_list();
            return data.ToList();
        }
    }
}
