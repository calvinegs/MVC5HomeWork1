using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVC5HomeWork1.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public 客戶聯絡人 Get單筆資料By客戶Id(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }

        public void Update(客戶聯絡人 cutomerContract)
        {
            this.UnitOfWork.Context.Entry(cutomerContract).State = EntityState.Modified;
        }
    }

    public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}