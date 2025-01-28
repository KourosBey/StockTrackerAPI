using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAPI.Core.Enums
{
    public enum OfferStatus
    {
        Pending,       // Bekleyen Teklifler
        Approved,      // Onaylanan Teklifler
        Rejected,      // İptal Olan Teklifler
        Completed      // Tamamlanmış Teklifler
    }
}
