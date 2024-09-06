using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class PeoplesService
    {
        private readonly IPeoplesRepository _peoplesRepository;
       
        public PeoplesService(IPeoplesRepository peoplesRepository)
        {
            _peoplesRepository = peoplesRepository;
        }


    }
}
