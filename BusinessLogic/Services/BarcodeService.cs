using BusinessLogic.Interfaces;
using IronBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class BarcodeService : IBarCodeService
    {
        public byte[] GenerateBarcode(string text)
        {
            var barcode = IronBarCode.BarcodeWriter.CreateBarcode(text, BarcodeWriterEncoding.Code128);
            return barcode.ToBitmap().GetBytes();
        }

        public byte[] GenerateQRCode(string text)
        {
            var qrCode = QRCodeWriter.CreateQrCode(text);
            return qrCode.ToBitmap().GetBytes();
        }

    }
}
