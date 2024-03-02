using Domain.Entities;
using review.test.Domain;

namespace App;

internal class GetPositionsListCommand(TestDatabase context)
{

	/*
	
	1. создать метод для получения списка позиций HierarchicalEntity
	Каждая запись должна иметь наименование позиции и наименование корневой категории
	
	Позиция - запись с установленым Value (не равен null)
	Категория - запись без установленного Value (равен null)
	Корневая категория - категория, у которой не установлен ParentId (равен null)

	Гарантируется:
	- нет циклических ссылок
	- категория может быть вложена только в категорию
	- позиция может быть вложена только в категорию
	
	- среднее количество записей: две тысячи. Возможное: 10 тысяч
	- из них: 30% - категории
	- уровень вложенности записей: в среднем - 3, макс. - 10

	 пример: 
		Name						Id		ParentId	Value
	---------------------------------------------------------------
		"category 1"					1		null		null		// корневая категория
			"category 2"				2		1			null		// 
				"position 3"			3		2			10			// 
				"position 12"			4		2			12			// 
				"category 4"			5		2			null		// 
					"position 4"		6		3			10			// корневой категорией является "category 1"
		"category 5"					7		null		null		// корневая категория
			"position 6"				8		7			10			// 
			"position 8"				9		7			20			// 
		"position 9"					10		null		5			// позиция без категории
	 
	 вывод:
		{ name: "position 3" , category: "category 1" }
		{ name: "position 12", category: "category 1" }
	 	{ name: "position 4" , category: "category 1" }
		{ name: "position 6" , category: "category 5" }
		{ name: "position 8" , category: "category 5" }
		{ name: "position 9" , category: "" }							// или .. category: null
	 */
	public class PositionName { public string Name { get; set; } public string Category { get; set; } }
	public List<PositionName> GetList()
	{
		
	}
}
