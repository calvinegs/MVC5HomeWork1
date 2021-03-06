﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5HomeWork1.Models;

namespace MVC5HomeWork1.Controllers
{
    public class 客戶聯絡人Controller : BaseController
    {
        //private 客戶資料Entities db = new 客戶資料Entities();

        客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();
        客戶資料Repository repo1;   //= RepositoryHelper.Get客戶資料Repository();

        public 客戶聯絡人Controller()
        {
            repo1 = RepositoryHelper.Get客戶資料Repository(repo.UnitOfWork);
        }

        // GET: 客戶聯絡人
        public ActionResult Index(string 聯絡人姓名, string 職稱, string sortBy, string currentSort)
        {
            // Entityes DB
            //var 客戶聯絡人 = db.客戶聯絡人.Include(p => p.客戶資料)
            //                .Where(p => p.是否已刪除 == false);

            // Repository
            //var 客戶聯絡人 = this.repo.All().Include(p => p.客戶資料)
            //                    .Where(p => p.是否已刪除 == false);
            //return View(客戶聯絡人.ToList());
            //return View(this.repo.All().Where(p => p.姓名.Contains(聯絡人姓名) && p.職稱.Contains(職稱) && p.是否已刪除 == false));

            ViewBag.CurrentSort = sortBy;

            sortBy = string.IsNullOrEmpty(sortBy) ? "職稱" : sortBy;

            switch (sortBy)
            {
                case "職稱":
                    if (sortBy.Equals(currentSort))
                    {
                        if ((聯絡人姓名 != null) && (職稱 != null))
                        {
                            ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderByDescending(p => p.職稱);
                        }
                        else
                            ViewData.Model = repo.All()
                                .Where(p => p.是否已刪除 == false)
                                .OrderByDescending(p => p.職稱);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        if ((聯絡人姓名 != null) && (職稱 != null))
                            ViewData.Model = repo.All()
                                .Where(p => p.姓名.Contains(聯絡人姓名)
                                && p.職稱.Contains(職稱)
                                && p.是否已刪除 == false)
                                .OrderBy(p => p.職稱);
                        else
                            ViewData.Model = repo.All()
                                .Where(p => p.是否已刪除 == false)
                                .OrderBy(p => p.職稱);
                    }
                    break;
                case "姓名":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderByDescending(p => p.姓名);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderBy(p => p.姓名);
                    }
                    break;
                case "Email":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderByDescending(p => p.Email);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderBy(p => p.Email);
                    }
                    break;
                case "手機":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderByDescending(p => p.手機);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderBy(p => p.手機);
                    }
                    break;
                case "電話":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderByDescending(p => p.電話);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderBy(p => p.電話);
                    }
                    break;
                case "客戶名稱":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderByDescending(p => p.客戶資料.客戶名稱);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.姓名.Contains(聯絡人姓名)
                            && p.職稱.Contains(職稱)
                            && p.是否已刪除 == false)
                            .OrderBy(p => p.客戶資料.客戶名稱);
                    }
                    break;
            }

            // 查詢
            //if ((聯絡人姓名 != null) && (職稱 != null))
            //    ViewData.Model = this.repo.All().Where(p => p.姓名.Contains(聯絡人姓名) && p.職稱.Contains(職稱) && p.是否已刪除 == false);
            //else
            //    ViewData.Model = this.repo.All();
            return View();


        }

        [HttpPost]
        public ActionResult Index1(string 聯絡人姓名, string 職稱)
        {
            //return View(this.db.客戶聯絡人.Where(p => p.姓名.Contains(聯絡人姓名) && p.職稱.Contains(職稱) && p.是否已刪除 == false));
            return View(this.repo.All().Where(p => p.姓名.Contains(聯絡人姓名) && p.職稱.Contains(職稱) && p.是否已刪除 == false));
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = this.repo.Get單筆資料By客戶Id(id.Value);    // db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            ViewBag.客戶Id = new SelectList(this.repo1.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                //db.客戶聯絡人.Add(客戶聯絡人);
                //db.SaveChanges();
                this.repo.Add(客戶聯絡人);
                this.repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            ViewBag.客戶Id = new SelectList(this.repo1.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = this.repo.Get單筆資料By客戶Id(id.Value);    // db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            ViewBag.客戶Id = new SelectList(this.repo1.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection form)
        {
            var 客戶聯絡人 = repo.Get單筆資料By客戶Id(id);

            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }

            if (TryUpdateModel(客戶聯絡人))
            {
                this.repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            //if (ModelState.IsValid)
            //{
            //    //db.Entry(客戶聯絡人).State = EntityState.Modified;
            //    //db.SaveChanges();
            //    this.repo.Update(客戶聯絡人);
            //    this.repo.UnitOfWork.Commit();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            ViewBag.客戶Id = new SelectList(this.repo1.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = this.repo.Get單筆資料By客戶Id(id.Value);    // drepo.UnitOfWork.Context.Dispose();b.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = this.repo.Get單筆資料By客戶Id(id);    // db.客戶聯絡人.Find(id);
            //db.客戶聯絡人.Remove(客戶聯絡人);
            //客戶聯絡人.是否已刪除 = true;
            //this.repo.Update(客戶聯絡人);

            this.repo.Delete(客戶聯絡人);
            this.repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                repo.UnitOfWork.Context.Dispose();
                //repo1.UnitOfWork.Context.Dispose(); // 不須要，因為是共用的
            }
            base.Dispose(disposing);
        }
    }
}
