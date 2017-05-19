using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5HomeWork1.Models
{   
	public  class 客戶統計資料Repository : EFRepository<客戶統計資料>, I客戶統計資料Repository
	{

	}

	public  interface I客戶統計資料Repository : IRepository<客戶統計資料>
	{

	}
}