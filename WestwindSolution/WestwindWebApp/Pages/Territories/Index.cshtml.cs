using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestwindSystem.Entities;
using WestwindSystem.BLL;
using WestwindWebApp.Helpers;

namespace WestwindWebApp.Pages.Territories
{
    public class IndexModel : PageModel
    {
        private readonly TerritoryServices _territoryServices;
        
        
        public IndexModel(TerritoryServices territoryServices)
        {
            _territoryServices = territoryServices;

            
        }
        [TempData]
        public string InfoMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public List<Territory>? QueryResultList { get; private set; }

        private const int PAGE_SIZE = 5;
        public Paginator Pager { get; set; }


        public void OnGet(int? currentPage)
        {
            try
            {
                /*QueryResultList = _territoryServices.List();*/

                //setting up for using the Paginator only needs to be done if
                //  a query is executing

                //determine the current page number
                int pagenumber = currentPage.HasValue ? currentPage.Value : 1;
                //setup the current state of the paginator (sizing)
                PageState current = new(pagenumber, PAGE_SIZE);
                //temporary local integer to hold the results of the query's total collection size
                //  this will be need by the Paginator during the paginator's execution
                int totalcount;

                //we need to pass paging data into our query so that efficiencies in the
                //  system will ONLY return the amount of records to actually be display
                //  on the browser page.

                QueryResultList = _territoryServices.List(pagenumber, PAGE_SIZE, out totalcount);

                //create the needed Pagnator instance
                Pager = new Paginator(totalcount, current);
            } catch (Exception e)
            {
                ErrorMessage = $"{e.Message}";
            }
        }


    }
}
