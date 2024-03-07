using HierarchicalStructureRefactor.Domain;

namespace HierarchicalStructureRefactor.Commands;

internal class UpdateValuesRecursivelyCommand(TestDatabase context)
{
	/*
	 2. На вход получены: идентификатор категории и новое значение Value для позиций.
	Необходимо реализовать обновление значения поля Value всем позициям, которые являются вложенными в указанную категорию.
	Должны быть обновлены записи на всех уровнях вложенности

	пример:

	input: (2, 100)
	
		Name										Id		ParentId	Value	|	new value
	----------------------------------------------------------------------------|---------------------
		"category 1"								1		null		null	| 
			"category 2"							2		1			null	| 
				"position 3"						3		2			10		| 100
				"position 12"						4		2			12		| 100
				"category 4"						5		2			null	| 
					"position 4"					6		5			10		| 100
					"category 15"					7		5			null	| 
						"position 16"				8		7			10		| 100
						"position 18"				9		7			20		| 100
					"position 9"					10		5			5		| 100
		"category 5"								11		null		null	| 
			"position 6"							12		11			10		| 
			"position 8"							13		11			20		| 
		"position 9"								14		null		5		| 
	 

	 */
	public void Update(long id, int value)
	{

	}
}
