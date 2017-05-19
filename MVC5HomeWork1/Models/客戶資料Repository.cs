using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVC5HomeWork1.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{

        public 客戶資料 Get單筆資料By客戶Id(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public void Update(客戶資料 customer)
        {
            this.UnitOfWork.Context.Entry(customer).State = EntityState.Modified;
        }

        public SelectList GetCategory()
        {
            var categoryQry = this.All().Select(p => p.客戶分類).Distinct();
            return new SelectList(categoryQry);
        }
        public IQueryable GetCustomerData(string customerName, string 客戶分類)
        {
            IQueryable CustomerData = null;
            if (客戶分類 == "")
                CustomerData = this.All()
                    .Where(p => p.客戶名稱.Contains(customerName) && p.是否已刪除 == false);
            else
                CustomerData = this.All()
                    .Where(p => p.客戶名稱.Contains(customerName) & p.客戶分類 == 客戶分類 && p.是否已刪除 == false);
            return CustomerData;
        }

    }

    public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}