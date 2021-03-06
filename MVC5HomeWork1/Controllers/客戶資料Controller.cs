﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5HomeWork1.Models;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace MVC5HomeWork1.Controllers
{
    public class 客戶資料Controller : BaseController
    {
        //private 客戶資料Entities db = new 客戶資料Entities();
        客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();

        客戶統計資料Repository repo1; // = RepositoryHelper.Get客戶統計資料Repository();

        public 客戶資料Controller()
        {
            repo1 = RepositoryHelper.Get客戶統計資料Repository(repo.UnitOfWork);
        }

        // GET: 客戶資料
        [HttpGet]
        public ActionResult Index(string sortBy, string currentSort)
        {
            //return View(db.客戶資料.ToList().Where(p => p.是否已刪除 == false));

            ViewBag.客戶分類 = this.repo.GetCategory();

            ViewBag.CurrentSort = sortBy;

            sortBy = string.IsNullOrEmpty(sortBy) ? "客戶名稱" : sortBy;

            switch (sortBy)
            {
                case "客戶名稱":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderByDescending(p => p.客戶名稱);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderBy(p => p.客戶名稱);
                    }
                    break;
                case "統一編號":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderByDescending(p => p.統一編號);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderBy(p => p.統一編號);
                    }
                    break;
                case "電話":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderByDescending(p => p.電話);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderBy(p => p.電話);
                    }
                    break;
                case "傳真":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderByDescending(p => p.傳真);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderBy(p => p.傳真);
                    }
                    break;
                case "地址":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderByDescending(p => p.地址);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderBy(p => p.地址);
                    }
                    break;
                case "Email":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderByDescending(p => p.Email);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderBy(p => p.Email);
                    }
                    break;
                case "客戶分類":
                    if (sortBy.Equals(currentSort))
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderByDescending(p => p.客戶分類);
                        ViewBag.CurrentSort = null;
                    }
                    else
                    {
                        ViewData.Model = repo.All()
                            .Where(p => p.是否已刪除 == false)
                            .OrderBy(p => p.客戶分類);
                    }
                    break;
            }

            //ViewData.Model = repo.All()
            //    .Where(p => p.是否已刪除 == false);

            return View();
        }

        [HttpPost]
        public ActionResult Index(string customerName, string 客戶分類, string sortBy, string CurrentSort)
        {
            // Using Entities DB
            //return View(db.客戶資料.Where(p => p.客戶名稱.Contains(customerName) && p.是否已刪除 == false));

            ViewBag.客戶分類 = this.repo.GetCategory();


            // Using Repository
            ViewData.Model = this.repo.GetCustomerData(customerName, 客戶分類);

            return View();
        }


        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.Get單筆資料By客戶Id(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        //[Authorize]
        [宣告客戶分類的SelectList物件]
        public ActionResult Create()
        {

            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[Authorize]
        [HttpPost]
        [宣告客戶分類的SelectList物件]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                //db.客戶資料.Add(客戶資料);
                //db.SaveChanges();
                repo.Add(客戶資料);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        //[Authorize]
        [宣告客戶分類的SelectList物件]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = repo.Get單筆資料By客戶Id(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[Authorize]
        [HttpPost]
        [宣告客戶分類的SelectList物件]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        public ActionResult Edit(int id, FormCollection form)
        {
            var 客戶資料 = repo.Get單筆資料By客戶Id(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            if (TryUpdateModel(客戶資料))
            {
                //db.Entry(客戶資料).State = EntityState.Modified;
                //db.SaveChanges();
                //repo.Update(客戶資料);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        //[Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = repo.Get單筆資料By客戶Id(id.Value); // db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        //[Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //[HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
        public ActionResult DeleteConfirmed(int id)
        {
            //try
            //{
                客戶資料 客戶資料 = repo.Get單筆資料By客戶Id(id);   //db.客戶資料.Find(id);
                                                      //db.客戶資料.Remove(客戶資料);
                客戶資料.是否已刪除 = true;
                //db.SaveChanges();
                repo.Update(客戶資料);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");

            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine(ex.Message);
            //    throw;
            //}
        }

        public ActionResult CustomerList()
        {
            return View(repo1.All());  //db.客戶統計資料
        }

        [HttpPost]
        public ActionResult CustomerList(string 客戶名稱)
        {
            //return View(this.db.客戶統計資料.Where(p => p.客戶名稱.Contains(客戶名稱)));
            return View(repo1.All().Where(p => p.客戶名稱.Contains(客戶名稱)));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
