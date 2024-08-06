using Microsoft.AspNetCore.Mvc;

namespace BankAppWithController.Controllers
{
    [Controller]
    public class AccountController : Controller
    {
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            return Content("welcome to the bank", "text/plain");
        }

        [Route("account-details")]
        [HttpGet]
        public IActionResult AccountDetail()
        {
            var accDetail = new
            {
                accountNumber = 1001,
                accountHolderName = "example name",
                currentBalance = 5000,
            };

            return Json(accDetail);
        }

        [Route("account-statement")]
        [HttpGet]
        public IActionResult AccountStatement()
        {
            return new VirtualFileResult("/dummy_acc_summary.pdf", "application/pdf");
        }
        [Route("get-current-balance/{accountNumber:int?}")]
        [HttpGet]
        public IActionResult GetCurrentBalance()
        {
            if (!Request.RouteValues.ContainsKey("accountNumber"))
            {
                return NotFound("account number should be supplied");
            }
            int accountNum = Convert.ToInt16(Request.RouteValues["accountNumber"]);
            if (accountNum != 1001)
            {
                return BadRequest("account number must be 1001");
            }

            var accDetail = new
            {
                accountNumber = 1001,
                accountHolderName = "example name",
                currentBalance = 5000,
            };
            return Content(Convert.ToString(accDetail.currentBalance),"text/plain");
        }
    }
}
