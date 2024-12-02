using WebApp.Models;


namespace WebApp.Models;

public class SiteProvider : BaseProvider{
    public SiteProvider(IConfiguration conf) : base(conf){
    }

    CategoryRepository? category;
    public CategoryRepository Category => category ??= new CategoryRepository(Connection);
    ProductRepository? product;
    public ProductRepository Product => product ??= new ProductRepository(Connection);
     SupplierRepository? supplier;
    public SupplierRepository Supplier => supplier ??= new SupplierRepository(Connection);
    CartRepository? cart;
    public CartRepository Cart => cart ??= new CartRepository(Connection);
    InvoiceRepository? invoice;
    public InvoiceRepository Invoice => invoice ??= new InvoiceRepository(Connection);
    EmployeeRepository? employee;
    public EmployeeRepository Employee => employee ??= new EmployeeRepository(Connection);
    VnPaymentRepository? vnPayment;
    public VnPaymentRepository VnPayment => vnPayment ??= new VnPaymentRepository(Connection);
    MemberRepository? member;
    public MemberRepository Member => member ??= new MemberRepository(Connection);

   
}