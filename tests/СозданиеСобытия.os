Перем Ф;
Перем Форма_0;
Перем Кнопка1;
Перем Надпись1;
Перем Надпись2;
Перем Надпись3;
Перем Надпись5;
Перем Надпись6;
Перем Надпись7;
Перем Надпись8;
Перем Надпись9;
Перем ПолеВвода3;
Перем ПолеВвода4;
Перем ПолеВвода5;
Перем ПолеВыбора1;
Перем ПолеВыбора2;

Перем КлассИмяРус;
Перем КлассИмяEn;
Перем СобытиеИмяРус;
Перем СобытиеИмяEn;
Перем Использование;
Перем ЗначениеТип;
Перем ЗначениеОписание;
Перем ВыходнойКаталог;
Перем Наследники;
Перем Надпись10;
Перем Кнопка2;

Перем Кнопка3;
Перем Надпись11;
Перем ПолеВыбора3;
Перем Кнопка4;
Перем Кнопка5;
Перем ПолеВыбора4;
Перем Надпись12;
Перем Надпись13;
Перем ПолеВыбора5;
Перем ПолеВыбора6;
Перем РамкаГруппы1;
Перем ТекстНаследования;
Перем Флажок1;

Процедура Кн_Нажатие() Экспорт
	М = РазобратьСтроку(ПолеВыбора3.Текст, " ");
	КлассИмяРус = М[0];
	КлассИмяEn = М[1];
	КлассИмяEn = СтрЗаменить(КлассИмяEn, "(", "");
	КлассИмяEn = СтрЗаменить(КлассИмяEn, ")", "");
	СобытиеИмяРус = СокрЛП(ПолеВвода3.Текст);
	СобытиеИмяEn = СокрЛП(ПолеВвода4.Текст);
	Использование = СокрЛП(ПолеВыбора1.Текст);
	ЗначениеТип = СокрЛП(ПолеВыбора2.Текст);
	ЗначениеОписание = СокрЛП(ПолеВвода5.Текст);
	
	ТекстНаследования = "";
	Если СокрЛП(ПолеВыбора5.Текст) <> "" Тогда
		М4 = РазобратьСтроку(ПолеВыбора5.Текст, " ");
		Если М4.Количество() = 2 Тогда
			ТекстНаследования = " (унаследовано от " + М4[0] + " (" + М4[1] + "))";
		КонецЕсли;
	КонецЕсли;
	
	Если Флажок1.Помечен Тогда
		Для А = 0 По ПолеВыбора6.Элементы.Количество - 1 Цикл
			Эл = ПолеВыбора6.Элементы(А);
			Сообщить("Эл.Текст = " + Эл.Текст);
			ПолеВыбора6.Текст = Эл.Текст;
			Приостановить(500);
			// Ф.Предупреждение("Завершено " + ПолеВыбора6.Текст, 1, "Завершено");
			СоздатьСобытие();
		КонецЦикла;
		Ф.ОкноСообщений().Показать("Завершено", "Завершено");
	Иначе
		СоздатьСобытие();
	КонецЕсли;
КонецПроцедуры

Процедура НачальноеЗаполнениеФормы()
	ПолеВыбора3.Текст = "";
	ПолеВвода3.Текст = "";
	ПолеВвода4.Текст = "";
	ПолеВвода5.Текст = "";
	ПолеВыбора1.Текст = "Чтение и запись.";
	ПолеВыбора2.Текст = "";
	
	ЗаполнитьПолеВыбора4();
	ЗаполнитьПолеВыбора5();
	ЗаполнитьПолеВыбораТип();
	Флажок1.Помечен = Ложь;
КонецПроцедуры

Процедура ЗаполнитьПолеВыбораТип()
	Список14 = Новый СписокЗначений();
	Список14 = ДобавитьПеречисления(Список14);

	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptGameForms\docs\doc.html");
	Стр = ТекстДок.ПолучитьТекст();
	М = СтрНайтиМежду(Стр, 
			"menu3", 
			"</summary>", 
			, );
	Если М.Количество() > 0 Тогда
		// Сообщить("М[0] = " + М[0]);
		Для А = 0 По М.ВГраница() Цикл
			М2 = СтрНайтиМежду(М[А], "right"">", "</a>", , );
			Если М2.Количество() > 0 Тогда
				// Сообщить("М2[0] = " + М2[0]);
				Для А2 = 0 По М2.ВГраница() Цикл
					СтрКласс = М2[0];
					СтрКласс = СтрЗаменить(СтрКласс, "(", "");
					СтрКласс = СтрЗаменить(СтрКласс, ")", "");
					// Сообщить("" + М2[0]);
					
					СтрКласс2En = СтрНайтиМежду(М2[0], "(", ")", , )[0];
					Фрагмент33 = "№" + М2[0];
					СтрКласс2Ru = СокрЛП(СтрНайтиМежду(Фрагмент33, "№", " (", , )[0]);
					СтрКласс2 = "<a href=""OSGForms." + СтрКласс2En + ".html"">" + СтрКласс2Ru + "&nbsp;(" + СтрКласс2En + ")</a>.";
					Если Список14.НайтиПоЗначению(СтрКласс2) = Неопределено Тогда
						Список14.Добавить(СтрКласс2, СтрКласс2Ru);
					КонецЕсли;
				КонецЦикла;
			КонецЕсли;
		КонецЦикла;
	КонецЕсли;
						
	Список14.СортироватьПоПредставлению();
	Для А45 = 0 По Список14.Количество() - 1 Цикл
		ПолеВыбора2.Элементы.Добавить(Список14.Получить(А45).Значение);
	КонецЦикла;
КонецПроцедуры

Функция ДобавитьПеречисления(СписокДляПеречислений)
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptGameForms\docs\doc.html");
	Стр56 = ТекстДок.ПолучитьТекст();
	М56 = СтрНайтиМежду(Стр56, 
			"Enumeration.html"" target=""right"">", 
			"</a>", 
			, );
	Если М56.Количество() > 0 Тогда
		// Сообщить("М56[0] = " + М56[0]);
		Для А57 = 0 По М56.ВГраница() Цикл
			СтрПеречисл = М56[А57];
			// Сообщить("СтрПеречисл = " + СтрПеречисл);
			
			СтрКласс2En = СтрНайтиМежду(СтрПеречисл, "(", ")", , )[0];
			Фрагмент33 = "№" + СтрПеречисл;
			СтрКласс2Ru = СокрЛП(СтрНайтиМежду(Фрагмент33, "№", " (", , )[0]);
			СтрКласс2 = "<a href=""OSGForms." + СтрКласс2En + "Enumeration.html"">" + СтрКласс2Ru + "&nbsp;(" + СтрКласс2En + ")</a>.";
			Если СписокДляПеречислений.НайтиПоЗначению(СтрКласс2) = Неопределено Тогда
				СписокДляПеречислений.Добавить(СтрКласс2, СтрКласс2Ru);
			КонецЕсли;
		КонецЦикла;
	КонецЕсли;
	Возврат СписокДляПеречислений;
КонецФункции

Процедура ЗаполнитьПолеВыбора5()
	Список = Новый СписокЗначений();
	ВыбранныеФайлы = НайтиФайлы("C:\444\OneScriptGameForms\docs\OSGForms\", "*.html", Истина);
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		Если СтрНайти(ВыбранныеФайлы[А].Имя, "Events.html") > 0 Тогда
			// Сообщить("" + ВыбранныеФайлы[А].ПолноеИмя);
			ТекстДок = Новый ТекстовыйДокумент;
			ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
			Стр = ТекстДок.ПолучитьТекст();
			
			КлассРусАнгл = СтрНайтиМежду(Стр, "<h1 class=dtH1>", "События</h1>", , )[0];
			КлассРусАнгл = СтрЗаменить(КлассРусАнгл, "&nbsp;", " ");
			КлассРусАнгл = СтрЗаменить(КлассРусАнгл, "(", "");
			КлассРусАнгл = СтрЗаменить(КлассРусАнгл, ")", "");
			КлассРусАнгл = СокрЛП(КлассРусАнгл);
			
			Если Список.НайтиПоЗначению(КлассРусАнгл) = Неопределено Тогда
				Список.Добавить(КлассРусАнгл);
			КонецЕсли;
		КонецЕсли;
	КонецЦикла;

	Список.СортироватьПоЗначению();
	Для А = 0 По Список.Количество() - 1 Цикл
		ПолеВыбора5.Элементы.Добавить(Список.Получить(А).Значение);
	КонецЦикла;
КонецПроцедуры

Процедура ЗаполнитьПолеВыбора4()
	Список = Новый СписокЗначений();
	ВыбранныеФайлы = НайтиФайлы("C:\444\OneScriptGameForms\docs\OSGForms\", "*.html", Истина);
	Для А = 0 По ВыбранныеФайлы.ВГраница() Цикл
		Если СтрНайти(ВыбранныеФайлы[А].Имя, "Events.html") > 0 Тогда
			// Сообщить("" + ВыбранныеФайлы[А].ПолноеИмя);
			ТекстДок = Новый ТекстовыйДокумент;
			ТекстДок.Прочитать(ВыбранныеФайлы[А].ПолноеИмя);
			Стр = ТекстДок.ПолучитьТекст();
			
			КлассРусАнгл = СтрНайтиМежду(Стр, "<h1 class=dtH1>", "События</h1>", , )[0];
			КлассРусАнгл = СтрЗаменить(КлассРусАнгл, "&nbsp;", " ");
			КлассРусАнгл = СтрЗаменить(КлассРусАнгл, "(", "");
			КлассРусАнгл = СтрЗаменить(КлассРусАнгл, ")", "");
			КлассРусАнгл = СокрЛП(КлассРусАнгл);
			
			М2 = СтрНайтиМежду(Стр, "<tbody>", "</tbody>", , );
			Если М2.Количество() > 0 Тогда
				// Сообщить("" + М2[1]);
				М3 = СтрНайтиМежду(М2[1], "<tr vAlign=top>", "</tr>", Ложь, );
				Для А3 = 0 По М3.ВГраница() Цикл
					// Сообщить("" + М3[А3]);
					М4 = СтрНайтиМежду(М3[А3], "html"">", "</a>", , );
					Если М4.Количество() > 0 Тогда
						Для А4 = 0 По М4.ВГраница() Цикл
							// Сообщить("М4[0] = " + М4[0]);
							ИмяСвойства = М4[0];
							ИмяСвойства = СтрЗаменить(ИмяСвойства, "&nbsp;", " ");
							ИмяСвойства = СтрЗаменить(ИмяСвойства, "(", "");
							ИмяСвойства = СтрЗаменить(ИмяСвойства, ")", "");
							
							Если Список.НайтиПоЗначению(ИмяСвойства) = Неопределено Тогда
								Список.Добавить(ИмяСвойства, КлассРусАнгл);
								// Сообщить("" + ИмяСвойства + " " + КлассРусАнгл);
							КонецЕсли;
						КонецЦикла;
					КонецЕсли;
				КонецЦикла;
			КонецЕсли;
		КонецЕсли;
	КонецЦикла;

	Для А = 0 По Список.Количество() - 1 Цикл
		ПолеВыбора4.Элементы.Добавить(Список.Получить(А).Значение + " " + Список.Получить(А).Представление);
	КонецЦикла;
КонецПроцедуры

Процедура СоздатьСобытие()
	Стр = "<!DOCTYPE html>
	|<html lang=""ru"">
	|<head>
	|    <title>EEVVEENNTT Event</title>
	|    <meta charset=""UTF-8"">
	|    <link rel=""stylesheet"" type=""text/css"" href=""mainstyle.css"">
	|    <script defer src=""mobilstyle.js""></script>
	|</head>
	|<body id=bodyID class=dtBODY>
	|    <div id=nsbanner>
	|        <div id=bannerrow1>
	|            <table class=bannerparthead cellSpacing=0>
	|                <tbody>
	|                    <tr id=hdr>
	|                        <td class=runninghead></td>
	|                        <td class=product></td>
	|                    </tr>
	|                </tbody>
	|            </table>
	|        </div>
	|        <div id=TitleRow>
	|            <h1 class=dtH1>ККЛЛААСС.ССООББЫЫТТИИЕЕ&nbsp;(CCLLAASS.EEVVEENNTT)&nbsp;Событие</h1>
	|        </div>
	|    </div>
	|    <div id=nstext>
	|        <h4 class=dtH4>Использование</h4>
	|        <p>" + Использование + "</p>
	|        <h4 class=dtH4>Значение</h4>
	|        <p>Тип: " + ЗначениеТип + "</p>
	|        <p>" + ЗначениеОписание + "</p>
	|        <h4 class=dtH4>Примечание</h4>
	|        <p></p>";
	БлокПримеров = "
	|        <h4 class=dtH4>Пример</h4>
	|<pre class=code>
	|
	|</pre>
	|        <details>
	|            <summary>Полный пример кода</summary>
	|<pre class=code>
	|<button type=""button"" class=""copy-btn"" data-target-id=""cont1"" style=""font-size:100%;"">Копировать</button>
	|<hr style=""border-color: lightgray;""><div id=""cont1"">
	|
	|</div>
	|</pre>
	|        </details>
	|        <p></p>";
	
	ЭтоБазовыйКласс = Ложь;
	ИмяФайлаКласса = "C:\444\OneScriptGameForms\docs\OSGForms\OSGForms." + КлассИмяEn + ".html";
	ТекстДокКласс = Новый ТекстовыйДокумент;
	ТекстДокКласс.Прочитать(ИмяФайлаКласса);
	СтрКласс = ТекстДокКласс.ПолучитьТекст();
	М6 = СтрНайтиМежду(СтрКласс, "<h4 class=dtH4>Описание</h4>", "<h4 class=dtH4>Иерархия</h4>", , );
	Если М6.Количество() > 0 Тогда
		// Сообщить("Описание = " + М6[0]);
		Описание = М6[0];
		М7 = СтрНайтиМежду(Описание, "<p>", "</p>", , );
		Если М7.Количество() > 0 Тогда
			// Сообщить("Лев(М7[0], 13) = " + Лев(М7[0], 13));
			Если Лев(М7[0], 13) = "Базовый класс" Тогда
				ЭтоБазовыйКласс = Истина;
			КонецЕсли;
		КонецЕсли;
	КонецЕсли;
	Если ЭтоБазовыйКласс Тогда
	Иначе
		Стр = Стр + БлокПримеров;
	КонецЕсли;
	Стр = Стр + "
	|        <h4 class=dtH4>Смотрите также</h4>
	|        <p><a href=""OSGForms.html"">Библиотека&nbsp;OSGForms</a></p>
	|    </div>
	|</body>
	|</html>
	|";
	Если КлассИмяEn = "" Тогда
		ПодстрокаПоиска = "ККЛЛААСС.";
		ПодстрокаЗамены = КлассИмяРус;
		Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
		
		ПодстрокаПоиска = "CCLLAASS.";
		ПодстрокаЗамены = КлассИмяEn;
		Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
	Иначе
		ПодстрокаПоиска = "ККЛЛААСС";
		ПодстрокаЗамены = КлассИмяРус;
		Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
		
		ПодстрокаПоиска = "CCLLAASS";
		ПодстрокаЗамены = КлассИмяEn;
		Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
	КонецЕсли;

	ПодстрокаПоиска = "ССООББЫЫТТИИЕЕ";
	ПодстрокаЗамены = СобытиеИмяРус;
	Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);

	ПодстрокаПоиска = "EEVVEENNTT";
	ПодстрокаЗамены = СобытиеИмяEn;
	Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);

	Если КлассИмяEn = "" Тогда
		ТекстДок = Новый ТекстовыйДокумент;
		ИмяФайла = ВыходнойКаталог + "\OSGForms." + СобытиеИмяEn + "Event.html";
		ТекстДок.УстановитьТекст(Стр);
		ТекстДок.Записать(ИмяФайла);
	Иначе
		ТекстДок = Новый ТекстовыйДокумент;
		ИмяФайла = ВыходнойКаталог + "\OSGForms." + КлассИмяEn + СобытиеИмяEn + "Event.html";
		ТекстДок.УстановитьТекст(Стр);
		ТекстДок.Записать(ИмяФайла);
	КонецЕсли;
	ОткудаПереносим1 = ИмяФайла;
	КудаПереносим1 = "C:\444\OneScriptGameForms\docs\OSGForms\OSGForms." + КлассИмяEn + СобытиеИмяEn + "Event.html";
	
	// ====================================================================================
	// Изменим C:\444\OneScriptGameForms\docs\OSGForms\OSGForms.КЛАССEvents.html 
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptGameForms\docs\OSGForms\OSGForms." + КлассИмяEn + "Events.html");
	Стр = ТекстДок.ПолучитьТекст();
	М = СтрНайтиМежду(Стр, 
		"<h4 class=dtH4>События</h4>
		|        <div class=tablediv>
		|            <table class=dtTABLE cellSpacing=0>
		|                <tbody>", 
		"<tr vAlign=top>", 
		Ложь, );
	// Сообщить("М[0] = " + М[0]);
	ПодстрокаПоиска = М[0];
	ПодстрокаЗамены = М[0] + "
	|                        <td width=""50%""><a href=""OSGForms." + КлассИмяEn + СобытиеИмяEn + "Event.html"">" + СобытиеИмяРус + "&nbsp;(" + СобытиеИмяEn + ")</a>" + ТекстНаследования + "</td>
	|                        <td width=""50%"">" + ЗначениеОписание + "</td>
	|                    </tr>
	|                    <tr vAlign=top>";
	Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);

	ИмяФайла = ВыходнойКаталог + "\OSGForms." + КлассИмяEn + "Events.html";
	ТекстДок.УстановитьТекст(Стр);
	ТекстДок.Записать(ИмяФайла);
	ОткудаПереносим2 = ИмяФайла;
	КудаПереносим2 = "C:\444\OneScriptGameForms\docs\OSGForms\OSGForms." + КлассИмяEn + "Events.html";
	
	Приостановить(2000);
	Сортировать_Events();
	
	ОкноСообщений1 = Ф.ОкноСообщений();
	Если Флажок1.Помечен Тогда
		КопироватьФайл(ОткудаПереносим1, КудаПереносим1);
		Приостановить(500);
		КопироватьФайл(ОткудаПереносим2, КудаПереносим2);
		Приостановить(500);
		УдалитьФайлы(ВыходнойКаталог, "*.html");  
		Ф.Предупреждение("Завершено " + КлассИмяРус + "." + СобытиеИмяРус, 1, "Завершено");
	Иначе
		Ф.ОкноСообщений().Показать("Завершено", "Завершено");
	КонецЕсли;
КонецПроцедуры//СоздатьСобытие

Процедура Сортировать_Events()
	Список = Новый СписокЗначений();
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ВыходнойКаталог + "\OSGForms." + КлассИмяEn + "Events.html");
	Стр = ТекстДок.ПолучитьТекст();
	М = СтрНайтиМежду(Стр, 
		"<tbody>", 
		"</tbody>", Ложь, );
	Если М.Количество() > 0 Тогда
		// Сообщить("" + М[1]);
		ПодстрокаПоиска = М[1];
		М2 = СтрНайтиМежду(М[1], "                    <tr vAlign=top>", "</tr>", Ложь, );
		Для А2 = 0 По М2.ВГраница() Цикл
			// Сообщить("" + М2[А2]);
			М3 = СтрНайтиМежду(М2[А2], "html"">", "</a>", , );
			Если М3.Количество() > 0 Тогда
				// Сообщить("М3[0] = " + М3[0]);
				Список.Добавить(М2[А2], СтрЗаменить(М3[0], "&nbsp;", " "));
			КонецЕсли;
		КонецЦикла;
	КонецЕсли;

	Список.СортироватьПоПредставлению();
	ПодстрокаЗамены = "";
	Для А = 0 По Список.Количество() - 1 Цикл
		// Сообщить("==" + Список.Получить(А).Значение);
		ПодстрокаЗамены = ПодстрокаЗамены + Список.Получить(А).Значение + "
		|";
	КонецЦикла;
	ПодстрокаЗамены = "<tbody>					
	|" + ПодстрокаЗамены + "                </tbody>";
	// Сообщить("=======================================");
	// Сообщить("" + ПодстрокаПоиска);
	// Сообщить("=======================================");
	// Сообщить("" + ПодстрокаЗамены);
	
	Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
	ИмяФайла = ВыходнойКаталог + "\OSGForms." + КлассИмяEn + "Events.html";
	ТекстДок.УстановитьТекст(Стр);
	ТекстДок.Записать(ИмяФайла);
КонецПроцедуры

Процедура КопироватьСобытие() Экспорт
	СобытиеРус = СтрРазделить(ПолеВыбора4.Текст, " ")[0];
	СобытиеАнгл = СтрРазделить(ПолеВыбора4.Текст, " ")[1];
	КлассСобытиеРус = СтрРазделить(ПолеВыбора4.Текст, " ")[2];
	КлассСобытиеАнгл = СтрРазделить(ПолеВыбора4.Текст, " ")[3];
    // Сообщить("СобытиеРус = " + СобытиеРус);
    // Сообщить("СобытиеАнгл = " + СобытиеАнгл);
    // Сообщить("КлассСобытиеРус = " + КлассСобытиеРус);
    // Сообщить("КлассСобытиеАнгл = " + КлассСобытиеАнгл);
	
	ТекстДок = Новый ТекстовыйДокумент;
	// OSGForms.ViewBottomProperty.html
	ФайлСобытие = "C:\444\OneScriptGameForms\docs\OSGForms\OSGForms." + КлассСобытиеАнгл + СобытиеАнгл + "Event.html";
	КаталогНаДиске = Новый Файл(ФайлСобытие);
    Если Не (КаталогНаДиске.Существует()) Тогда
		Возврат;
	КонецЕсли;
	ТекстДок.Прочитать(ФайлСобытие);
	СтрТекстДок = ТекстДок.ПолучитьТекст();
	// Сообщить("СтрТекстДок = " + СтрТекстДок);
	
	// СобытиеИмяРус
	// СобытиеИмяEn
	// Использование
	// ЗначениеТип
	// ЗначениеОписание
	
	// Использование</h4>
	М = СтрНайтиМежду(СтрТекстДок, "Использование</h4>", "/p>", , );
	Использование = СтрНайтиМежду(М[0], "<p>", "<", , )[0]; // ПолеВыбора1
	ПолеВыбора1.Текст = Использование;
	// Сообщить("Использование = " + Использование);
	
	СобытиеИмяРус = СобытиеРус; // ПолеВвода3
	ПолеВвода3.Текст = СобытиеИмяРус;
	// Сообщить("СобытиеИмяРус = " + СобытиеИмяРус);
	
	СобытиеИмяEn = СобытиеАнгл; // ПолеВвода4
	ПолеВвода4.Текст = СобытиеИмяEn;
	// Сообщить("СобытиеИмяEn = " + СобытиеИмяEn);
	
	М = СтрНайтиМежду(СтрТекстДок, "<h4 class=dtH4>Значение</h4>", "<h4 class=dtH4>Примечание</h4>", , );
	Если М.Количество() > 0 Тогда
		// Сообщить("" + М2[1]);
		М2 = СтрНайтиМежду(М[0], "<p>", "</p>", , );
		Если М2.Количество() > 0 Тогда
			Попытка
				ЗначениеТип = М2[0]; // ПолеВыбора2
				ЗначениеТип = СтрЗаменить(ЗначениеТип, "Тип:", " ");
				ЗначениеТип = СтрЗаменить(ЗначениеТип, " ", "");
				ЗначениеТип = СтрЗаменить(ЗначениеТип, "ahref", "a href");
				ПолеВыбора2.Текст = ЗначениеТип;
				// Сообщить("ЗначениеТип = " + ЗначениеТип);
			Исключение
			КонецПопытки;
			Попытка
				ЗначениеОписание = М2[1]; // ПолеВвода5
				ПолеВвода5.Текст = ЗначениеОписание;
				// Сообщить("ЗначениеОписание = " + ЗначениеОписание);
			Исключение
			КонецПопытки;
		КонецЕсли;
	КонецЕсли;
КонецПроцедуры

Процедура ЗаполнитьНаследуемые() Экспорт
	ПолеВыбора6.Элементы.Очистить();
	ПолеВыбора6.Текст = "";
	
	КлассСобытияРус = СтрРазделить(ПолеВыбора5.Текст, " ")[0];
	КлассСобытияАнгл = СтрРазделить(ПолеВыбора5.Текст, " ")[1];
	// Сообщить("КлассСобытияРус = " + КлассСобытияРус);
	// Сообщить("КлассСобытияАнгл = " + КлассСобытияАнгл);
	
	ТекстДок = Новый ТекстовыйДокумент;
	// OSGForms.ButtonToStringMethod.html
	ФайлСобытия = "C:\444\OneScriptGameForms\docs\OSGForms\OSGForms." + КлассСобытияАнгл + "Events.html";
	КаталогНаДиске = Новый Файл(ФайлСобытия);
    Если Не (КаталогНаДиске.Существует()) Тогда
		Возврат;
	КонецЕсли;
	ТекстДок.Прочитать(ФайлСобытия);
	СтрТекстДок = ТекстДок.ПолучитьТекст();
	// Сообщить("СтрТекстДок = " + СтрТекстДок);

	Список = Новый СписокЗначений();
	М2 = СтрНайтиМежду(СтрТекстДок, "<tbody>", "</tbody>", , );
	Если М2.Количество() > 0 Тогда
		// Сообщить("" + М2[1]);
		М3 = СтрНайтиМежду(М2[1], "<tr vAlign=top>", "</tr>", Ложь, );
		Для А3 = 0 По М3.ВГраница() Цикл
			// Сообщить("" + М3[А3]);
			М4 = СтрНайтиМежду(М3[А3], "html"">", "</a>", , );
			Если М4.Количество() > 0 Тогда
				Для А4 = 0 По М4.ВГраница() Цикл
					// Сообщить("М4[0] = " + М4[0]);
					ИмяСобытия = М4[0];
					ИмяСобытия = СтрЗаменить(ИмяСобытия, "&nbsp;", " ");
					ИмяСобытия = СтрЗаменить(ИмяСобытия, "(", "");
					ИмяСобытия = СтрЗаменить(ИмяСобытия, ")", "");
					
					Если Список.НайтиПоЗначению(ИмяСобытия) = Неопределено Тогда
						Если Не СтрНайти(М3[А3], "(унаследовано") > 0 Тогда
							Список.Добавить(ИмяСобытия, КлассСобытияРус + " " + КлассСобытияАнгл);
							// Сообщить("" + ИмяСобытия + " " + КлассРусАнгл);
						КонецЕсли;
					КонецЕсли;
				КонецЦикла;
			КонецЕсли;
		КонецЦикла;
	КонецЕсли;

	Для А = 0 По Список.Количество() - 1 Цикл
		ПолеВыбора6.Элементы.Добавить(Список.Получить(А).Значение);
	КонецЦикла;
КонецПроцедуры

Процедура НаследоватьСобытие() Экспорт
	СобытиеРус = СтрРазделить(ПолеВыбора6.Текст, " ")[0];
	СобытиеАнгл = СтрРазделить(ПолеВыбора6.Текст, " ")[1];
	КлассСобытиеРус = СтрРазделить(ПолеВыбора5.Текст, " ")[0];
	КлассСобытиеАнгл = СтрРазделить(ПолеВыбора5.Текст, " ")[1];
    // Сообщить("СобытиеРус = " + СобытиеРус);
    // Сообщить("СобытиеАнгл = " + СобытиеАнгл);
    // Сообщить("КлассСобытиеРус = " + КлассСобытиеРус);
    // Сообщить("КлассСобытиеАнгл = " + КлассСобытиеАнгл);
	
	ТекстДок = Новый ТекстовыйДокумент;
	// OSGForms.ViewBottomProperty.html
	ФайлСобытие = "C:\444\OneScriptGameForms\docs\OSGForms\OSGForms." + КлассСобытиеАнгл + СобытиеАнгл + "Event.html";
	КаталогНаДиске = Новый Файл(ФайлСобытие);
    Если Не (КаталогНаДиске.Существует()) Тогда
		Возврат;
	КонецЕсли;
	ТекстДок.Прочитать(ФайлСобытие);
	СтрТекстДок = ТекстДок.ПолучитьТекст();
	// Сообщить("СтрТекстДок = " + СтрТекстДок);
	
	// СобытиеИмяРус
	// СобытиеИмяEn
	// Использование
	// ЗначениеТип
	// ЗначениеОписание
	
	// Использование</h4>
	М = СтрНайтиМежду(СтрТекстДок, "Использование</h4>", "/p>", , );
	Использование = СтрНайтиМежду(М[0], "<p>", "<", , )[0]; // ПолеВыбора1
	ПолеВыбора1.Текст = Использование;
	// Сообщить("Использование = " + Использование);
	
	СобытиеИмяРус = СобытиеРус; // ПолеВвода3
	ПолеВвода3.Текст = СобытиеИмяРус;
	// Сообщить("СобытиеИмяРус = " + СобытиеИмяРус);
	
	СобытиеИмяEn = СобытиеАнгл; // ПолеВвода4
	ПолеВвода4.Текст = СобытиеИмяEn;
	// Сообщить("СобытиеИмяEn = " + СобытиеИмяEn);
	
	М = СтрНайтиМежду(СтрТекстДок, "<h4 class=dtH4>Значение</h4>", "<h4 class=dtH4>Примечание</h4>", , );
	Если М.Количество() > 0 Тогда
		// Сообщить("" + М2[1]);
		М2 = СтрНайтиМежду(М[0], "<p>", "</p>", , );
		Если М2.Количество() > 0 Тогда
			Попытка
				ЗначениеТип = М2[0]; // ПолеВыбора2
				ЗначениеТип = СтрЗаменить(ЗначениеТип, "Тип:", " ");
				ЗначениеТип = СтрЗаменить(ЗначениеТип, " ", "");
				ЗначениеТип = СтрЗаменить(ЗначениеТип, "ahref", "a href");
				ПолеВыбора2.Текст = ЗначениеТип;
				// Сообщить("ЗначениеТип = " + ЗначениеТип);
			Исключение
			КонецПопытки;
			Попытка
				ЗначениеОписание = М2[1]; // ПолеВвода5
				ПолеВвода5.Текст = ЗначениеОписание;
				// Сообщить("ЗначениеОписание = " + ЗначениеОписание);
			Исключение
			КонецПопытки;
		КонецЕсли;
	КонецЕсли;
КонецПроцедуры

Процедура ПодготовкаКомпонентов()
    // ВАЖНО: Необходимая процедура для поддержки конструктора — не изменяйте содержимое этой процедуры с помощью редактора кода.
    // osdText = "WzzQmtC+0L3RgdGC0YDRg9C60YLQvtGA0YtdDQrQpNC+0YDQvNCwXzAgPSDQpC7QpNC+0YDQvNCwKCk7DQrQmtC90L7Qv9C60LAxID0g0KQu0JrQvdC+0L/QutCwKCk7DQrQndCw0LTQv9C40YHRjDIgPSDQpC7QndCw0LTQv9C40YHRjCgpOw0K0J3QsNC00L/QuNGB0Yw1ID0g0KQu0J3QsNC00L/QuNGB0YwoKTsNCtCd0LDQtNC/0LjRgdGMNiA9INCkLtCd0LDQtNC/0LjRgdGMKCk7DQrQn9C+0LvQtdCS0LLQvtC00LAzID0g0KQu0J/QvtC70LXQktCy0L7QtNCwKCk7DQrQn9C+0LvQtdCS0LLQvtC00LA0ID0g0KQu0J/QvtC70LXQktCy0L7QtNCwKCk7DQrQndCw0LTQv9C40YHRjDcgPSDQpC7QndCw0LTQv9C40YHRjCgpOw0K0J/QvtC70LXQktGL0LHQvtGA0LAxID0g0KQu0J/QvtC70LXQktGL0LHQvtGA0LAoKTsNCtCd0LDQtNC/0LjRgdGMOCA9INCkLtCd0LDQtNC/0LjRgdGMKCk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDIgPSDQpC7Qn9C+0LvQtdCS0YvQsdC+0YDQsCgpOw0K0J3QsNC00L/QuNGB0Yw5ID0g0KQu0J3QsNC00L/QuNGB0YwoKTsNCtCf0L7Qu9C10JLQstC+0LTQsDUgPSDQpC7Qn9C+0LvQtdCS0LLQvtC00LAoKTsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMyA9INCkLtCf0L7Qu9C10JLRi9Cx0L7RgNCwKCk7DQrQndCw0LTQv9C40YHRjDExID0g0KQu0J3QsNC00L/QuNGB0YwoKTsNCtCd0LDQtNC/0LjRgdGMMSA9INCkLtCd0LDQtNC/0LjRgdGMKCk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDQgPSDQpC7Qn9C+0LvQtdCS0YvQsdC+0YDQsCgpOw0K0KDQsNC80LrQsNCT0YDRg9C/0L/RizEgPSDQpC7QoNCw0LzQutCw0JPRgNGD0L/Qv9GLKCk7DQrQndCw0LTQv9C40YHRjDEyID0g0KQu0J3QsNC00L/QuNGB0YwoKTsNCtCd0LDQtNC/0LjRgdGMMTMgPSDQpC7QndCw0LTQv9C40YHRjCgpOw0K0J/QvtC70LXQktGL0LHQvtGA0LA1ID0g0KQu0J/QvtC70LXQktGL0LHQvtGA0LAoKTsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwNiA9INCkLtCf0L7Qu9C10JLRi9Cx0L7RgNCwKCk7DQrQpNC70LDQttC+0LoxID0g0KQu0KTQu9Cw0LbQvtC6KCk7DQpb0JrQvtC90YHRgtGA0YPQutGC0L7RgNGLPl0NCls80KHQstC+0LnRgdGC0LLQsF0NCls80KTQvtGA0LzQsF8wXQ0K0KTQvtGA0LzQsF8wLtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCg2NDksIDUzNCk7DQrQpNC+0YDQvNCwXzAu0J/Rg9GC0YwgPSAiQzpcNDQ0XDYt0JfQsNCz0L7RgtC+0LLQutC40KLQtdGA0LzQuNC90LDQu9Ck0L7RgNC8XCEhIdCh0L7Qt9C00LDQvdC40LXQodC+0LHRi9GC0LjRjy5vcyI7DQrQpNC+0YDQvNCwXzAu0KHRgtC40LvRjNCh0LrRgNC40L/RgtCwID0gItCh0YLQuNC70YzQodC60YDQuNC/0YLQsCI7DQrQpNC+0YDQvNCwXzAu0KLQtdC60YHRgiA9ICLQodC+0LfQtNCw0L3QuNC1INGB0L7QsdGL0YLQuNGPIjsNCtCk0L7RgNC80LBfMC7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0K0KTQvtGA0LzQsF8wLtCY0LzRj9Ce0LHRitC10LrRgtCw0KTQvtGA0LzRi9CU0LvRj9Ce0LTQvdC+0KHQutGA0LjQv9GC0LAgPSAi0KQiOw0KW9Ck0L7RgNC80LBfMD5dDQpbPNCa0L3QvtC/0LrQsDFdDQrQmtC90L7Qv9C60LAxLtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQmtC90L7Qv9C60LAxLtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCgxMjcsIDIzKTsNCtCa0L3QvtC/0LrQsDEu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAwOw0K0JrQvdC+0L/QutCwMS7QndCw0LbQsNGC0LjQtSA9ICLQmtC9X9Cd0LDQttCw0YLQuNC1IjsNCtCa0L3QvtC/0LrQsDEu0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCg0NzAsIDQ1OSk7DQrQmtC90L7Qv9C60LAxLtCi0LXQutGB0YIgPSAi0KHQvtC30LTQsNGC0Ywg0YHQvtCx0YvRgtC40LUiOw0K0JrQvdC+0L/QutCwMS7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Ca0L3QvtC/0LrQsDE+XQ0KWzzQndCw0LTQv9C40YHRjDJdDQrQndCw0LTQv9C40YHRjDIu0KDQvtC00LjRgtC10LvRjCA9INCk0L7RgNC80LBfMDsNCtCd0LDQtNC/0LjRgdGMMi7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMzUyLCAyMyk7DQrQndCw0LTQv9C40YHRjDIu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAyOw0K0J3QsNC00L/QuNGB0YwyLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMTksIDQ2Mik7DQrQndCw0LTQv9C40YHRjDIu0KLQtdC60YHRgiA9ICLQktGL0YXQvtC00L3Ri9C1INC00LDQvdC90YvQtSDQsdGD0LTRg9GCINCyINC60LDRgtCw0LvQvtCz0LUgQzpcMDAwIjsNCtCd0LDQtNC/0LjRgdGMMi7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cd0LDQtNC/0LjRgdGMMj5dDQpbPNCd0LDQtNC/0LjRgdGMNV0NCtCd0LDQtNC/0LjRgdGMNS7QoNC+0LTQuNGC0LXQu9GMID0g0KTQvtGA0LzQsF8wOw0K0J3QsNC00L/QuNGB0Yw1LtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCgxNDIsIDE3KTsNCtCd0LDQtNC/0LjRgdGMNS7Qn9C+0YDRj9C00L7QutCe0LHRhdC+0LTQsCA9IDc7DQrQndCw0LTQv9C40YHRjDUu0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCgxOCwgMTk1KTsNCtCd0LDQtNC/0LjRgdGMNS7QotC10LrRgdGCID0gItCh0L7QsdGL0YLQuNC10JjQvNGP0KDRg9GBIjsNCtCd0LDQtNC/0LjRgdGMNS7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cd0LDQtNC/0LjRgdGMNT5dDQpbPNCd0LDQtNC/0LjRgdGMNl0NCtCd0LDQtNC/0LjRgdGMNi7QoNC+0LTQuNGC0LXQu9GMID0g0KTQvtGA0LzQsF8wOw0K0J3QsNC00L/QuNGB0Yw2LtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCgxMjUsIDE2KTsNCtCd0LDQtNC/0LjRgdGMNi7Qn9C+0YDRj9C00L7QutCe0LHRhdC+0LTQsCA9IDg7DQrQndCw0LTQv9C40YHRjDYu0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCgzMTksIDE5Nik7DQrQndCw0LTQv9C40YHRjDYu0KLQtdC60YHRgiA9ICLQodC+0LHRi9GC0LjQtdCY0LzRj0VuIjsNCtCd0LDQtNC/0LjRgdGMNi7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cd0LDQtNC/0LjRgdGMNj5dDQpbPNCf0L7Qu9C10JLQstC+0LTQsDNdDQrQn9C+0LvQtdCS0LLQvtC00LAzLtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQn9C+0LvQtdCS0LLQvtC00LAzLtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCgyOTYsIDIyKTsNCtCf0L7Qu9C10JLQstC+0LTQsDMu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSA5Ow0K0J/QvtC70LXQktCy0L7QtNCwMy7Qn9C+0LvQvtC20LXQvdC40LUgPSDQpC7QotC+0YfQutCwKDE3LCAyMTUpOw0K0J/QvtC70LXQktCy0L7QtNCwMy7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cf0L7Qu9C10JLQstC+0LTQsDM+XQ0KWzzQn9C+0LvQtdCS0LLQvtC00LA0XQ0K0J/QvtC70LXQktCy0L7QtNCwNC7QoNC+0LTQuNGC0LXQu9GMID0g0KTQvtGA0LzQsF8wOw0K0J/QvtC70LXQktCy0L7QtNCwNC7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMjk2LCAyMik7DQrQn9C+0LvQtdCS0LLQvtC00LA0LtCf0L7RgNGP0LTQvtC60J7QsdGF0L7QtNCwID0gMTA7DQrQn9C+0LvQtdCS0LLQvtC00LA0LtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMzE5LCAyMTUpOw0K0J/QvtC70LXQktCy0L7QtNCwNC7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cf0L7Qu9C10JLQstC+0LTQsDQ+XQ0KWzzQndCw0LTQv9C40YHRjDddDQrQndCw0LTQv9C40YHRjDcu0KDQvtC00LjRgtC10LvRjCA9INCk0L7RgNC80LBfMDsNCtCd0LDQtNC/0LjRgdGMNy7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMTU3LCAxOCk7DQrQndCw0LTQv9C40YHRjDcu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAxMTsNCtCd0LDQtNC/0LjRgdGMNy7Qn9C+0LvQvtC20LXQvdC40LUgPSDQpC7QotC+0YfQutCwKDE4LCAyMzgpOw0K0J3QsNC00L/QuNGB0Yw3LtCi0LXQutGB0YIgPSAi0JjRgdC/0L7Qu9GM0LfQvtCy0LDQvdC40LUiOw0K0J3QsNC00L/QuNGB0Yw3LtCo0YDQuNGE0YIgPSDQpC7QqNGA0LjRhNGCKCJNaWNyb3NvZnQgU2FucyBTZXJpZiIsIDkuNzUsICk7DQpb0J3QsNC00L/QuNGB0Yw3Pl0NCls80J/QvtC70LXQktGL0LHQvtGA0LAxXQ0K0J/QvtC70LXQktGL0LHQvtGA0LAxLtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDEu0KDQsNC30LzQtdGAID0g0KQu0KDQsNC30LzQtdGAKDI5NSwgMjQpOw0K0J/QvtC70LXQktGL0LHQvtGA0LAxLtCf0L7RgNGP0LTQvtC60J7QsdGF0L7QtNCwID0gMTI7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDEu0JLRi9GB0L7RgtCw0K3Qu9C10LzQtdC90YLQsCA9IDE2Ow0K0J/QvtC70LXQktGL0LHQvtGA0LAxLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMTgsIDI1OSk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDEu0KLQtdC60YHRgiA9ICLQotC+0LvRjNC60L4g0LfQsNC/0LjRgdGMLiI7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDEu0KjQuNGA0LjQvdCw0JLRi9C/0LDQtNCw0Y7RidC10LPQvtCh0L/QuNGB0LrQsCA9IDI5NTsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMS7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0K0J/QvtC70LXQktGL0LHQvtGA0LAxLtCt0LvQtdC80LXQvdGC0Ysu0JTQvtCx0LDQstC40YLRjCjQpC7QrdC70LXQvNC10L3RgtCh0L/QuNGB0LrQsCgi0KLQvtC70YzQutC+INC30LDQv9C40YHRjC4iLCAi0KLQvtC70YzQutC+INC30LDQv9C40YHRjC4iKSk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDEu0K3Qu9C10LzQtdC90YLRiy7QlNC+0LHQsNCy0LjRgtGMKNCkLtCt0LvQtdC80LXQvdGC0KHQv9C40YHQutCwKCLQotC+0LvRjNC60L4g0YfRgtC10L3QuNC1LiIsICLQotC+0LvRjNC60L4g0YfRgtC10L3QuNC1LiIpKTsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMS7QrdC70LXQvNC10L3RgtGLLtCU0L7QsdCw0LLQuNGC0Ywo0KQu0K3Qu9C10LzQtdC90YLQodC/0LjRgdC60LAoItCn0YLQtdC90LjQtSDQuCDQt9Cw0L/QuNGB0YwuIiwgItCn0YLQtdC90LjQtSDQuCDQt9Cw0L/QuNGB0YwuIikpOw0KW9Cf0L7Qu9C10JLRi9Cx0L7RgNCwMT5dDQpbPNCd0LDQtNC/0LjRgdGMOF0NCtCd0LDQtNC/0LjRgdGMOC7QoNC+0LTQuNGC0LXQu9GMID0g0KTQvtGA0LzQsF8wOw0K0J3QsNC00L/QuNGB0Yw4LtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCgxMzIsIDE3KTsNCtCd0LDQtNC/0LjRgdGMOC7Qn9C+0YDRj9C00L7QutCe0LHRhdC+0LTQsCA9IDEzOw0K0J3QsNC00L/QuNGB0Yw4LtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMTcsIDI5Mik7DQrQndCw0LTQv9C40YHRjDgu0KLQtdC60YHRgiA9ICLQl9C90LDRh9C10L3QuNC10KLQuNC/IjsNCtCd0LDQtNC/0LjRgdGMOC7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cd0LDQtNC/0LjRgdGMOD5dDQpbPNCf0L7Qu9C10JLRi9Cx0L7RgNCwMl0NCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMi7QoNC+0LTQuNGC0LXQu9GMID0g0KTQvtGA0LzQsF8wOw0K0J/QvtC70LXQktGL0LHQvtGA0LAyLtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCg1OTcsIDI0KTsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMi7Qn9C+0YDRj9C00L7QutCe0LHRhdC+0LTQsCA9IDE0Ow0K0J/QvtC70LXQktGL0LHQvtGA0LAyLtCS0YvRgdC+0YLQsNCt0LvQtdC80LXQvdGC0LAgPSAxNjsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMi7Qn9C+0LvQvtC20LXQvdC40LUgPSDQpC7QotC+0YfQutCwKDE4LCAzMTIpOw0K0J/QvtC70LXQktGL0LHQvtGA0LAyLtCi0LXQutGB0YIgPSAi0JHRg9C70LXQstC+LiI7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDIu0KjQuNGA0LjQvdCw0JLRi9C/0LDQtNCw0Y7RidC10LPQvtCh0L/QuNGB0LrQsCA9IDU5NzsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMi7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0K0J/QvtC70LXQktGL0LHQvtGA0LAyLtCt0LvQtdC80LXQvdGC0Ysu0JTQvtCx0LDQstC40YLRjCjQpC7QrdC70LXQvNC10L3RgtCh0L/QuNGB0LrQsCgi0JHRg9C70LXQstC+LiIsICLQkdGD0LvQtdCy0L4uIikpOw0K0J/QvtC70LXQktGL0LHQvtGA0LAyLtCt0LvQtdC80LXQvdGC0Ysu0JTQvtCx0LDQstC40YLRjCjQpC7QrdC70LXQvNC10L3RgtCh0L/QuNGB0LrQsCgi0KHRgtGA0L7QutCwLiIsICLQodGC0YDQvtC60LAuIikpOw0K0J/QvtC70LXQktGL0LHQvtGA0LAyLtCt0LvQtdC80LXQvdGC0Ysu0JTQvtCx0LDQstC40YLRjCjQpC7QrdC70LXQvNC10L3RgtCh0L/QuNGB0LrQsCgi0KfQuNGB0LvQvi4iLCAi0KfQuNGB0LvQvi4iKSk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDIu0K3Qu9C10LzQtdC90YLRiy7QlNC+0LHQsNCy0LjRgtGMKNCkLtCt0LvQtdC80LXQvdGC0KHQv9C40YHQutCwKCLQn9GA0L7QuNC30LLQvtC70YzQvdGL0LkuIiwgItCf0YDQvtC40LfQstC+0LvRjNC90YvQuS4iKSk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDIu0K3Qu9C10LzQtdC90YLRiy7QlNC+0LHQsNCy0LjRgtGMKNCkLtCt0LvQtdC80LXQvdGC0KHQv9C40YHQutCwKCLQudC50LnQudC50LnQudC50LnQuSAgINC50LnQudC50LnQudC50LnQudC5IiwgItC50LnQudC50LnQudC50LnQudC5ICAg0LnQudC50LnQudC50LnQudC50LkiKSk7DQpb0J/QvtC70LXQktGL0LHQvtGA0LAyPl0NCls80J3QsNC00L/QuNGB0Yw5XQ0K0J3QsNC00L/QuNGB0Yw5LtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQndCw0LTQv9C40YHRjDku0KDQsNC30LzQtdGAID0g0KQu0KDQsNC30LzQtdGAKDE1OCwgMTgpOw0K0J3QsNC00L/QuNGB0Yw5LtCf0L7RgNGP0LTQvtC60J7QsdGF0L7QtNCwID0gMTU7DQrQndCw0LTQv9C40YHRjDku0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCgxNywgMzQ1KTsNCtCd0LDQtNC/0LjRgdGMOS7QotC10LrRgdGCID0gItCX0L3QsNGH0LXQvdC40LXQntC/0LjRgdCw0L3QuNC1IjsNCtCd0LDQtNC/0LjRgdGMOS7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cd0LDQtNC/0LjRgdGMOT5dDQpbPNCf0L7Qu9C10JLQstC+0LTQsDVdDQrQn9C+0LvQtdCS0LLQvtC00LA1LtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQn9C+0LvQtdCS0LLQvtC00LA1LtCc0L3QvtCz0L7RgdGC0YDQvtGH0L3Ri9C50KDQtdC20LjQvCA9INCY0YHRgtC40L3QsDsNCtCf0L7Qu9C10JLQstC+0LTQsDUu0KDQsNC30LzQtdGAID0g0KQu0KDQsNC30LzQtdGAKDU5NywgODcpOw0K0J/QvtC70LXQktCy0L7QtNCwNS7Qn9C+0YDRj9C00L7QutCe0LHRhdC+0LTQsCA9IDE2Ow0K0J/QvtC70LXQktCy0L7QtNCwNS7Qn9C+0LvQvtC20LXQvdC40LUgPSDQpC7QotC+0YfQutCwKDE4LCAzNjYpOw0K0J/QvtC70LXQktCy0L7QtNCwNS7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cf0L7Qu9C10JLQstC+0LTQsDU+XQ0KWzzQn9C+0LvQtdCS0YvQsdC+0YDQsDNdDQrQn9C+0LvQtdCS0YvQsdC+0YDQsDMu0KDQvtC00LjRgtC10LvRjCA9INCk0L7RgNC80LBfMDsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMy7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMjk1LCAyNCk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDMu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAyMTsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMy7QktGL0YHQvtGC0LDQrdC70LXQvNC10L3RgtCwID0gMTY7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDMu0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCgxOCwgNDIpOw0K0J/QvtC70LXQktGL0LHQvtGA0LAzLtCo0LjRgNC40L3QsNCS0YvQv9Cw0LTQsNGO0YnQtdCz0L7QodC/0LjRgdC60LAgPSAyOTY7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDMu0KjRgNC40YTRgiA9INCkLtCo0YDQuNGE0YIoIk1pY3Jvc29mdCBTYW5zIFNlcmlmIiwgOS43NSwgKTsNClvQn9C+0LvQtdCS0YvQsdC+0YDQsDM+XQ0KWzzQndCw0LTQv9C40YHRjDExXQ0K0J3QsNC00L/QuNGB0YwxMS7QoNC+0LTQuNGC0LXQu9GMID0g0KTQvtGA0LzQsF8wOw0K0J3QsNC00L/QuNGB0YwxMS7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMTUzLCAxNik7DQrQndCw0LTQv9C40YHRjDExLtCf0L7RgNGP0LTQvtC60J7QsdGF0L7QtNCwID0gMjI7DQrQndCw0LTQv9C40YHRjDExLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMTksIDIzKTsNCtCd0LDQtNC/0LjRgdGMMTEu0KLQtdC60YHRgiA9ICLQmtC70LDRgdGBIjsNCtCd0LDQtNC/0LjRgdGMMTEu0KjRgNC40YTRgiA9INCkLtCo0YDQuNGE0YIoIk1pY3Jvc29mdCBTYW5zIFNlcmlmIiwgOS43NSwgKTsNClvQndCw0LTQv9C40YHRjDExPl0NCls80J3QsNC00L/QuNGB0YwxXQ0K0J3QsNC00L/QuNGB0YwxLtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQndCw0LTQv9C40YHRjDEu0KDQsNC30LzQtdGAID0g0KQu0KDQsNC30LzQtdGAKDE0NSwgMjMpOw0K0J3QsNC00L/QuNGB0YwxLtCf0L7RgNGP0LTQvtC60J7QsdGF0L7QtNCwID0gMjM7DQrQndCw0LTQv9C40YHRjDEu0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCgxOSwgNzcpOw0K0J3QsNC00L/QuNGB0YwxLtCi0LXQutGB0YIgPSAi0JrQvtC/0LjRgNGD0LXQvNC+0LUg0YHQvtCx0YvRgtC40LUiOw0K0J3QsNC00L/QuNGB0YwxLtCo0YDQuNGE0YIgPSDQpC7QqNGA0LjRhNGCKCJNaWNyb3NvZnQgU2FucyBTZXJpZiIsIDkuNzUsICk7DQpb0J3QsNC00L/QuNGB0YwxPl0NCls80J/QvtC70LXQktGL0LHQvtGA0LA0XQ0K0J/QvtC70LXQktGL0LHQvtGA0LA0LtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDQu0KDQsNC30LzQtdGAID0g0KQu0KDQsNC30LzQtdGAKDQ0NiwgMjQpOw0K0J/QvtC70LXQktGL0LHQvtGA0LA0LtCf0L7RgNGP0LTQvtC60J7QsdGF0L7QtNCwID0gMjQ7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDQu0JLRi9GB0L7RgtCw0K3Qu9C10LzQtdC90YLQsCA9IDE2Ow0K0J/QvtC70LXQktGL0LHQvtGA0LA0LtCY0L3QtNC10LrRgdCS0YvQsdGA0LDQvdC90L7Qs9C+0JjQt9C80LXQvdC10L0gPSAi0JrQvtC/0LjRgNC+0LLQsNGC0YzQodC+0LHRi9GC0LjQtSI7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDQu0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCgxNjksIDc0KTsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwNC7QqNC40YDQuNC90LDQktGL0L/QsNC00LDRjtGJ0LXQs9C+0KHQv9C40YHQutCwID0gNDQ2Ow0K0J/QvtC70LXQktGL0LHQvtGA0LA0LtCo0YDQuNGE0YIgPSDQpC7QqNGA0LjRhNGCKCJNaWNyb3NvZnQgU2FucyBTZXJpZiIsIDkuNzUsICk7DQpb0J/QvtC70LXQktGL0LHQvtGA0LA0Pl0NCls80KDQsNC80LrQsNCT0YDRg9C/0L/RizFdDQrQoNCw0LzQutCw0JPRgNGD0L/Qv9GLMS7QoNC+0LTQuNGC0LXQu9GMID0g0KTQvtGA0LzQsF8wOw0K0KDQsNC80LrQsNCT0YDRg9C/0L/RizEu0KDQsNC30LzQtdGAID0g0KQu0KDQsNC30LzQtdGAKDU5NiwgODApOw0K0KDQsNC80LrQsNCT0YDRg9C/0L/RizEu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAyNTsNCtCg0LDQvNC60LDQk9GA0YPQv9C/0YsxLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMTksIDEwNCk7DQrQoNCw0LzQutCw0JPRgNGD0L/Qv9GLMS7QotC10LrRgdGCID0gItCd0LDRgdC70LXQtNC+0LLQsNC90LjQtSI7DQrQoNCw0LzQutCw0JPRgNGD0L/Qv9GLMS7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cg0LDQvNC60LDQk9GA0YPQv9C/0YsxPl0NCls80J3QsNC00L/QuNGB0YwxMl0NCtCd0LDQtNC/0LjRgdGMMTIu0KDQvtC00LjRgtC10LvRjCA9INCg0LDQvNC60LDQk9GA0YPQv9C/0YsxOw0K0J3QsNC00L/QuNGB0YwxMi7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMTQ5LCAyMyk7DQrQndCw0LTQv9C40YHRjDEyLtCf0L7RgNGP0LTQvtC60J7QsdGF0L7QtNCwID0gMDsNCtCd0LDQtNC/0LjRgdGMMTIu0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCg2LCA0OCk7DQrQndCw0LTQv9C40YHRjDEyLtCi0LXQutGB0YIgPSAi0J3QsNGB0LvQtdC00YPQtdC80L7QtSDRgdC+0LHRi9GC0LjQtSI7DQrQndCw0LTQv9C40YHRjDEyLtCo0YDQuNGE0YIgPSDQpC7QqNGA0LjRhNGCKCJNaWNyb3NvZnQgU2FucyBTZXJpZiIsIDkuNzUsICk7DQpb0J3QsNC00L/QuNGB0YwxMj5dDQpbPNCd0LDQtNC/0LjRgdGMMTNdDQrQndCw0LTQv9C40YHRjDEzLtCg0L7QtNC40YLQtdC70YwgPSDQoNCw0LzQutCw0JPRgNGD0L/Qv9GLMTsNCtCd0LDQtNC/0LjRgdGMMTMu0KDQsNC30LzQtdGAID0g0KQu0KDQsNC30LzQtdGAKDExMywgMjMpOw0K0J3QsNC00L/QuNGB0YwxMy7Qn9C+0YDRj9C00L7QutCe0LHRhdC+0LTQsCA9IDE7DQrQndCw0LTQv9C40YHRjDEzLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoNiwgMTgpOw0K0J3QsNC00L/QuNGB0YwxMy7QotC10LrRgdGCID0gItCj0L3QsNGB0LvQtdC00L7QstCw0L3QviDQvtGCIjsNCtCd0LDQtNC/0LjRgdGMMTMu0KjRgNC40YTRgiA9INCkLtCo0YDQuNGE0YIoIk1pY3Jvc29mdCBTYW5zIFNlcmlmIiwgOS43NSwgKTsNClvQndCw0LTQv9C40YHRjDEzPl0NCls80J/QvtC70LXQktGL0LHQvtGA0LA1XQ0K0J/QvtC70LXQktGL0LHQvtGA0LA1LtCg0L7QtNC40YLQtdC70YwgPSDQoNCw0LzQutCw0JPRgNGD0L/Qv9GLMTsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwNS7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMzgyLCAyNCk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDUu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAyOw0K0J/QvtC70LXQktGL0LHQvtGA0LA1LtCS0YvRgdC+0YLQsNCt0LvQtdC80LXQvdGC0LAgPSAxNjsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwNS7QmNC90LTQtdC60YHQktGL0LHRgNCw0L3QvdC+0LPQvtCY0LfQvNC10L3QtdC9ID0gItCX0LDQv9C+0LvQvdC40YLRjNCd0LDRgdC70LXQtNGD0LXQvNGL0LUiOw0K0J/QvtC70LXQktGL0LHQvtGA0LA1LtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMTI1LCAxNSk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDUu0KjQuNGA0LjQvdCw0JLRi9C/0LDQtNCw0Y7RidC10LPQvtCh0L/QuNGB0LrQsCA9IDQyODsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwNS7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cf0L7Qu9C10JLRi9Cx0L7RgNCwNT5dDQpbPNCf0L7Qu9C10JLRi9Cx0L7RgNCwNl0NCtCf0L7Qu9C10JLRi9Cx0L7RgNCwNi7QoNC+0LTQuNGC0LXQu9GMID0g0KDQsNC80LrQsNCT0YDRg9C/0L/RizE7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDYu0KDQsNC30LzQtdGAID0g0KQu0KDQsNC30LzQtdGAKDQxNywgMjQpOw0K0J/QvtC70LXQktGL0LHQvtGA0LA2LtCf0L7RgNGP0LTQvtC60J7QsdGF0L7QtNCwID0gMzsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwNi7QktGL0YHQvtGC0LDQrdC70LXQvNC10L3RgtCwID0gMTY7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDYu0JjQvdC00LXQutGB0JLRi9Cx0YDQsNC90L3QvtCz0L7QmNC30LzQtdC90LXQvSA9ICLQndCw0YHQu9C10LTQvtCy0LDRgtGM0KHQvtCx0YvRgtC40LUiOw0K0J/QvtC70LXQktGL0LHQvtGA0LA2LtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMTYxLCA0NSk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDYu0KjQuNGA0LjQvdCw0JLRi9C/0LDQtNCw0Y7RidC10LPQvtCh0L/QuNGB0LrQsCA9IDQxNzsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwNi7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cf0L7Qu9C10JLRi9Cx0L7RgNCwNj5dDQpbPNCk0LvQsNC20L7QujFdDQrQpNC70LDQttC+0LoxLtCg0L7QtNC40YLQtdC70YwgPSDQoNCw0LzQutCw0JPRgNGD0L/Qv9GLMTsNCtCk0LvQsNC20L7QujEu0KDQsNC30LzQtdGAID0g0KQu0KDQsNC30LzQtdGAKDc3LCAyNCk7DQrQpNC70LDQttC+0LoxLtCf0L7RgNGP0LTQvtC60J7QsdGF0L7QtNCwID0gNDsNCtCk0LvQsNC20L7QujEu0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCg1MTMsIDE1KTsNCtCk0LvQsNC20L7QujEu0KLQtdC60YHRgiA9ICLQkNCy0YLQvtC80LDRgiI7DQrQpNC70LDQttC+0LoxLtCo0YDQuNGE0YIgPSDQpC7QqNGA0LjRhNGCKCJNaWNyb3NvZnQgU2FucyBTZXJpZiIsIDkuNzUsICk7DQpb0KTQu9Cw0LbQvtC6MT5dDQpb0KHQstC+0LnRgdGC0LLQsD5dDQo=";
    ПодключитьВнешнююКомпоненту("OneScriptForms.dll");
    Ф = Новый ФормыДляОдноСкрипта();

    Форма_0 = Ф.Форма();
    Форма_0.Отображать = Истина;
    Форма_0.Показать();
    Форма_0.Активизировать();

    Кнопка1 = Ф.Кнопка();
    Надпись2 = Ф.Надпись();
    Надпись5 = Ф.Надпись();
    Надпись6 = Ф.Надпись();
    ПолеВвода3 = Ф.ПолеВвода();
    ПолеВвода4 = Ф.ПолеВвода();
    Надпись7 = Ф.Надпись();
    ПолеВыбора1 = Ф.ПолеВыбора();
    Надпись8 = Ф.Надпись();
    ПолеВыбора2 = Ф.ПолеВыбора();
    Надпись9 = Ф.Надпись();
    ПолеВвода5 = Ф.ПолеВвода();
    ПолеВыбора3 = Ф.ПолеВыбора();
    Надпись11 = Ф.Надпись();
    Надпись1 = Ф.Надпись();
    ПолеВыбора4 = Ф.ПолеВыбора();
    РамкаГруппы1 = Ф.РамкаГруппы();
    Надпись12 = Ф.Надпись();
    Надпись13 = Ф.Надпись();
    ПолеВыбора5 = Ф.ПолеВыбора();
    ПолеВыбора6 = Ф.ПолеВыбора();
    Флажок1 = Ф.Флажок();

    Форма_0.Размер = Ф.Размер(649, 534);
    Форма_0.Текст = "Создание события";
    Форма_0.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Кнопка1.Родитель = Форма_0;
    Кнопка1.Размер = Ф.Размер(127, 23);
    Кнопка1.ПорядокОбхода = 0;
    Кнопка1.Нажатие = Ф.Действие(ЭтотОбъект, "Кн_Нажатие");
    Кнопка1.Положение = Ф.Точка(470, 459);
    Кнопка1.Текст = "Создать событие";
    Кнопка1.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись2.Родитель = Форма_0;
    Надпись2.Размер = Ф.Размер(352, 23);
    Надпись2.ПорядокОбхода = 2;
    Надпись2.Положение = Ф.Точка(19, 462);
    Надпись2.Текст = "Выходные данные будут в каталоге НовыеHtml";
    Надпись2.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись5.Родитель = Форма_0;
    Надпись5.Размер = Ф.Размер(142, 17);
    Надпись5.ПорядокОбхода = 7;
    Надпись5.Положение = Ф.Точка(18, 195);
    Надпись5.Текст = "СобытиеИмяРус";
    Надпись5.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись6.Родитель = Форма_0;
    Надпись6.Размер = Ф.Размер(125, 16);
    Надпись6.ПорядокОбхода = 8;
    Надпись6.Положение = Ф.Точка(319, 196);
    Надпись6.Текст = "СобытиеИмяEn";
    Надпись6.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВвода3.Родитель = Форма_0;
    ПолеВвода3.Размер = Ф.Размер(296, 22);
    ПолеВвода3.ПорядокОбхода = 9;
    ПолеВвода3.Положение = Ф.Точка(17, 215);
    ПолеВвода3.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВвода4.Родитель = Форма_0;
    ПолеВвода4.Размер = Ф.Размер(296, 22);
    ПолеВвода4.ПорядокОбхода = 10;
    ПолеВвода4.Положение = Ф.Точка(319, 215);
    ПолеВвода4.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись7.Родитель = Форма_0;
    Надпись7.Размер = Ф.Размер(157, 18);
    Надпись7.ПорядокОбхода = 11;
    Надпись7.Положение = Ф.Точка(18, 238);
    Надпись7.Текст = "Использование";
    Надпись7.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВыбора1.Родитель = Форма_0;
    ПолеВыбора1.Размер = Ф.Размер(295, 24);
    ПолеВыбора1.ПорядокОбхода = 12;
    ПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка("Только запись.", "Только запись."));
    ПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка("Только чтение.", "Только чтение."));
    ПолеВыбора1.Элементы.Добавить(Ф.ЭлементСписка("Чтение и запись.", "Чтение и запись."));
    ПолеВыбора1.ВысотаЭлемента = 16;
    ПолеВыбора1.Положение = Ф.Точка(18, 259);
    ПолеВыбора1.Текст = "Только запись.";
    ПолеВыбора1.ШиринаВыпадающегоСписка = 295;
    ПолеВыбора1.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись8.Родитель = Форма_0;
    Надпись8.Размер = Ф.Размер(132, 17);
    Надпись8.ПорядокОбхода = 13;
    Надпись8.Положение = Ф.Точка(17, 292);
    Надпись8.Текст = "ЗначениеТип";
    Надпись8.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВыбора2.Родитель = Форма_0;
    ПолеВыбора2.Размер = Ф.Размер(597, 24);
    ПолеВыбора2.ПорядокОбхода = 14;
    ПолеВыбора2.Элементы.Добавить(Ф.ЭлементСписка("Булево.", "Булево."));
    ПолеВыбора2.Элементы.Добавить(Ф.ЭлементСписка("Строка.", "Строка."));
    ПолеВыбора2.Элементы.Добавить(Ф.ЭлементСписка("Число.", "Число."));
    ПолеВыбора2.Элементы.Добавить(Ф.ЭлементСписка("Произвольный.", "Произвольный."));
    ПолеВыбора2.Элементы.Добавить(Ф.ЭлементСписка("йййййййййй   йййййййййй", "йййййййййй   йййййййййй"));
    ПолеВыбора2.ВысотаЭлемента = 16;
    ПолеВыбора2.Положение = Ф.Точка(18, 312);
    ПолеВыбора2.Текст = "Булево.";
    ПолеВыбора2.ШиринаВыпадающегоСписка = 597;
    ПолеВыбора2.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись9.Родитель = Форма_0;
    Надпись9.Размер = Ф.Размер(158, 18);
    Надпись9.ПорядокОбхода = 15;
    Надпись9.Положение = Ф.Точка(17, 345);
    Надпись9.Текст = "ЗначениеОписание";
    Надпись9.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВвода5.Родитель = Форма_0;
    ПолеВвода5.Размер = Ф.Размер(597, 87);
    ПолеВвода5.ПорядокОбхода = 16;
    ПолеВвода5.МногострочныйРежим = Истина;
    ПолеВвода5.Положение = Ф.Точка(18, 366);
    ПолеВвода5.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВыбора3.Родитель = Форма_0;
    ПолеВыбора3.Размер = Ф.Размер(295, 24);
    ПолеВыбора3.ПорядокОбхода = 21;
    ПолеВыбора3.ВысотаЭлемента = 16;
    ПолеВыбора3.Положение = Ф.Точка(18, 42);
    ПолеВыбора3.ШиринаВыпадающегоСписка = 296;
    ПолеВыбора3.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись11.Родитель = Форма_0;
    Надпись11.Размер = Ф.Размер(153, 16);
    Надпись11.ПорядокОбхода = 22;
    Надпись11.Положение = Ф.Точка(19, 23);
    Надпись11.Текст = "Класс";
    Надпись11.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись1.Родитель = Форма_0;
    Надпись1.Размер = Ф.Размер(145, 23);
    Надпись1.ПорядокОбхода = 23;
    Надпись1.Положение = Ф.Точка(19, 77);
    Надпись1.Текст = "Копируемое событие";
    Надпись1.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВыбора4.Родитель = Форма_0;
    ПолеВыбора4.Размер = Ф.Размер(446, 24);
    ПолеВыбора4.ПорядокОбхода = 24;
    ПолеВыбора4.ВысотаЭлемента = 16;
    ПолеВыбора4.ИндексВыбранногоИзменен = Ф.Действие(ЭтотОбъект, "КопироватьСобытие");
    ПолеВыбора4.Положение = Ф.Точка(169, 74);
    ПолеВыбора4.ШиринаВыпадающегоСписка = 446;
    ПолеВыбора4.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    РамкаГруппы1.Родитель = Форма_0;
    РамкаГруппы1.Размер = Ф.Размер(596, 80);
    РамкаГруппы1.ПорядокОбхода = 25;
    РамкаГруппы1.Положение = Ф.Точка(19, 104);
    РамкаГруппы1.Текст = "Наследование";
    РамкаГруппы1.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись12.Родитель = РамкаГруппы1;
    Надпись12.Размер = Ф.Размер(149, 23);
    Надпись12.ПорядокОбхода = 0;
    Надпись12.Положение = Ф.Точка(6, 48);
    Надпись12.Текст = "Наследуемое событие";
    Надпись12.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись13.Родитель = РамкаГруппы1;
    Надпись13.Размер = Ф.Размер(113, 23);
    Надпись13.ПорядокОбхода = 1;
    Надпись13.Положение = Ф.Точка(6, 18);
    Надпись13.Текст = "Унаследовано от";
    Надпись13.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВыбора5.Родитель = РамкаГруппы1;
    ПолеВыбора5.Размер = Ф.Размер(382, 24);
    ПолеВыбора5.ПорядокОбхода = 2;
    ПолеВыбора5.ВысотаЭлемента = 16;
    ПолеВыбора5.ИндексВыбранногоИзменен = Ф.Действие(ЭтотОбъект, "ЗаполнитьНаследуемые");
    ПолеВыбора5.Положение = Ф.Точка(125, 15);
    ПолеВыбора5.ШиринаВыпадающегоСписка = 428;
    ПолеВыбора5.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВыбора6.Родитель = РамкаГруппы1;
    ПолеВыбора6.Размер = Ф.Размер(417, 24);
    ПолеВыбора6.ПорядокОбхода = 3;
    ПолеВыбора6.ВысотаЭлемента = 16;
    ПолеВыбора6.ИндексВыбранногоИзменен = Ф.Действие(ЭтотОбъект, "НаследоватьСобытие");
    ПолеВыбора6.Положение = Ф.Точка(161, 45);
    ПолеВыбора6.ШиринаВыпадающегоСписка = 417;
    ПолеВыбора6.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Флажок1.Родитель = РамкаГруппы1;
    Флажок1.Размер = Ф.Размер(77, 24);
    Флажок1.ПорядокОбхода = 4;
    Флажок1.Положение = Ф.Точка(513, 15);
    Флажок1.Текст = "Автомат";
    Флажок1.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

КонецПроцедуры

Функция РазобратьСтроку(Строка, Разделитель)
	Стр = СтрЗаменить(Строка,Разделитель,символы.ПС);
	М = Новый Массив;
	Если ПустаяСтрока(Стр) Тогда
		Возврат М;
	КонецЕсли;
	Для Ч = 1 По СтрЧислоСтрок(Стр) Цикл
		М.Добавить(СтрПолучитьСтроку(Стр,Ч));
	КонецЦикла;
	Возврат М;
КонецФункции

Функция СтрНайтиМежду(СтрПараметр, Фрагмент1 = Неопределено, Фрагмент2 = Неопределено, ИсключитьФрагменты = Истина, БезНаложения = Истина)
	//Стр - исходная строка
	//Фрагмент1 - подстрока поиска от которой ведем поиск
	//Фрагмент2 - подстрока поиска до которой ведем поиск
	//ИсключитьФрагменты - не включать Фрагмент1 и Фрагмент2 в результат
	//БезНаложения - в результат не будут включены участки, содержащие другие найденные участки, удовлетворяющие переданным параметрам
	//функция возвращает массив строк
	Стр = СтрПараметр;
	М = Новый Массив;
	Если (Фрагмент1 <> Неопределено) и (Фрагмент2 = Неопределено) Тогда
		Позиция = Найти(Стр, Фрагмент1);
		Пока Позиция > 0 Цикл
			М.Добавить(?(ИсключитьФрагменты, Сред(Стр, Позиция + СтрДлина(Фрагмент1)), Сред(Стр, Позиция)));
			Стр = Сред(Стр, Позиция + 1);
			Позиция = Найти(Стр, Фрагмент1);
		КонецЦикла;
	ИначеЕсли (Фрагмент1 = Неопределено) и (Фрагмент2 <> Неопределено) Тогда
		Позиция = Найти(Стр, Фрагмент2);
		СуммаПозиций = Позиция;
		Пока Позиция > 0 Цикл
			М.Добавить(?(ИсключитьФрагменты, Сред(Стр, 1, СуммаПозиций - 1), Сред(Стр, 1, СуммаПозиций - 1 + СтрДлина(Фрагмент2))));
			Позиция = Найти(Сред(Стр, СуммаПозиций + 1), Фрагмент2);
			СуммаПозиций = СуммаПозиций + Позиция;
		КонецЦикла;
	ИначеЕсли (Фрагмент1 <> Неопределено) и (Фрагмент2 <> Неопределено) Тогда
		Позиция = Найти(Стр, Фрагмент1);
		Пока Позиция > 0 Цикл
			Стр2 = ?(ИсключитьФрагменты, Сред(Стр, Позиция + СтрДлина(Фрагмент1)), Сред(Стр, Позиция));
			Позиция2 = Найти(Стр2, Фрагмент2);
			СуммаПозиций2 = Позиция2;
			Пока Позиция2 > 0 Цикл
				Если БезНаложения Тогда
					Если Найти(Сред(Стр2, 1, СуммаПозиций2 - 1), Фрагмент2) = 0 Тогда
						М.Добавить("" + ?(ИсключитьФрагменты, Сред(Стр2, 1, СуммаПозиций2 - 1), Сред(Стр2, 1, СуммаПозиций2 - 1 + СтрДлина(Фрагмент2))));
					КонецЕсли;
				Иначе
					М.Добавить("" + ?(ИсключитьФрагменты, Сред(Стр2, 1, СуммаПозиций2 - 1), Сред(Стр2, 1, СуммаПозиций2 - 1 + СтрДлина(Фрагмент2))));
				КонецЕсли;
				Позиция2 = Найти(Сред(Стр2, СуммаПозиций2 + 1), Фрагмент2);
				СуммаПозиций2 = СуммаПозиций2 + Позиция2;
			КонецЦикла;
			Стр = Сред(Стр, Позиция + 1);
			Позиция = Найти(Стр, Фрагмент1);
		КонецЦикла;
	КонецЕсли;
	
	Возврат М;
КонецФункции//СтрНайтиМежду

Процедура ПолучитьКлассы()
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptGameForms\docs\doc.html");
	Стр = ТекстДок.ПолучитьТекст();
	М = СтрНайтиМежду(Стр, "menu3", "</summary>", , );
	Если М.Количество() > 0 Тогда
		Для А = 0 По М.ВГраница() Цикл
			СтрЗаголовка= М[А];
			М2 = СтрНайтиМежду(СтрЗаголовка, "right"">", "</a>", , );
			// Сообщить("М2[0] = " + М2[0]);
			ПолеВыбора3.Элементы.Добавить(М2[0]);
		КонецЦикла;
	КонецЕсли;
КонецПроцедуры

ПодготовкаКомпонентов();

ВыходнойКаталог = "C:\444\OneScriptGameForms\НовыеHtml";// без слэша в конце
КлассИмяРус = "йййййййййй";//!!!!!!!!!!!!!!!!!!!!
КлассИмяEn = "йййййййййй";//!!!!!!!!!!!!!!!!!!!!
СобытиеИмяРус = "йййййййййй";//!!!!!!!!!!!!!!!!!!!!
СобытиеИмяEn = "йййййййййй";//!!!!!!!!!!!!!!!!!!!!
Использование = "йййййййййй";//!!!!!!!!!!!!!!!!!!!!
ЗначениеТип = "йййййййййй";//!!!!!!!!!!!!!!!!!!!!
ЗначениеОписание = "йййййййййй";//!!!!!!!!!!!!!!!!!!!!

ПолучитьКлассы();

НачальноеЗаполнениеФормы();

Ф.ЗапуститьОбработкуСобытий();
