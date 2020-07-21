using MiniDMartApp.Application.Interfaces;
using MiniDMartApp.Application.Mapper;
using MiniDMartApp.Application.Models;
using MiniDMartApp.Domain.Domain;
using MiniDMartApp.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDMartApp.Application.Services
{
    public class StateDataService : IStateDataService
    {
        private readonly IRepository<StateData> _stateRepository;
        public StateDataService(IRepository<StateData> stateRepository)
        {
            this._stateRepository = stateRepository;
        }
        public void Add(StateDataModel model)
        {
            var entity = model.MapToStateData();
            _stateRepository.Add(entity);
        }

        public IEnumerable<StateDataModel> GetAll()
        {
            var lstEntity = _stateRepository.GetAll();
            List<StateDataModel> lstModel = new List<StateDataModel>();
            foreach(var entity in lstEntity)
            {
                lstModel.Add(entity.MapToStateData());
            }
            return lstModel;
        }
    }
}
