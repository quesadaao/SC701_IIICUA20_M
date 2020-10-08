using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Solution.UI.Controllers
{

    public class PaisCAPIController : Controller
    {
        string baseURL = "http://localhost:51780/";

        // GET: PaisWEF
        public async Task<IActionResult> Index()
        {
            List<Models.Pais> aux = new List<Models.Pais>();
            using (var cl = new HttpClient()) 
            {
                cl.BaseAddress = new Uri(baseURL);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/Pais");
                if (res.IsSuccessStatusCode) {
                    var auxR = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Pais>>(auxR);
                }
            }
            return View(aux);                
        }

        //// GET: PaisWEF/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pais = await _context.Paises
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pais == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pais);
        //}

        //// GET: PaisWEF/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PaisWEF/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nombre")] Pais pais)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pais);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pais);
        //}

        //// GET: PaisWEF/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pais = await _context.Paises.FindAsync(id);
        //    if (pais == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(pais);
        //}

        //// POST: PaisWEF/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Pais pais)
        //{
        //    if (id != pais.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pais);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PaisExists(pais.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pais);
        //}

        //// GET: PaisWEF/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pais = await _context.Paises
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pais == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pais);
        //}

        //// POST: PaisWEF/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var pais = await _context.Paises.FindAsync(id);
        //    _context.Paises.Remove(pais);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PaisExists(int id)
        //{
        //    return _context.Paises.Any(e => e.Id == id);
        //}
    }
}
