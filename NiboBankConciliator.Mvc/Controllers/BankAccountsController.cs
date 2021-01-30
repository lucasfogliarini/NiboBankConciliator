using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NiboBankConciliator.Mvc.Controllers
{
    public class BankAccountsController : Controller
    {
        // GET: BankAccountsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BankAccountsController/Details/5
        public ActionResult Transactions(int id)
        {
            var bankTransactions = 1;
            return View(bankTransactions);
        }

        // GET: BankAccountsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BankAccountsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
