Перем Ф;
Перем Кнопка1;
Перем Надпись1;
Перем Надпись2;
Перем Надпись3;
Перем Надпись4;
Перем ПолеВвода1;
Перем ПолеВвода2;
Перем ПолеВвода3;
Перем Форма_0;
Перем ИмяРус;
Перем ИмяEn;
Перем Описание;
Перем Надпись5;
Перем ВыходнойКаталог;
Перем ПолеВыбора1;
Перем Флажок1;

Процедура Кн1_Нажатие() Экспорт
	ИмяРус = СокрЛП(ПолеВвода1.Текст);
	ИмяEn = СокрЛП(ПолеВвода2.Текст);
	Описание = СокрЛП(ПолеВвода3.Текст);

    СоздатьКласс();
КонецПроцедуры

Процедура ПодготовкаКомпонентов()
    // ВАЖНО: Необходимая процедура для поддержки конструктора — не изменяйте содержимое этой процедуры с помощью редактора кода.
    // osdText = "WzzQmtC+0L3RgdGC0YDRg9C60YLQvtGA0YtdDQrQpNC+0YDQvNCwXzAgPSDQpC7QpNC+0YDQvNCwKCk7DQrQndCw0LTQv9C40YHRjDEgPSDQpC7QndCw0LTQv9C40YHRjCgpOw0K0J3QsNC00L/QuNGB0YwyID0g0KQu0J3QsNC00L/QuNGB0YwoKTsNCtCf0L7Qu9C10JLQstC+0LTQsDEgPSDQpC7Qn9C+0LvQtdCS0LLQvtC00LAoKTsNCtCf0L7Qu9C10JLQstC+0LTQsDIgPSDQpC7Qn9C+0LvQtdCS0LLQvtC00LAoKTsNCtCd0LDQtNC/0LjRgdGMMyA9INCkLtCd0LDQtNC/0LjRgdGMKCk7DQrQn9C+0LvQtdCS0LLQvtC00LAzID0g0KQu0J/QvtC70LXQktCy0L7QtNCwKCk7DQrQmtC90L7Qv9C60LAxID0g0KQu0JrQvdC+0L/QutCwKCk7DQrQndCw0LTQv9C40YHRjDQgPSDQpC7QndCw0LTQv9C40YHRjCgpOw0K0J3QsNC00L/QuNGB0Yw1ID0g0KQu0J3QsNC00L/QuNGB0YwoKTsNCtCk0LvQsNC20L7QujEgPSDQpC7QpNC70LDQttC+0LooKTsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMSA9INCkLtCf0L7Qu9C10JLRi9Cx0L7RgNCwKCk7DQpb0JrQvtC90YHRgtGA0YPQutGC0L7RgNGLPl0NCls80KHQstC+0LnRgdGC0LLQsF0NCls80KTQvtGA0LzQsF8wXQ0K0KTQvtGA0LzQsF8wLtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCg2NDAsIDUwMSk7DQrQpNC+0YDQvNCwXzAu0J/Rg9GC0YwgPSAiQzpcNDQ0XE9uZVNjcmlwdEdhbWVGb3Jtc1zQpNCw0LHRgNC40LrQsEh0bWxc0KHQvtC30LTQsNC90LjQtdCa0LvQsNGB0YHQsC5vcyI7DQrQpNC+0YDQvNCwXzAu0KHRgtC40LvRjNCh0LrRgNC40L/RgtCwID0gItCh0YLQuNC70YzQodC60YDQuNC/0YLQsCI7DQrQpNC+0YDQvNCwXzAu0KLQtdC60YHRgiA9ICLQodC+0LfQtNCw0L3QuNC1INC60LvQsNGB0YHQsCI7DQrQpNC+0YDQvNCwXzAu0KjRgNC40YTRgiA9INCkLtCo0YDQuNGE0YIoIk1pY3Jvc29mdCBTYW5zIFNlcmlmIiwgOS43NSwgKTsNCtCk0L7RgNC80LBfMC7QmNC80Y/QntCx0YrQtdC60YLQsNCk0L7RgNC80YvQlNC70Y/QntC00L3QvtCh0LrRgNC40L/RgtCwID0gItCkIjsNClvQpNC+0YDQvNCwXzA+XQ0KWzzQndCw0LTQv9C40YHRjDFdDQrQndCw0LTQv9C40YHRjDEu0KDQvtC00LjRgtC10LvRjCA9INCk0L7RgNC80LBfMDsNCtCd0LDQtNC/0LjRgdGMMS7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMTAwLCAxOCk7DQrQndCw0LTQv9C40YHRjDEu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAwOw0K0J3QsNC00L/QuNGB0YwxLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMjYsIDI3KTsNCtCd0LDQtNC/0LjRgdGMMS7QotC10LrRgdGCID0gItCY0LzRj9Cg0YPRgSI7DQrQndCw0LTQv9C40YHRjDEu0KjRgNC40YTRgiA9INCkLtCo0YDQuNGE0YIoIk1pY3Jvc29mdCBTYW5zIFNlcmlmIiwgOS43NSwgKTsNClvQndCw0LTQv9C40YHRjDE+XQ0KWzzQndCw0LTQv9C40YHRjDJdDQrQndCw0LTQv9C40YHRjDIu0KDQvtC00LjRgtC10LvRjCA9INCk0L7RgNC80LBfMDsNCtCd0LDQtNC/0LjRgdGMMi7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMTAwLCAxOCk7DQrQndCw0LTQv9C40YHRjDIu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAwOw0K0J3QsNC00L/QuNGB0YwyLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMjYsIDkxKTsNCtCd0LDQtNC/0LjRgdGMMi7QotC10LrRgdGCID0gItCY0LzRj0VuIjsNCtCd0LDQtNC/0LjRgdGMMi7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cd0LDQtNC/0LjRgdGMMj5dDQpbPNCf0L7Qu9C10JLQstC+0LTQsDFdDQrQn9C+0LvQtdCS0LLQvtC00LAxLtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQn9C+0LvQtdCS0LLQvtC00LAxLtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCg1NjcsIDIyKTsNCtCf0L7Qu9C10JLQstC+0LTQsDEu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAxOw0K0J/QvtC70LXQktCy0L7QtNCwMS7Qn9C+0LvQvtC20LXQvdC40LUgPSDQpC7QotC+0YfQutCwKDI2LCA0OCk7DQrQn9C+0LvQtdCS0LLQvtC00LAxLtCo0YDQuNGE0YIgPSDQpC7QqNGA0LjRhNGCKCJNaWNyb3NvZnQgU2FucyBTZXJpZiIsIDkuNzUsICk7DQpb0J/QvtC70LXQktCy0L7QtNCwMT5dDQpbPNCf0L7Qu9C10JLQstC+0LTQsDJdDQrQn9C+0LvQtdCS0LLQvtC00LAyLtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQn9C+0LvQtdCS0LLQvtC00LAyLtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCg1NjcsIDIyKTsNCtCf0L7Qu9C10JLQstC+0LTQsDIu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAyOw0K0J/QvtC70LXQktCy0L7QtNCwMi7Qn9C+0LvQvtC20LXQvdC40LUgPSDQpC7QotC+0YfQutCwKDI2LCAxMTIpOw0K0J/QvtC70LXQktCy0L7QtNCwMi7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cf0L7Qu9C10JLQstC+0LTQsDI+XQ0KWzzQndCw0LTQv9C40YHRjDNdDQrQndCw0LTQv9C40YHRjDMu0KDQvtC00LjRgtC10LvRjCA9INCk0L7RgNC80LBfMDsNCtCd0LDQtNC/0LjRgdGMMy7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMTAwLCAxOSk7DQrQndCw0LTQv9C40YHRjDMu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSAzOw0K0J3QsNC00L/QuNGB0YwzLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMjYsIDE1Nik7DQrQndCw0LTQv9C40YHRjDMu0KLQtdC60YHRgiA9ICLQntC/0LjRgdCw0L3QuNC1IjsNCtCd0LDQtNC/0LjRgdGMMy7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cd0LDQtNC/0LjRgdGMMz5dDQpbPNCf0L7Qu9C10JLQstC+0LTQsDNdDQrQn9C+0LvQtdCS0LLQvtC00LAzLtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQn9C+0LvQtdCS0LLQvtC00LAzLtCc0L3QvtCz0L7RgdGC0YDQvtGH0L3Ri9C50KDQtdC20LjQvCA9INCY0YHRgtC40L3QsDsNCtCf0L7Qu9C10JLQstC+0LTQsDMu0KDQsNC30LzQtdGAID0g0KQu0KDQsNC30LzQtdGAKDU2NywgODQpOw0K0J/QvtC70LXQktCy0L7QtNCwMy7Qn9C+0YDRj9C00L7QutCe0LHRhdC+0LTQsCA9IDI7DQrQn9C+0LvQtdCS0LLQvtC00LAzLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMjYsIDE3OCk7DQrQn9C+0LvQtdCS0LLQvtC00LAzLtCo0YDQuNGE0YIgPSDQpC7QqNGA0LjRhNGCKCJNaWNyb3NvZnQgU2FucyBTZXJpZiIsIDkuNzUsICk7DQpb0J/QvtC70LXQktCy0L7QtNCwMz5dDQpbPNCa0L3QvtC/0LrQsDFdDQrQmtC90L7Qv9C60LAxLtCg0L7QtNC40YLQtdC70YwgPSDQpNC+0YDQvNCwXzA7DQrQmtC90L7Qv9C60LAxLtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCgxMDcsIDIzKTsNCtCa0L3QvtC/0LrQsDEu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSA0Ow0K0JrQvdC+0L/QutCwMS7QndCw0LbQsNGC0LjQtSA9ICLQmtC9MV/QndCw0LbQsNGC0LjQtSI7DQrQmtC90L7Qv9C60LAxLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoNDg2LCAzOTUpOw0K0JrQvdC+0L/QutCwMS7QotC10LrRgdGCID0gItCh0L7Qt9C00LDRgtGMINC60LvQsNGB0YEiOw0K0JrQvdC+0L/QutCwMS7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Ca0L3QvtC/0LrQsDE+XQ0KWzzQndCw0LTQv9C40YHRjDRdDQrQndCw0LTQv9C40YHRjDQu0KDQvtC00LjRgtC10LvRjCA9INCk0L7RgNC80LBfMDsNCtCd0LDQtNC/0LjRgdGMNC7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMzY4LCAyMyk7DQrQndCw0LTQv9C40YHRjDQu0J/QvtGA0Y/QtNC+0LrQntCx0YXQvtC00LAgPSA1Ow0K0J3QsNC00L/QuNGB0Yw0LtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMjYsIDQxOCk7DQrQndCw0LTQv9C40YHRjDQu0KLQtdC60YHRgiA9ICLQktGL0YXQvtC00L3Ri9C1INC00LDQvdC90YvQtSDQsdGD0LTRg9GCINCyINC60LDRgtCw0LvQvtCz0LUgQzpcMDAwIjsNCtCd0LDQtNC/0LjRgdGMNC7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cd0LDQtNC/0LjRgdGMND5dDQpbPNCd0LDQtNC/0LjRgdGMNV0NCtCd0LDQtNC/0LjRgdGMNS7QoNC+0LTQuNGC0LXQu9GMID0g0KTQvtGA0LzQsF8wOw0K0J3QsNC00L/QuNGB0Yw1LtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCgzNjgsIDIzKTsNCtCd0LDQtNC/0LjRgdGMNS7Qn9C+0YDRj9C00L7QutCe0LHRhdC+0LTQsCA9IDY7DQrQndCw0LTQv9C40YHRjDUu0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCgyNiwgMzk1KTsNCtCd0LDQtNC/0LjRgdGMNS7QotC10LrRgdGCID0gItCY0YHRhdC+0LTQvdGL0LUg0LTQsNC90L3Ri9C1INC70LXQttCw0YIg0LIg0LrQsNGC0LDQu9C+0LPQtSBDOlw0NDRcT1NERm9ybXNSdSI7DQrQndCw0LTQv9C40YHRjDUu0KjRgNC40YTRgiA9INCkLtCo0YDQuNGE0YIoIk1pY3Jvc29mdCBTYW5zIFNlcmlmIiwgOS43NSwgKTsNClvQndCw0LTQv9C40YHRjDU+XQ0KWzzQpNC70LDQttC+0LoxXQ0K0KTQu9Cw0LbQvtC6MS7QoNC+0LTQuNGC0LXQu9GMID0g0KTQvtGA0LzQsF8wOw0K0KTQu9Cw0LbQvtC6MS7QoNCw0LfQvNC10YAgPSDQpC7QoNCw0LfQvNC10YAoMTgxLCAyNCk7DQrQpNC70LDQttC+0LoxLtCf0L7RgNGP0LTQvtC60J7QsdGF0L7QtNCwID0gNzsNCtCk0LvQsNC20L7QujEu0J/QvtC70L7QttC10L3QuNC1ID0g0KQu0KLQvtGH0LrQsCgyNiwgMjc4KTsNCtCk0LvQsNC20L7QujEu0KLQtdC60YHRgiA9ICLQo9C90LDRgdC70LXQtNC+0LLQsNC90L4g0L7RgiI7DQrQpNC70LDQttC+0LoxLtCo0YDQuNGE0YIgPSDQpC7QqNGA0LjRhNGCKCJNaWNyb3NvZnQgU2FucyBTZXJpZiIsIDkuNzUsICk7DQpb0KTQu9Cw0LbQvtC6MT5dDQpbPNCf0L7Qu9C10JLRi9Cx0L7RgNCwMV0NCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMS7QoNC+0LTQuNGC0LXQu9GMID0g0KTQvtGA0LzQsF8wOw0K0J/QvtC70LXQktGL0LHQvtGA0LAxLtCg0LDQt9C80LXRgCA9INCkLtCg0LDQt9C80LXRgCg1NjcsIDI0KTsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMS7Qn9C+0YDRj9C00L7QutCe0LHRhdC+0LTQsCA9IDg7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDEu0JLRi9GB0L7RgtCw0K3Qu9C10LzQtdC90YLQsCA9IDE2Ow0K0J/QvtC70LXQktGL0LHQvtGA0LAxLtCf0L7Qu9C+0LbQtdC90LjQtSA9INCkLtCi0L7Rh9C60LAoMjYsIDMwOCk7DQrQn9C+0LvQtdCS0YvQsdC+0YDQsDEu0KjQuNGA0LjQvdCw0JLRi9C/0LDQtNCw0Y7RidC10LPQvtCh0L/QuNGB0LrQsCA9IDU2NzsNCtCf0L7Qu9C10JLRi9Cx0L7RgNCwMS7QqNGA0LjRhNGCID0g0KQu0KjRgNC40YTRgigiTWljcm9zb2Z0IFNhbnMgU2VyaWYiLCA5Ljc1LCApOw0KW9Cf0L7Qu9C10JLRi9Cx0L7RgNCwMT5dDQpb0KHQstC+0LnRgdGC0LLQsD5dDQo=";
    ПодключитьВнешнююКомпоненту("OneScriptForms.dll");
    Ф = Новый ФормыДляОдноСкрипта();

    Форма_0 = Ф.Форма();
    Форма_0.Отображать = Истина;
    Форма_0.Показать();
    Форма_0.Активизировать();

    Надпись1 = Ф.Надпись();
    Надпись2 = Ф.Надпись();
    ПолеВвода1 = Ф.ПолеВвода();
    ПолеВвода2 = Ф.ПолеВвода();
    Надпись3 = Ф.Надпись();
    ПолеВвода3 = Ф.ПолеВвода();
    Кнопка1 = Ф.Кнопка();
    Надпись4 = Ф.Надпись();
    Надпись5 = Ф.Надпись();
    Флажок1 = Ф.Флажок();
    ПолеВыбора1 = Ф.ПолеВыбора();

    Форма_0.Размер = Ф.Размер(640, 501);
    Форма_0.Текст = "Создание класса";
    Форма_0.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись1.Родитель = Форма_0;
    Надпись1.Размер = Ф.Размер(100, 18);
    Надпись1.ПорядокОбхода = 0;
    Надпись1.Положение = Ф.Точка(26, 27);
    Надпись1.Текст = "ИмяРус";
    Надпись1.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись2.Родитель = Форма_0;
    Надпись2.Размер = Ф.Размер(100, 18);
    Надпись2.ПорядокОбхода = 0;
    Надпись2.Положение = Ф.Точка(26, 91);
    Надпись2.Текст = "ИмяEn";
    Надпись2.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВвода1.Родитель = Форма_0;
    ПолеВвода1.Размер = Ф.Размер(567, 22);
    ПолеВвода1.ПорядокОбхода = 1;
    ПолеВвода1.Положение = Ф.Точка(26, 48);
    ПолеВвода1.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВвода2.Родитель = Форма_0;
    ПолеВвода2.Размер = Ф.Размер(567, 22);
    ПолеВвода2.ПорядокОбхода = 2;
    ПолеВвода2.Положение = Ф.Точка(26, 112);
    ПолеВвода2.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись3.Родитель = Форма_0;
    Надпись3.Размер = Ф.Размер(100, 19);
    Надпись3.ПорядокОбхода = 3;
    Надпись3.Положение = Ф.Точка(26, 156);
    Надпись3.Текст = "Описание";
    Надпись3.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВвода3.Родитель = Форма_0;
    ПолеВвода3.Размер = Ф.Размер(567, 84);
    ПолеВвода3.ПорядокОбхода = 2;
    ПолеВвода3.МногострочныйРежим = Истина;
    ПолеВвода3.Положение = Ф.Точка(26, 178);
    ПолеВвода3.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Кнопка1.Родитель = Форма_0;
    Кнопка1.Размер = Ф.Размер(107, 23);
    Кнопка1.ПорядокОбхода = 4;
    Кнопка1.Нажатие = Ф.Действие(ЭтотОбъект, "Кн1_Нажатие");
    Кнопка1.Положение = Ф.Точка(486, 395);
    Кнопка1.Текст = "Создать класс";
    Кнопка1.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись4.Родитель = Форма_0;
    Надпись4.Размер = Ф.Размер(368, 23);
    Надпись4.ПорядокОбхода = 5;
    Надпись4.Положение = Ф.Точка(26, 418);
    Надпись4.Текст = "Выходные данные будут в каталоге C:\000";
    Надпись4.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Надпись5.Родитель = Форма_0;
    Надпись5.Размер = Ф.Размер(368, 23);
    Надпись5.ПорядокОбхода = 6;
    Надпись5.Положение = Ф.Точка(26, 395);
    Надпись5.Текст = "Исходные данные лежат в каталоге C:\444\OneScriptGameForms";
    Надпись5.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    Флажок1.Родитель = Форма_0;
    Флажок1.Размер = Ф.Размер(181, 24);
    Флажок1.ПорядокОбхода = 7;
    Флажок1.Положение = Ф.Точка(26, 278);
    Флажок1.Текст = "Унаследовано от";
    Флажок1.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

    ПолеВыбора1.Родитель = Форма_0;
    ПолеВыбора1.Размер = Ф.Размер(567, 24);
    ПолеВыбора1.ПорядокОбхода = 8;
    ПолеВыбора1.ВысотаЭлемента = 16;
    ПолеВыбора1.Положение = Ф.Точка(26, 308);
    ПолеВыбора1.ШиринаВыпадающегоСписка = 567;
    ПолеВыбора1.Шрифт = Ф.Шрифт("Microsoft Sans Serif", 9.75, );

КонецПроцедуры

Процедура НачальноеЗаполнениеФормы()
	ПолеВвода1.Текст = ИмяРус;
	ПолеВвода2.Текст = ИмяEn;
	ПолеВвода3.Текст = Описание;
	ПолеВыбора1.Текст = "ОбъектГодо GObject";
	
	ЗаполнитьПолеВыбора1();
	Флажок1.Помечен = Истина;
КонецПроцедуры

Процедура ЗаполнитьПолеВыбора1()
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
					ПолеВыбора1.Элементы.Добавить(СтрКласс);
				КонецЦикла;
			КонецЕсли;
		КонецЦикла;
	КонецЕсли;
КонецПроцедуры

Процедура СоздатьКласс()
	// Создадим ".html" для нового класса ===============================================================================
	
	СтрКласса = "<!DOCTYPE html>
	|<html lang=""ru"">
	|<head>
	|    <title>CCLLAASS Class</title>
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
	|            <h1 class=dtH1>ККЛЛААСС (CCLLAASS) Класс</h1>
	|        </div>
	|    </div>
	|    <div id=nstext>
	|        <h4 class=dtH4>Описание</h4>
	|        <p>" + Описание + "</p>
	|        <p></p>
	|        <h4 class=dtH4>Иерархия</h4>
	|        <p>
	|            <a href=""OSGForms.GObject.html"">ОбъектГодо (GObject)</a>
	|            <br>&nbsp;&nbsp;&nbsp;<b>ККЛЛААСС (CCLLAASS)</b>
	|        </p>
	|        <h4 class=dtH4>Смотрите также</h4>
	|        <p><a href=""OSGForms.html"">Библиотека&nbsp;OSGForms</a></p>
	|    </div>
	|</body>
	|</html>
	|";
	ПодстрокаПоиска = "ККЛЛААСС";
	ПодстрокаЗамены = ИмяРус;
	СтрКласса = СтрЗаменить(СтрКласса, ПодстрокаПоиска, ПодстрокаЗамены);

	ПодстрокаПоиска = "CCLLAASS";
	ПодстрокаЗамены = ИмяEn;
	СтрКласса = СтрЗаменить(СтрКласса, ПодстрокаПоиска, ПодстрокаЗамены);

	ТекстДок = Новый ТекстовыйДокумент;
	ИмяФайла = ВыходнойКаталог + "\OSGForms." + ИмяEn + ".html";
	ТекстДок.УстановитьТекст(СтрКласса);
	ТекстДок.Записать(ИмяФайла);
	
	Приостановить(1000);
	// ============================================================================================
	// Обновим иерархию.
	Если Флажок1.Помечен Тогда
		РодительДляИерархии = СокрЛП(ПолеВыбора1.Текст);
		// Сообщить("РодительДляИерархии = " + РодительДляИерархии);
		
		РодительДляИерархии2 = СтрЗаменить(РодительДляИерархии, " ", " (") + ")";
		ИмяEn2 = СтрНайтиМежду(РодительДляИерархии2, "(", ")", , )[0];
		// Сообщить("ИмяEn2 = " + ИмяEn2);
		ТекстДокРод = Новый ТекстовыйДокумент;
		ИмяФайла = "C:\444\OneScriptGameForms\docs\OSGForms\OSGForms." + ИмяEn2 + ".html";
		// Сообщить("ИмяФайла = " + ИмяФайла);
		ТекстДокРод.Прочитать(ИмяФайла);
		СтрРод = ТекстДокРод.ПолучитьТекст();
		М = СтрНайтиМежду(СтрРод, "<h4 class=dtH4>Иерархия</h4>", "</p>", Ложь, );
		Если М.Количество() > 0 Тогда
			СтрИерархияРод= М[0];
			// Сообщить("СтрИерархияРод = " + СтрИерархияРод);
			Искомое = "<b>" + РодительДляИерархии2 + "</b>";
			// Перебираю построчно СтрИерархияРод и после строки с РодительДляИерархии2 добавляю потомка
			СтрРезультат = "";
			Для А = 0 По СтрЧислоСтрок(СтрИерархияРод) Цикл
				ТекСтрока = СтрПолучитьСтроку(СтрИерархияРод, А);
				Индекс = СтрНайти(ТекСтрока, Искомое);
				Если Индекс > 0 Тогда
					Начало = Сред(ТекСтрока, 0, Индекс - 1);
					Фрагмент = Начало + "&nbsp;&nbsp;&nbsp;" + "<a href=""OSGForms." + ИмяEn + ".html"">" + ИмяРус + " (" + ИмяEn + ")</a>";
					СтрРезультат = СтрРезультат + ТекСтрока + Символы.ПС;
					СтрРезультат = СтрРезультат + Фрагмент + Символы.ПС;
				Иначе
					СтрРезультат = СтрРезультат + ТекСтрока + Символы.ПС;
				КонецЕсли;
			КонецЦикла;
			СтрРезультат = СокрЛП(СтрРезультат);
			// Сообщить("СтрРезультат = " + СтрРезультат);
			
			ПодстрокаПоиска = СтрИерархияРод;
			ПодстрокаЗамены = СтрРезультат;
			СтрРод = СтрЗаменить(СтрРод, ПодстрокаПоиска, ПодстрокаЗамены);
			// Сообщить("===");
			// Сообщить(СтрРод);
			// Сообщить("===");
			
			// Теперь нужно отсортировать наследников.
			Список = Новый СписокЗначений();
			М = СтрНайтиМежду(СтрРод, Искомое, "</p>", , );
			Если М.Количество() > 0 Тогда
				ДляСортировки = М[0];
				// Сообщить("ДляСортировки = " + ДляСортировки);
				Для А13 = 0 По СтрЧислоСтрок(ДляСортировки) Цикл
					Значение1 = СтрПолучитьСтроку(ДляСортировки, А13);
					Если Не СтрДлина(СокрЛП(Значение1)) = 0 Тогда
						// Сообщить("Значение1 = " + Значение1);
						М34 = СтрНайтиМежду(Значение1, ".html"">", "</a>", , );
						Если М34.Количество() > 0 Тогда
							Представление = М34[0];
							Если ПолеВыбора1.Текст = "ОбъектГодо GObject" Тогда
								Значение1 = СокрЛП(Значение1);
								Если СтрНайти(Значение1, "<br>") > 0 Тогда
									Значение1 = "            " + Значение1;
								Иначе
									Значение1 = "            <br>" + Значение1;
								КонецЕсли;
								Список.Добавить(Значение1, Представление);
							Иначе
								Список.Добавить(Значение1, Представление);
							КонецЕсли;
						Иначе
							Сообщить("Ошибка. Проверь теги на иерархию для " + Искомое);
						КонецЕсли;
					КонецЕсли;
				КонецЦикла;
				Список.СортироватьПоПредставлению();
				// Сообщить("Список.Количество() = " + Список.Количество());
				Отсортирован = "";
				Для А12 = 0 По Список.Количество() - 1 Цикл
					Отсортирован = Отсортирован + Список.Получить(А12).Значение + Символы.ПС;
				КонецЦикла;
				// Сообщить("Отсортирован = " + Отсортирован);
				Отсортирован = СокрП(Отсортирован);
				ПодстрокаПоиска = ДляСортировки;
				ПодстрокаЗамены = "
				|" + Отсортирован + "
				|        ";
				СтрРод = СтрЗаменить(СтрРод, ПодстрокаПоиска, ПодстрокаЗамены);
				// Сообщить("===");
				// Сообщить(СтрРод);
				// Сообщить("===");
				
				ИмяФайла = ВыходнойКаталог + "\OSGForms." + ИмяEn2 + ".html";
				ТекстДокРод.УстановитьТекст(СтрРод);
				ТекстДокРод.Записать(ИмяФайла);
			КонецЕсли;
			
			// Теперь нужно у самого нового класса создать иерархию.
			// Возмем иерархию родителя и подправим её.
			М = СтрНайтиМежду(СтрРод, "<h4 class=dtH4>Иерархия</h4>", "</p>", Ложь, );
			Если М.Количество() > 0 Тогда
				СтрИерархияНов= М[0];
				// Сообщить("СтрИерархияНов = " + СтрИерархияНов);
				М33 = СтрНайтиМежду(СтрИерархияНов, "<p>", Искомое, Ложь, );
				Если М33.Количество() > 0 Тогда
					Фрагмент14 = М33[0];
					// Сообщить("Фрагмент14 = " + Фрагмент14);
					Фрагмент15 = СтрЗаменить(Фрагмент14, Искомое, "");
					Фрагмент15 = Фрагмент15 + "<a href=""OSGForms." + ИмяEn2 + ".html"">" + РодительДляИерархии2 + "</a>";
					// Сообщить("Фрагмент15 = " + Фрагмент15);
					// Добавим ещё строку с новым классом.
					СтрШаблон = СтрПолучитьСтроку(Фрагмент15, СтрЧислоСтрок(Фрагмент15));
					СтрШаблон = СтрЗаменить(СтрШаблон, "<a href=""OSGForms." + ИмяEn2 + ".html"">" + РодительДляИерархии2 + "</a>", "");
					Если ПолеВыбора1.Текст = "ОбъектГодо GObject" Тогда
						СтрШаблон = СтрШаблон + "<br>&nbsp;&nbsp;&nbsp;<b>" + ИмяРус + " (" + ИмяEn + ")" + "</b>";
					Иначе
						СтрШаблон = СтрШаблон + "&nbsp;&nbsp;&nbsp;<b>" + ИмяРус + " (" + ИмяEn + ")" + "</b>";
					КонецЕсли;
					Фрагмент15 = Фрагмент15 + Символы.ПС + СтрШаблон + Символы.ПС;
					Фрагмент15 = СокрЛП(Фрагмент15);
					Фрагмент15 = "<h4 class=dtH4>Иерархия</h4>
					|        " + Фрагмент15 + "
					|        </p>";
					
					// Сообщить("СтрШаблон = " + СтрШаблон);
					// Сообщить("Фрагмент15 = " + Фрагмент15);
					
					ТекстДок12 = Новый ТекстовыйДокумент;
					ИмяФайла = ВыходнойКаталог + "\OSGForms." + ИмяEn + ".html";
					ТекстДок12.Прочитать(ИмяФайла);
					СтрНов = ТекстДок12.ПолучитьТекст();
					М = СтрНайтиМежду(СтрНов, "<h4 class=dtH4>Иерархия</h4>", "</p>", Ложь, );
					Если М.Количество() > 0 Тогда
						СтрИерархия12= М[0];
						// Сообщить("СтрИерархия12 = " + СтрИерархия12);
						ПодстрокаПоиска = СтрИерархия12;
						ПодстрокаЗамены = Фрагмент15;
						СтрНов = СтрЗаменить(СтрНов, ПодстрокаПоиска, ПодстрокаЗамены);
						// Сообщить("СтрНов = " + СтрНов);
						ТекстДок12.УстановитьТекст(СтрНов);
						ТекстДок12.Записать(ИмяФайла);
					КонецЕсли;
				КонецЕсли;
			КонецЕсли;
		КонецЕсли;
	Иначе
		// Объект ни от кого не наследуется.
		ТекстДок12 = Новый ТекстовыйДокумент;
		ИмяФайла = ВыходнойКаталог + "\OSGForms." + ИмяEn + ".html";
		ТекстДок12.Прочитать(ИмяФайла);
		СтрНов = ТекстДок12.ПолучитьТекст();
		М = СтрНайтиМежду(СтрНов, "<h4 class=dtH4>Иерархия</h4>", "</p>", Ложь, );
		Если М.Количество() > 0 Тогда
			СтрИерархия12= М[0];
			// Сообщить("СтрИерархия12 = " + СтрИерархия12);
			ПодстрокаПоиска = СтрИерархия12;
			ПодстрокаЗамены = СтрЗаменить(СтрИерархия12, "<p>
			|            <a href=""OSGForms.GObject.html"">ОбъектГодо (GObject)</a>", "<p>");
			ПодстрокаЗамены = СтрЗаменить(ПодстрокаЗамены, "<br>", "");
			// Сообщить("ПодстрокаЗамены = " + ПодстрокаЗамены);
			СтрНов = СтрЗаменить(СтрНов, ПодстрокаПоиска, ПодстрокаЗамены);
			// Сообщить("СтрНов = " + СтрНов);
			ТекстДок12.УстановитьТекст(СтрНов);
			ТекстДок12.Записать(ИмяФайла);
		КонецЕсли;
	КонецЕсли;

	// Создадим конструктор для нового класса ===============================================================================
	СтрКонструктор = "<!DOCTYPE html>
	|<html lang=""ru"">
	|<head>
	|    <title>CCLLAASS Constructor</title>
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
	|            <h1 class=dtH1>ККЛЛААСС (CCLLAASS)&nbsp;Конструктор</h1>
	|        </div>
	|    </div>
	|    <div id=nstext>
	|        <h4 class=dtH4>Синтаксис</h4>
	|        <p>ККЛЛААСС()</p>
	|        <h4 class=dtH4>Параметры</h4>
	|        <dl></dl>
	|        <h4 class=dtH4>Описание</h4>
	|        <p>Создаёт новый экземпляр класса <b>ККЛЛААСС&nbsp;(CCLLAASS)</b>.</p>
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
			
	Если Лев(Описание, 13) = "Базовый класс" Тогда
		ЭтоБазовыйКласс = Истина;
	КонецЕсли;

	Если ЭтоБазовыйКласс Тогда
	Иначе
		СтрКонструктор = СтрКонструктор + БлокПримеров;
	КонецЕсли;
	СтрКонструктор = СтрКонструктор + "
	|        <h4 class=dtH4>Смотрите также</h4>
	|        <p><a href=""OSGForms.html"">Библиотека&nbsp;OSGForms</a></p>
	|    </div>
	|</body>
	|</html>
	|";
	ПодстрокаПоиска = "ККЛЛААСС";
	ПодстрокаЗамены = ИмяРус;
	СтрКонструктор = СтрЗаменить(СтрКонструктор, ПодстрокаПоиска, ПодстрокаЗамены);

	ПодстрокаПоиска = "CCLLAASS";
	ПодстрокаЗамены = ИмяEn;
	СтрКонструктор = СтрЗаменить(СтрКонструктор, ПодстрокаПоиска, ПодстрокаЗамены);

	ТекстДок = Новый ТекстовыйДокумент;
	ИмяФайла = ВыходнойКаталог + "\OSGForms." + ИмяEn + "Constructor.html";
	ТекстДок.УстановитьТекст(СтрКонструктор);
	ТекстДок.Записать(ИмяФайла);

	// Создадим раздел События для нового класса ===============================================================================
	СтрСобытия = "<!DOCTYPE html>
	|<html lang=""ru"">
	|<head>
	|    <title>CCLLAASS</title>
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
	|            <h1 class=dtH1>ККЛЛААСС (CCLLAASS)&nbsp;События</h1>
	|        </div>
	|    </div>
	|    <div id=nstext>
	|        <p></p>
	|        <h4 class=dtH4>События</h4>
	|        <div class=tablediv>
	|            <table class=dtTABLE cellSpacing=0>
	|                <tbody>
	|                    <tr vAlign=top>
	|                        <td width=""50%""><a href=""OSGForms.CCLLAASS.йййййййййй.html"">йййййййййй&nbsp;(йййййййййй)</a></td>
	|                        <td width=""50%"">йййййййййй</td>
	|                    </tr>
	|                </tbody>
	|            </table>
	|        </div>
	|        <h4 class=dtH4>Смотрите также</h4>
	|        <p><a href=""OSGForms.html"">Библиотека&nbsp;OSGForms</a></p>
	|    </div>
	|</body>
	|</html>
	|";
	ПодстрокаПоиска = "ККЛЛААСС";
	ПодстрокаЗамены = ИмяРус;
	СтрСобытия = СтрЗаменить(СтрСобытия, ПодстрокаПоиска, ПодстрокаЗамены);

	ПодстрокаПоиска = "CCLLAASS";
	ПодстрокаЗамены = ИмяEn;
	СтрСобытия = СтрЗаменить(СтрСобытия, ПодстрокаПоиска, ПодстрокаЗамены);

	ТекстДок = Новый ТекстовыйДокумент;
	ИмяФайла = ВыходнойКаталог + "\OSGForms." + ИмяEn + "Events.html";
	ТекстДок.УстановитьТекст(СтрСобытия);
	ТекстДок.Записать(ИмяФайла);

	// Создадим раздел Методы для нового класса ===============================================================================
	СтрМетоды = "<!DOCTYPE html>
	|<html lang=""ru"">
	|<head>
	|    <title>CCLLAASS Methods</title>
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
	|            <h1 class=dtH1>ККЛЛААСС (CCLLAASS)&nbsp;Методы</h1>
	|        </div>
	|    </div>
	|    <div id=nstext>
	|        <p></p>
	|        <h4 class=dtH4>Методы</h4>
	|        <div class=tablediv>
	|            <table class=dtTABLE cellSpacing=0>
	|                <tbody>
	|                    <tr vAlign=top>
	|                        <td width=""50%""><img src=""pubmethod.gif""></img><a href=""OSGForms.CCLLAASS.йййййййййй.html"">йййййййййй&nbsp;(йййййййййй)</a></td>
	|                        <td width=""50%"">йййййййййй</td>
	|                    </tr>
	|                </tbody>
	|            </table>
	|        </div>
	|        <h4 class=dtH4>Смотрите также</h4>
	|        <p><a href=""OSGForms.html"">Библиотека&nbsp;OSGForms</a></p>
	|    </div>
	|</body>
	|</html>
	|";
	ПодстрокаПоиска = "ККЛЛААСС";
	ПодстрокаЗамены = ИмяРус;
	СтрМетоды = СтрЗаменить(СтрМетоды, ПодстрокаПоиска, ПодстрокаЗамены);

	ПодстрокаПоиска = "CCLLAASS";
	ПодстрокаЗамены = ИмяEn;
	СтрМетоды = СтрЗаменить(СтрМетоды, ПодстрокаПоиска, ПодстрокаЗамены);

	ТекстДок = Новый ТекстовыйДокумент;
	ИмяФайла = ВыходнойКаталог + "\OSGForms." + ИмяEn + "Methods.html";
	ТекстДок.УстановитьТекст(СтрМетоды);
	ТекстДок.Записать(ИмяФайла);

	// Создадим раздел Свойства для нового класса ===============================================================================
	СтрСвойства = "<!DOCTYPE html>
	|<html lang=""ru"">
	|<head>
	|    <title>CCLLAASS Properties</title>
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
	|            <h1 class=dtH1>ККЛЛААСС (CCLLAASS)&nbsp;Свойства</h1>
	|        </div>
	|    </div>
	|    <div id=nstext>
	|        <p></p>
	|        <h4 class=dtH4>Свойства</h4>
	|        <div class=tablediv>
	|            <table class=dtTABLE cellSpacing=0>
	|                <tbody>
	|                    <tr vAlign=top>
	|                        <td width=""50%""><img src=""pubproperty.gif""></img><a href=""OSGForms.CCLLAASS.йййййййййй.html"">йййййййййй&nbsp;(йййййййййй)</a></td>
	|                        <td width=""50%"">йййййййййй</td>
	|                    </tr>
	|                </tbody>
	|            </table>
	|        </div>
	|        <h4 class=dtH4>Смотрите также</h4>
	|        <p><a href=""OSGForms.html"">Библиотека&nbsp;OSGForms</a></p>
	|    </div>
	|</body>
	|</html>
	|";
	ПодстрокаПоиска = "ККЛЛААСС";
	ПодстрокаЗамены = ИмяРус;
	СтрСвойства = СтрЗаменить(СтрСвойства, ПодстрокаПоиска, ПодстрокаЗамены);

	ПодстрокаПоиска = "CCLLAASS";
	ПодстрокаЗамены = ИмяEn;
	СтрСвойства = СтрЗаменить(СтрСвойства, ПодстрокаПоиска, ПодстрокаЗамены);

	ТекстДок = Новый ТекстовыйДокумент;
	ИмяФайла = ВыходнойКаталог + "\OSGForms." + ИмяEn + "Properties.html";
	ТекстДок.УстановитьТекст(СтрСвойства);
	ТекстДок.Записать(ИмяФайла);

	// ============================================================================================
	// Добавим ссылку в ФайлДокHtml
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptGameForms\docs\doc.html");
	Стр = ТекстДок.ПолучитьТекст();
	М = СтрНайтиМежду(Стр, 
			"<summary class=""menu2""><a href=""OSGForms/OSGForms.html"" target=""right"">Классы</a>", 
			"</summary>", 
			Ложь, );
	Если М.Количество() > 0 Тогда
		СтрЗаголовка= М[0];
		// Сообщить("М[0] = " + М[0]);
		ПодстрокаПоиска = М[0];
		ПодстрокаЗамены = М[0] + "
		|					<details>
		|						<summary class=""menu3""><a href=""OSGForms/OSGForms.CCLLAASS.html"" target=""right"">ККЛЛААСС (CCLLAASS)</a></summary>
		|						<p class=""prop""><a href=""OSGForms/OSGForms.CCLLAASSConstructor.html"" target=""right"">Конструктор</a></p>
		|						<p class=""prop""><a href=""OSGForms/OSGForms.CCLLAASSEvents.html"" target=""right"">События</a></p>
		|						<p class=""prop""><a href=""OSGForms/OSGForms.CCLLAASSProperties.html"" target=""right"">Свойства</a></p>
		|						<p class=""prop""><a href=""OSGForms/OSGForms.CCLLAASSMethods.html"" target=""right"">Методы</a></p>
		|					</details>";
		ПодстрокаЗамены = СтрЗаменить(ПодстрокаЗамены, "ККЛЛААСС", ИмяРус);
		ПодстрокаЗамены = СтрЗаменить(ПодстрокаЗамены, "CCLLAASS", ИмяEn);
		Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
	КонецЕсли;
	ИмяФайла = ВыходнойКаталог + "\doc.html";
	ТекстДок.УстановитьТекст(Стр);
	ТекстДок.Записать(ИмяФайла);
	
	Приостановить(2000);
	СортироватьDoc();
	
	// ============================================================================================
	// Добавим ссылку в C:\444\OneScriptGameForms\docs\OSGForms\OSGForms.html
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать("C:\444\OneScriptGameForms\docs\OSGForms\OSGForms.html");
	Стр = ТекстДок.ПолучитьТекст();
	М = СтрНайтиМежду(Стр, 
			"<h3 class=dtH3>Классы</h3>
			|        <div class=tablediv>
			|            <table class=dtTABLE cellSpacing=0>
			|                <tbody>", 
			"                    <tr vAlign=top>", 
			Ложь, );
	Если М.Количество() > 0 Тогда
		СтрЗаголовка= М[0];
		// Сообщить("М[0] = " + М[0]);
		ПодстрокаПоиска = М[0];
		ПодстрокаЗамены = М[0] + "
		|                        <td width=""50%""><a href=""OSGForms." + ИмяEn + ".html"">" + ИмяРус + "&nbsp;(" + ИмяEn + ")</a></td>
		|                        <td width=""50%"">" + Описание + "</td>
		|                    </tr>
		|                    <tr vAlign=top>";
		Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
	КонецЕсли;
	
	ИмяФайла = ВыходнойКаталог + "\OSGForms.html";
	ТекстДок.УстановитьТекст(Стр);
	ТекстДок.Записать(ИмяФайла);
	
	Приостановить(2000);
	СортироватьOSGForms();
	ОкноСообщений1 = Ф.ОкноСообщений();
	ОкноСообщений1.Показать("Завершено", "Завершено");
КонецПроцедуры//СоздатьКласс

Процедура СортироватьOSGForms()
	Список = Новый СписокЗначений();
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ВыходнойКаталог + "\OSGForms.html");
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
	ИмяФайла = ВыходнойКаталог + "\OSGForms.html";
	ТекстДок.УстановитьТекст(Стр);
	ТекстДок.Записать(ИмяФайла);
КонецПроцедуры
	
Процедура СортироватьDoc()
	Список = Новый СписокЗначений();
	ТекстДок = Новый ТекстовыйДокумент;
	ТекстДок.Прочитать(ВыходнойКаталог + "\doc.html");
	Стр = ТекстДок.ПолучитьТекст();
	М = СтрНайтиМежду(Стр, 
		"<summary class=""menu2""><a href=""OSGForms/OSGForms.html"" target=""right"">Классы</a></summary>", 
		"</details><!-- end class -->", , );
	Если М.Количество() > 0 Тогда
		// Сообщить("" + М[0]);
		ПодстрокаПоиска = М[0];
		Для А = 0 По М.ВГраница() Цикл
			СтрЗаголовка= М[А];
			М2 = СтрНайтиМежду(СтрЗаголовка, "<details>", "</details>", , );
			Для А2 = 0 По М2.ВГраница() Цикл
				// Сообщить("М2[А2] = " + М2[А2]);
				
				М3 = СтрНайтиМежду(М2[А2], "menu3", "</summary>", , );
				Если М3.Количество() > 0 Тогда
					// Сообщить("М3[0] = " + М3[0]);
					М4 = СтрНайтиМежду(М3[0], "<a", "/a", , );
					Если М4.Количество() > 0 Тогда
						М5 = СтрНайтиМежду(М4[0], ">", "<", , );
						// <summary class="menu3"><a href="OSGForms/OSGForms.йййййййййй.html" target="right">Аудио11 (Audio)</a></summary>
						Если М5.Количество() > 0 Тогда
							// Сообщить("" + М5[0]);
							Список.Добавить(М2[А2], М5[0]);
						КонецЕсли;
					КонецЕсли;
				КонецЕсли;
			КонецЦикла;
		КонецЦикла;
	КонецЕсли;

	Список.СортироватьПоПредставлению();
	ПодстрокаЗамены = "";
	Для А = 0 По Список.Количество() - 1 Цикл
		// Сообщить("==" + Список.Получить(А).Значение);
		ПодстрокаЗамены = ПодстрокаЗамены + "
		|					<details>
		|						" + СокрЛП(Список.Получить(А).Значение) + "
		|					</details>";
	КонецЦикла;
	ПодстрокаЗамены = "					
	|					" + СокрЛ(ПодстрокаЗамены) + "
	|				";
	// Сообщить("=======================================");
	// Сообщить("" + ПодстрокаПоиска);
	// Сообщить("=======================================");
	// Сообщить("" + ПодстрокаЗамены);
	
	Стр = СтрЗаменить(Стр, ПодстрокаПоиска, ПодстрокаЗамены);
	ИмяФайла = ВыходнойКаталог + "\doc.html";
	ТекстДок.УстановитьТекст(Стр);
	ТекстДок.Записать(ИмяФайла);
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

ПодготовкаКомпонентов();

ВыходнойКаталог = "C:\444\OneScriptGameForms\НовыеHtml";// без слэша в конце
ИмяРус = "йййййййййй";//!!!!!!!!!!!!!!!!!!!!
ИмяEn = "йййййййййй";//!!!!!!!!!!!!!!!!!!!!
Описание = "йййййййййй";//!!!!!!!!!!!!!!!!!!!!

НачальноеЗаполнениеФормы();
// ...

Ф.ЗапуститьОбработкуСобытий();
