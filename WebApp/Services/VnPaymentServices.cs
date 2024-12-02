using System.Net;
using Microsoft.Extensions.Options;
using WebApp.Models;

namespace WebApp.Services;

public class VnPaymentServices
{
        VnPayment payment;

    IHttpContextAccessor accessor;

    public VnPaymentServices(IOptions<VnPayment> options, IHttpContextAccessor accessor){
        payment = options.Value;
        this.accessor = accessor;

        
    }
    public string ToUrl(Invoice obj){
        IDictionary<string, string> dict = new SortedDictionary<string, string>{
            {"vnp_Amount", (obj.Amount * 100).ToString("#.")},
            {"vnp_Command", payment.Command},
            {"vnp_CreateDate", obj.InvoiceDate.ToString("yyyyMMddHHmmss")},
            {"vnp_CurrCode", payment.CurrCode},
            {"vnp_IpAddr", "127.0.0.1"},
            {"vnp_Locale", payment.Locale},
            {"vnp_OrderInfo", $"Thanh Toan Don Hang{obj.InvoiceId} voi so tien{obj.Amount}"},
            {"vnp_OrderType", payment.OrderType},
            {"vnp_ReturnUrl", payment.ReturnUrl},
            {"vnp_TmnCode", payment.TmnCode},
            {"vnp_TxnRef", obj.InvoiceId.ToString()},
            {"vnp_Version", payment.Version},

        };

        string query = string.Join("&", dict.Select(p => $"{p.Key}={WebUtility.UrlEncode(p.Value)}"));
        string secureHash = Helper.HmacSha512(query, payment.HashSecret);
        string url = $"{payment.BaseUrl}?{query}&vnp_SecureHash={secureHash}";
        System.Console.WriteLine(url);
        return url;
    }

}
/*
https://sandbox.vnpayment.vn/paymentv2/vpcpay.html
?vnp_Amount=1000200
&vnp_Command=pay
&vnp_CreateDate=202410DD095634
&vnp_CurrCode=VND
&vnp_IpAddr=127.0.0.1
&vnp_Locale=vn
&vnp_OrderInfo=Thanh+Toan+Don+Hang326bf1c81ea44bee8ad636c76419502e+voi+so+tien10002
&vnp_OrderType=other
&vnp_ReturnUrl=http%3A%2F%2Flocalhost%3A5090%2Fcart%2FvnpaymentResponse
&vnp_TmnCode=G0NOWUSF
&vnp_TxnRef=326bf1c81ea44bee8ad636c76419502e
&vnp_Version=2.1.0
&vnp_Securehash=E27A7BAD0797275E9003D94725E72CC2E20636330B6541481410B5B5723FA7AA291AC09C5D265D8462DB564D0EBFAE712B269E9DD6FAE90E2DBB84797A909143*/


