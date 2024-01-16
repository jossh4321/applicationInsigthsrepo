using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppPractice.IService;
using WebAppPractice.Model;

namespace WabAppWithSql.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public List<Product> productList;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGet()
        {
            productList = _productService.GetAllProducts();
        }
    }
}