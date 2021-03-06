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
    public class 客戶銀行資訊Controller : Controller
    {
        //private 客戶資料Entities db = new 客戶資料Entities();
        客戶銀行資訊Repository repo =  RepositoryHelper.Get客戶銀行資訊Repository();
        客戶資料Repository repo1;   // = RepositoryHelper.Get客戶資料Repository();

        public 客戶銀行資訊Controller()
        {
            repo1 = RepositoryHelper.Get客戶資料Repository(repo.UnitOfWork);
        }
        // GET: 客戶銀行資訊
        public ActionResult Index()
        {
            //var 客戶銀行資訊 = db.客戶銀行資訊.Include(p => p.客戶資料).Where(p => p.是否已刪除 == false);
            var 客戶銀行資訊 = repo.All().Include(p => p.客戶資料).Where(p => p.是否已刪除 == false);
            return View(客戶銀行資訊.ToList());
        }

        [HttpPost]
        public ActionResult Index(string accountName)
        {
            return View(this.repo.All().Where(p => p.帳戶名稱.Contains(accountName) && p.是否已刪除 == false));  // this.db.客戶銀行資訊.Where(p => p.帳戶名稱.Contains(accountName) && p.是否已刪除 == false));
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = repo.Get單筆資料By客戶Id(id.Value);   // db.客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(this.repo1.All(), "Id", "客戶名稱");  //new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶銀行資訊/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                this.repo.Add(客戶銀行資訊);
                this.repo.UnitOfWork.Commit();
                //db.客戶銀行資訊.Add(客戶銀行資訊);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            ViewBag.客戶Id = new SelectList(this.repo1.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = this.repo.Get單筆資料By客戶Id(id.Value);  // db.客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            ViewBag.客戶Id = new SelectList(this.repo1.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection form)
        {
            var 客戶銀行資訊 = repo.Get單筆資料By客戶Id(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }

            if (TryUpdateModel(客戶銀行資訊))
            {
                //db.Entry(客戶銀行資訊).State = EntityState.Modified;
                //db.SaveChanges();
                //this.repo.Update(客戶銀行資訊);
                this.repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            ViewBag.客戶Id = new SelectList(this.repo1.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = this.repo.Get單筆資料By客戶Id(id.Value);  // db.客戶銀行資訊.Find(id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶銀行資訊 客戶銀行資訊 = this.repo.Get單筆資料By客戶Id(id);  // db.客戶銀行資訊.Find(id);
            //db.客戶銀行資訊.Remove(客戶銀行資訊);
            //客戶銀行資訊.是否已刪除 = true;
            //this.repo.Update(客戶銀行資訊);

            this.repo.Delete(客戶銀行資訊);
            this.repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
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
