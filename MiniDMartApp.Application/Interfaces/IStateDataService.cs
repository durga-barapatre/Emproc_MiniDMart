using MiniDMartApp.Application.CrudFunctions;
using MiniDMartApp.Application.Models;
using MiniDMartApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Application.Interfaces
{
   public interface IStateDataService:CRUDFunction<StateDataModel>
    {
    }
}
