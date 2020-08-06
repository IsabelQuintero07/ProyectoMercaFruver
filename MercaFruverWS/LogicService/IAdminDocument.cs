using ModelService;
using System.Collections.Generic;

namespace LogicService
{
    public interface IAdminDocument
    {
        List<Document_Type> GetAllDocuments();
    }
}
