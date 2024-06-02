using donetCore_beginner.Data;
using donetCore_beginner.Models;
using Microsoft.AspNetCore.Mvc;

namespace donetCore_beginner.Controllers
{
    public class CategoryController : Controller
    {   
        // 取資料表所有資料
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

		// 發送時，取得新增商品頁Form表單Input的值
		[HttpPost]
		public IActionResult Create(Category obj) 
		{
			//if (obj.Name == obj.DisplayOrder.ToString()) 
			//{
			//	// 自定義錯誤訊息
			//	ModelState.AddModelError("name", "商品名稱與商品數量不能相同");  
			//}

			//if (obj.Name != null && obj.Name.ToLower() == "test")
            //{
			//	// 第一個參數為""，代表不顯示在對應的錯誤訊息html結構上，而是顯示在全部錯誤訊息的html結構上
			//	ModelState.AddModelError("", "這個商品名稱不能使用"); 
			//}

			if (ModelState.IsValid)   // 新增資料時，驗證使否符合Model的規則
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
				TempData["success"] = "新增成功";

				return RedirectToAction("Index", "Category");     // 驗證通過，導回商品列表的首頁
			}
            return View();            // 驗證不通過，停在新增頁
		}


        public IActionResult Edit(int? id)
        {
			if (id == null || id == 0)
			{
				return NotFound();
			}
			//	寫法一
			Category? categoryFromDb = _db.Categories.Find(id);
			//	寫法二
			//Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u=>u.CategoryID==id);
			//	寫法三
			//Category? categoryFromDb3 = _db.Categories.Where(u => u.CategoryID == id).FirstOrDefault();

			if (categoryFromDb == null)
			{
				return NotFound();
			}
            return  View(categoryFromDb);
        }
		// 發送時，取得更新商品頁Form表單Input的值
		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)   //ㄍ更新資料時，驗證使否符合Model的規則
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "更新成功";

				return RedirectToAction("Index", "Category");     // 驗證通過，導回商品列表的首頁
			}
			return View();            // 驗證不通過，停在新增頁
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			
			Category? categoryFromDb = _db.Categories.Find(id);
			
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}
		// 發送時，取得刪除商品頁Form表單Input的值
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			Category? obj = _db.Categories.Find(id);
			if(obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "刪除成功";

			return RedirectToAction("Index", "Category");
		}
	}
}
