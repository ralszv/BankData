using BankData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankData.Interface
{
    public interface IHomeInterface
    {
        Task<OutputResponse> GetList();
    }
}
