using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IBarCodeService
    {
        byte[] GenerateBarcode(string text);
        byte[] GenerateQRCode(string text);
    }
}
