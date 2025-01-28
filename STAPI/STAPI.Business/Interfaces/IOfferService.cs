using STAPI.Core.DTOs.Offer;
using STAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Business.Interfaces
{
    public interface IOfferService : IGenericService<OfferDto, Offer>
    {
    }
}
