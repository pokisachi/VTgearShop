using WebApp.Models;

namespace WebApp.Services;

public class VnPayment
{
    public string Version {get; set;} = null!;
    public string Command {get; set;} = null!;
    public string TmnCode {get; set;} = null!;
    public string HashSecret {get; set;} = null!;
    public string CurrCode {get; set;} = null!;
    public string Locale {get; set;} = null!;
    public string OrderType {get; set;} = null!;
    public string ReturnUrl {get; set;} = null!;
    public decimal Amount {get; set;}
    public DateTime CreateDate {get; set;}
    public string IpAddr {get; set;} = null!;
    public string OrderInfo {get; set;} = null!;
    public string TxnRef {get; set;} = null!;
    public string SecureHash {get; set;} = null!;
    public string BaseUrl {get; set;} = null!;

    internal static string ToUrl(Invoice obj)
    {
        throw new NotImplementedException();
    }
}

// "Payment":{
//   "VnPayment": {
//     "Version":"2.1.0",
//     "Command": "pay",
//     "TimnCode": "G0NOWUSF",
//     "HashSecret": "GMODBWX465IFU601XSG4PSHG41TMIGQZ",
//     "CurrCode": "VND",
//     "Locale": "vn",
//     "OrderType": "other",
//     "ReturnUrl": "http://localhost:5090/cart/vnpaymentResponse"
//   }
// }