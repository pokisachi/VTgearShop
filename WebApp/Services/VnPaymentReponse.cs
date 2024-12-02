using Microsoft.AspNetCore.Mvc;

public class VnPaymentReponse
{
    [BindProperty(Name = "vnp_Amount")]
    public int Amount{get; set;}
    [BindProperty(Name = "vnp_BankCode")]
    public string? BankCode{get; set;}
    [BindProperty(Name ="vnp_BankTranNo")]

    public string? BankTranNo{get; set;}
    [BindProperty(Name ="vnp_CardType")]
    public string? CardType{get; set;}
    [BindProperty(Name ="vnp_OrderInfo")]
    public string? OrderInfo{get; set;}
    [BindProperty(Name ="vnp_PayDate")]
    public string? PayDate{get; set;}
    [BindProperty(Name ="vnp_ResponseCode")]
    public string? ResponseCode{get; set;}
    [BindProperty(Name ="vnp_TmnCode")]
    
    public string? TmnCode{get; set;}
    [BindProperty(Name ="vnp_TransactionNo")]

    public string? TransactionNo{get; set;}
    [BindProperty(Name ="vnp_TransactionStatus")]

    public string? TransactionStatus{get; set;}
    [BindProperty(Name ="vnp_TxnRef")]
      public string? TxnRef{get; set;}
    [BindProperty(Name ="vnp_SecureHash")]

    public string? SecureHash{get; set;}
   
    

}

/*http://localhost:5090/cart/vnpaymentResponse?
vnp_Amount=10000000
&vnp_BankCode=NCB
&vnp_BankTranNo=VNP14623779
&vnp_CardType=ATM
&vnp_OrderInfo=Thanh+Toan+Don+Hangdacae1f063014c19ada97fc03c24a3c7+voi+so+tien100000
&vnp_PayDate=20241021101927
&vnp_ResponseCode=00
&vnp_TmnCode=G0NOWU5F
&vnp_TransactionNo=14623779
&vnp_TransactionStatus=00
&vnp_TxnRef=dacae1f063014c19ada97fc03c24a3c7
&vnp_SecureHash=162a87847ce0e717667f3ff3b0891b9120237a743055f20b0e34965e505d452e2d6d7ee0cd8a2fbb46b109a8fc1d5957d20d8b4ad91be21fccecfd9d22d29905*/