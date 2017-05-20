using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVC5HomeWork1.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public 客戶銀行資訊 Get單筆資料By客戶Id(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id); 
        }
        public void Update(客戶銀行資訊 cutomerBank)
        {
            this.UnitOfWork.Context.Entry(cutomerBank).State = EntityState.Modified;
        }
        public override void Delete(客戶銀行資訊 entity)
        {
            entity.是否已刪除 = true;
            //base.Delete(entity);
        }

    }

    public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}