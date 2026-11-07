using OneScript.Contexts;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфЦвет", "GfColor")]
    public class GfColor : AutoContext<GfColor>
    {
        public GfColor()
        {
        }

        public GfColor MakeColor(int p1, int p2, int p3, int p4)
        {
            GfColor color = new GfColor();
            color.R = p1;
            color.G = p2;
            color.B = p3;
            color.A = p4;
            return color;
        }

        [ContextProperty("Аквамариновый", "Aquamarine")]
        public GfColor Aquamarine
        {
            get { return MakeColor(127, 255, 212, 255); }
        }

        [ContextProperty("АнтичныйБелый", "AntiqueWhite")]
        public GfColor AntiqueWhite
        {
            get { return MakeColor(250, 235, 215, 255); }
        }

        [ContextProperty("Бежевый", "Beige")]
        public GfColor Beige
        {
            get { return MakeColor(245, 245, 220, 255); }
        }

        [ContextProperty("БелаяДымка", "WhiteSmoke")]
        public GfColor WhiteSmoke
        {
            get { return MakeColor(245, 245, 245, 255); }
        }

        [ContextProperty("Белый", "White")]
        public GfColor White
        {
            get { return MakeColor(255, 255, 255, 255); }
        }

        [ContextProperty("БелыйНавахо", "NavajoWhite")]
        public GfColor NavajoWhite
        {
            get { return MakeColor(255, 222, 173, 255); }
        }

        [ContextProperty("Бирюзовый", "Turquoise")]
        public GfColor Turquoise
        {
            get { return MakeColor(64, 224, 208, 255); }
        }

        [ContextProperty("Бисквитный", "Bisque")]
        public GfColor Bisque
        {
            get { return MakeColor(255, 228, 196, 255); }
        }

        [ContextProperty("БледноБирюзовый", "PaleTurquoise")]
        public GfColor PaleTurquoise
        {
            get { return MakeColor(175, 238, 238, 255); }
        }

        [ContextProperty("БледноЖелтый", "Cornsilk")]
        public GfColor Cornsilk
        {
            get { return MakeColor(255, 248, 220, 255); }
        }

        [ContextProperty("БледноЗеленый", "PaleGreen")]
        public GfColor PaleGreen
        {
            get { return MakeColor(152, 251, 152, 255); }
        }

        [ContextProperty("БледноЗолотистый", "PaleGoldenrod")]
        public GfColor PaleGoldenrod
        {
            get { return MakeColor(238, 232, 170, 255); }
        }

        [ContextProperty("Васильковый", "CornflowerBlue")]
        public GfColor CornflowerBlue
        {
            get { return MakeColor(100, 149, 237, 255); }
        }

        [ContextProperty("ГлубокийРозовый", "DeepPink")]
        public GfColor DeepPink
        {
            get { return MakeColor(255, 20, 147, 255); }
        }

        [ContextProperty("Голубой", "DeepSkyBlue")]
        public GfColor DeepSkyBlue
        {
            get { return MakeColor(0, 191, 255, 255); }
        }

        [ContextProperty("ГрифельноСерый", "LightSlateGray")]
        public GfColor LightSlateGray
        {
            get { return MakeColor(119, 136, 153, 255); }
        }

        [ContextProperty("ГрифельноСиний", "SlateBlue")]
        public GfColor SlateBlue
        {
            get { return MakeColor(106, 90, 205, 255); }
        }

        [ContextProperty("ЖелтоЗеленый", "YellowGreen")]
        public GfColor YellowGreen
        {
            get { return MakeColor(154, 205, 50, 255); }
        }

        [ContextProperty("Желтый", "Yellow")]
        public GfColor Yellow
        {
            get { return MakeColor(255, 255, 0, 255); }
        }

        [ContextProperty("ЗащитноСиний", "DodgerBlue")]
        public GfColor DodgerBlue
        {
            get { return MakeColor(30, 144, 255, 255); }
        }

        [ContextProperty("ЗеленаяВесна", "SpringGreen")]
        public GfColor SpringGreen
        {
            get { return MakeColor(0, 255, 127, 255); }
        }

        [ContextProperty("ЗеленаяЛужайка", "LawnGreen")]
        public GfColor LawnGreen
        {
            get { return MakeColor(124, 252, 0, 255); }
        }

        [ContextProperty("ЗеленоеМоре", "SeaGreen")]
        public GfColor SeaGreen
        {
            get { return MakeColor(46, 139, 87, 255); }
        }

        [ContextProperty("ЗеленоЖелтый", "GreenYellow")]
        public GfColor GreenYellow
        {
            get { return MakeColor(173, 255, 47, 255); }
        }

        [ContextProperty("Зеленый", "Green")]
        public GfColor Green
        {
            get { return MakeColor(0, 128, 0, 255); }
        }

        [ContextProperty("ЗеленыйЛайм", "LimeGreen")]
        public GfColor LimeGreen
        {
            get { return MakeColor(50, 205, 50, 255); }
        }

        [ContextProperty("ЗеленыйЛесной", "ForestGreen")]
        public GfColor ForestGreen
        {
            get { return MakeColor(34, 139, 34, 255); }
        }

        [ContextProperty("ЗначениеАльфа", "A")]
        public int A { get; set; } = 255;

        [ContextProperty("ЗначениеЗеленый", "G")]
        public int G { get; set; } = 0;

        [ContextProperty("ЗначениеКрасный", "R")]
        public int R { get; set; } = 0;

        [ContextProperty("ЗначениеСиний", "B")]
        public int B { get; set; } = 0;

        [ContextProperty("Золотарник", "Goldenrod")]
        public GfColor Goldenrod
        {
            get { return MakeColor(218, 165, 32, 255); }
        }

        [ContextProperty("Золотой", "Gold")]
        public GfColor Gold
        {
            get { return MakeColor(255, 215, 0, 255); }
        }

        [ContextProperty("Имя", "Имя")]
        public string NameRu
        {
            get
            {
                string name = getNameRu(this);
                if (name != "")
                {
                    return name;
                }
                else
                {
                    decimal Dec1 = (A * 16777216) + (R * 65536) + (G * 256) + B;
                    if (Dec1 == 0)
                    {
                        return "Черный";
                    }
                    return "RGB(" + this.R.ToString() + ", " + this.G.ToString() + ", " + this.B.ToString() + ")";
                }
            }
        }

        [ContextProperty("Name", "Name")]
        public string NameEn
        {
            get
            {
                string name = getNameEn(this);
                if (name != "")
                {
                    return name;
                }
                else
                {
                    decimal Dec1 = (A * 16777216) + (R * 65536) + (G * 256) + B;
                    if (Dec1 == 0)
                    {
                        return "Black";
                    }
                    return "RGB(" + this.R.ToString() + ", " + this.G.ToString() + ", " + this.B.ToString() + ")";
                }
            }
        }

        public string getNameRu(GfColor p1)
        {
            string result = p1.ToString() switch
            {
                "{R:127 G:255 B:212 A:255}" => "Аквамариновый",
                "{R:250 G:235 B:215 A:255}" => "АнтичныйБелый",
                "{R:245 G:245 B:220 A:255}" => "Бежевый",
                "{R:245 G:245 B:245 A:255}" => "БелаяДымка",
                "{R:255 G:255 B:255 A:255}" => "Белый",
                "{R:255 G:222 B:173 A:255}" => "БелыйНавахо",
                "{R:64 G:224 B:208 A:255}" => "Бирюзовый",
                "{R:255 G:228 B:196 A:255}" => "Бисквитный",
                "{R:175 G:238 B:238 A:255}" => "БледноБирюзовый",
                "{R:255 G:248 B:220 A:255}" => "БледноЖелтый",
                "{R:152 G:251 B:152 A:255}" => "БледноЗеленый",
                "{R:238 G:232 B:170 A:255}" => "БледноЗолотистый",
                "{R:100 G:149 B:237 A:255}" => "Васильковый",
                "{R:255 G:20 B:147 A:255}" => "ГлубокийРозовый",
                "{R:0 G:191 B:255 A:255}" => "Голубой",
                "{R:119 G:136 B:153 A:255}" => "ГрифельноСерый",
                "{R:106 G:90 B:205 A:255}" => "ГрифельноСиний",
                "{R:154 G:205 B:50 A:255}" => "ЖелтоЗеленый",
                "{R:255 G:255 B:0 A:255}" => "Желтый",
                "{R:30 G:144 B:255 A:255}" => "ЗащитноСиний",
                "{R:0 G:255 B:127 A:255}" => "ЗеленаяВесна",
                "{R:124 G:252 B:0 A:255}" => "ЗеленаяЛужайка",
                "{R:46 G:139 B:87 A:255}" => "ЗеленоеМоре",
                "{R:173 G:255 B:47 A:255}" => "ЗеленоЖелтый",
                "{R:0 G:128 B:0 A:255}" => "Зеленый",
                "{R:50 G:205 B:50 A:255}" => "ЗеленыйЛайм",
                "{R:34 G:139 B:34 A:255}" => "ЗеленыйЛесной",
                "{R:218 G:165 B:32 A:255}" => "Золотарник",
                "{R:255 G:215 B:0 A:255}" => "Золотой",
                "{R:75 G:0 B:130 A:255}" => "Индиго",
                "{R:205 G:92 B:92 A:255}" => "ИндийскийКрасный",
                "{R:178 G:34 B:34 A:255}" => "Кирпичный",
                "{R:139 G:69 B:19 A:255}" => "КожаноКоричневый",
                "{R:255 G:127 B:80 A:255}" => "Коралловый",
                "{R:128 G:0 B:0 A:255}" => "КоричневоМалиновый",
                "{R:165 G:42 B:42 A:255}" => "Коричневый",
                "{R:65 G:105 B:225 A:255}" => "КоролевскийСиний",
                "{R:255 G:0 B:0 A:255}" => "Красный",
                "{R:220 G:20 B:60 A:255}" => "Кровавый",
                "{R:230 G:230 B:250 A:255}" => "Лаванда",
                "{R:240 G:255 B:255 A:255}" => "Лазурный",
                "{R:0 G:255 B:0 A:255}" => "Лайм",
                "{R:219 G:112 B:147 A:255}" => "Лиловый",
                "{R:250 G:128 B:114 A:255}" => "Лососевый",
                "{R:250 G:240 B:230 A:255}" => "Льняной",
                "{R:255 G:0 B:255 A:255}" => "Малиновый",
                "{R:240 G:255 B:240 A:255}" => "Медовый",
                "{R:255 G:228 B:181 A:255}" => "Мокасиновый",
                "{R:0 G:255 B:255 A:255}" => "МорскаяВолна",
                "{R:255 G:245 B:238 A:255}" => "МорскаяРакушка",
                "{R:245 G:255 B:250 A:255}" => "МятноКремовый",
                "{R:135 G:206 B:235 A:255}" => "НебесноГолубой",
                "{R:135 G:206 B:250 A:255}" => "НебесноГолубойСветлый",
                "{R:107 G:142 B:35 A:255}" => "НежноОливковый",
                "{R:128 G:128 B:0 A:255}" => "Оливковый",
                "{R:255 G:69 B:0 A:255}" => "ОранжевоКрасный",
                "{R:255 G:165 B:0 A:255}" => "Оранжевый",
                "{R:218 G:112 B:214 A:255}" => "Орхидея",
                "{R:160 G:82 B:45 A:255}" => "Охра",
                "{R:255 G:218 B:185 A:255}" => "Персиковый",
                "{R:244 G:164 B:96 A:255}" => "Песочный",
                "{R:255 G:239 B:213 A:255}" => "ПобегПапайи",
                "{R:25 G:25 B:112 A:255}" => "ПолуночноСиний",
                "{R:176 G:224 B:230 A:255}" => "ПороховаяСинь",
                "{R:248 G:248 B:255 A:255}" => "ПризрачноБелый",
                "{R:255 G:255 B:255 A:0}" => "Прозрачный",
                "{R:128 G:0 B:128 A:255}" => "Пурпурный",
                "{R:245 G:222 B:179 A:255}" => "Пшеничный",
                "{R:188 G:143 B:143 A:255}" => "РозовоКоричневый",
                "{R:255 G:240 B:245 A:255}" => "РозовоЛавандовый",
                "{R:255 G:192 B:203 A:255}" => "Розовый",
                "{R:32 G:178 B:170 A:255}" => "СветлаяМорскаяВолна",
                "{R:255 G:255 B:224 A:255}" => "СветлоЖелтый",
                "{R:250 G:250 B:210 A:255}" => "СветлоЖелтыйЗолотистый",
                "{R:144 G:238 B:144 A:255}" => "СветлоЗеленый",
                "{R:240 G:128 B:128 A:255}" => "СветлоКоралловый",
                "{R:205 G:133 B:63 A:255}" => "СветлоКоричневый",
                "{R:255 G:235 B:205 A:255}" => "СветлоКремовый",
                "{R:255 G:250 B:205 A:255}" => "СветлоЛимонный",
                "{R:255 G:182 B:193 A:255}" => "СветлоРозовый",
                "{R:211 G:211 B:211 A:255}" => "СветлоСерый",
                "{R:173 G:216 B:230 A:255}" => "СветлоСиний",
                "{R:224 G:255 B:255 A:255}" => "СветлыйЗеленоватоГолубой",
                "{R:255 G:160 B:122 A:255}" => "СветлыйЛососевый",
                "{R:192 G:192 B:192 A:255}" => "Серебристый",
                "{R:95 G:158 B:160 A:255}" => "СероСиний",
                "{R:128 G:128 B:128 A:255}" => "Серый",
                "{R:112 G:128 B:144 A:255}" => "СерыйШифер",
                "{R:176 G:196 B:222 A:255}" => "СинеГолубойСоСтальнымОттенком",
                "{R:0 G:128 B:128 A:255}" => "СинеЗеленый",
                "{R:138 G:43 B:226 A:255}" => "СинеФиолетовый",
                "{R:0 G:0 B:255 A:255}" => "Синий",
                "{R:240 G:248 B:255 A:255}" => "СинийЭлис",
                "{R:70 G:130 B:180 A:255}" => "СиняяСталь",
                "{R:221 G:160 B:221 A:255}" => "Сливовый",
                "{R:255 G:255 B:240 A:255}" => "СлоноваяКость",
                "{R:253 G:245 B:230 A:255}" => "СтароеКружево",
                "{R:233 G:150 B:122 A:255}" => "ТемнаяЛососина",
                "{R:143 G:188 B:139 A:255}" => "ТемнаяМорскаяВолна",
                "{R:153 G:50 B:204 A:255}" => "ТемнаяОрхидея",
                "{R:47 G:79 B:79 A:255}" => "ТемноАспидныйСерый",
                "{R:0 G:139 B:139 A:255}" => "ТемноГолубой",
                "{R:0 G:100 B:0 A:255}" => "ТемноЗеленый",
                "{R:139 G:0 B:0 A:255}" => "ТемноКрасный",
                "{R:0 G:206 B:209 A:255}" => "ТемноМандариновый",
                "{R:139 G:0 B:139 A:255}" => "ТемноПурпурный",
                "{R:169 G:169 B:169 A:255}" => "ТемноСерый",
                "{R:0 G:0 B:139 A:255}" => "ТемноСиний",
                "{R:148 G:0 B:211 A:255}" => "ТемноФиолетовый",
                "{R:72 G:61 B:139 A:255}" => "ТемныйГрифельноСиний",
                "{R:184 G:134 B:11 A:255}" => "ТемныйЗолотой",
                "{R:85 G:107 B:47 A:255}" => "ТемныйОливковоЗеленый",
                "{R:255 G:140 B:0 A:255}" => "ТемныйОранжевый",
                "{R:189 G:183 B:107 A:255}" => "ТемныйХаки",
                "{R:255 G:99 B:71 A:255}" => "Томатный",
                "{R:220 G:220 B:220 A:255}" => "ТуманноБелый",
                "{R:255 G:228 B:225 A:255}" => "ТусклоРозовый",
                "{R:105 G:105 B:105 A:255}" => "ТусклоСерый",
                "{R:102 G:205 B:170 A:255}" => "УмеренныйАквамарин",
                "{R:72 G:209 B:204 A:255}" => "УмеренныйБирюзовый",
                "{R:0 G:250 B:154 A:255}" => "УмеренныйВесеннеЗеленый",
                "{R:123 G:104 B:238 A:255}" => "УмеренныйГрифельноСиний",
                "{R:60 G:179 B:113 A:255}" => "УмеренныйМорскаяВолна",
                "{R:186 G:85 B:211 A:255}" => "УмеренныйОрхидея",
                "{R:0 G:0 B:205 A:255}" => "УмеренныйСиний",
                "{R:199 G:21 B:133 A:255}" => "УмеренныйФиолетовоКрасный",
                "{R:147 G:112 B:219 A:255}" => "УмеренныйФиолетовый",
                "{R:238 G:130 B:238 A:255}" => "Фиолетовый",
                "{R:240 G:230 B:140 A:255}" => "Хаки",
                "{R:210 G:180 B:140 A:255}" => "ЦветЗагара",
                "{R:255 G:250 B:240 A:255}" => "ЦветочноБелый",
                "{R:222 G:184 B:135 A:255}" => "ЦветПлотнойДревесины",
                "{R:0 G:0 B:128 A:255}" => "ЦветФормыМорскихОфицеров",
                "{R:0 G:0 B:0 A:255}" => "Черный",
                "{R:216 G:191 B:216 A:255}" => "Чертополох",
                "{R:127 G:255 B:0 A:255}" => "Шартрез",
                "{R:210 G:105 B:30 A:255}" => "Шоколадный",
                "{R:255 G:250 B:250 A:255}" => "ЯркийБелый",
                "{R:255 G:105 B:180 A:255}" => "ЯркоРозовый",
                _ => "" // аналог default
            };
            return result;
        }

        public string getNameEn(GfColor p1)
        {
            string result = p1.ToString() switch
            {
                "{R:127 G:255 B:212 A:255}" => "Aquamarine",
                "{R:250 G:235 B:215 A:255}" => "AntiqueWhite",
                "{R:245 G:245 B:220 A:255}" => "Beige",
                "{R:245 G:245 B:245 A:255}" => "WhiteSmoke",
                "{R:255 G:255 B:255 A:255}" => "White",
                "{R:255 G:222 B:173 A:255}" => "NavajoWhite",
                "{R:64 G:224 B:208 A:255}" => "Turquoise",
                "{R:255 G:228 B:196 A:255}" => "Bisque",
                "{R:175 G:238 B:238 A:255}" => "PaleTurquoise",
                "{R:255 G:248 B:220 A:255}" => "Cornsilk",
                "{R:152 G:251 B:152 A:255}" => "PaleGreen",
                "{R:238 G:232 B:170 A:255}" => "PaleGoldenrod",
                "{R:100 G:149 B:237 A:255}" => "CornflowerBlue",
                "{R:255 G:20 B:147 A:255}" => "DeepPink",
                "{R:0 G:191 B:255 A:255}" => "DeepSkyBlue",
                "{R:119 G:136 B:153 A:255}" => "LightSlateGray",
                "{R:106 G:90 B:205 A:255}" => "SlateBlue",
                "{R:154 G:205 B:50 A:255}" => "YellowGreen",
                "{R:255 G:255 B:0 A:255}" => "Yellow",
                "{R:30 G:144 B:255 A:255}" => "DodgerBlue",
                "{R:0 G:255 B:127 A:255}" => "SpringGreen",
                "{R:124 G:252 B:0 A:255}" => "LawnGreen",
                "{R:46 G:139 B:87 A:255}" => "SeaGreen",
                "{R:173 G:255 B:47 A:255}" => "GreenYellow",
                "{R:0 G:128 B:0 A:255}" => "Green",
                "{R:50 G:205 B:50 A:255}" => "LimeGreen",
                "{R:34 G:139 B:34 A:255}" => "ForestGreen",
                "{R:218 G:165 B:32 A:255}" => "Goldenrod",
                "{R:255 G:215 B:0 A:255}" => "Gold",
                "{R:75 G:0 B:130 A:255}" => "Indigo",
                "{R:205 G:92 B:92 A:255}" => "IndianRed",
                "{R:178 G:34 B:34 A:255}" => "Firebrick",
                "{R:139 G:69 B:19 A:255}" => "SaddleBrown",
                "{R:255 G:127 B:80 A:255}" => "Coral",
                "{R:128 G:0 B:0 A:255}" => "Maroon",
                "{R:165 G:42 B:42 A:255}" => "Brown",
                "{R:65 G:105 B:225 A:255}" => "RoyalBlue",
                "{R:255 G:0 B:0 A:255}" => "Red",
                "{R:220 G:20 B:60 A:255}" => "Crimson",
                "{R:230 G:230 B:250 A:255}" => "Lavender",
                "{R:240 G:255 B:255 A:255}" => "Azure",
                "{R:0 G:255 B:0 A:255}" => "Lime",
                "{R:219 G:112 B:147 A:255}" => "PaleVioletRed",
                "{R:250 G:128 B:114 A:255}" => "Salmon",
                "{R:250 G:240 B:230 A:255}" => "Linen",
                "{R:255 G:0 B:255 A:255}" => "Magenta",
                "{R:240 G:255 B:240 A:255}" => "Honeydew",
                "{R:255 G:228 B:181 A:255}" => "Moccasin",
                "{R:0 G:255 B:255 A:255}" => "Aqua",
                "{R:255 G:245 B:238 A:255}" => "SeaShell",
                "{R:245 G:255 B:250 A:255}" => "MintCream",
                "{R:135 G:206 B:235 A:255}" => "SkyBlue",
                "{R:135 G:206 B:250 A:255}" => "LightSkyBlue",
                "{R:107 G:142 B:35 A:255}" => "OliveDrab",
                "{R:128 G:128 B:0 A:255}" => "Olive",
                "{R:255 G:69 B:0 A:255}" => "OrangeRed",
                "{R:255 G:165 B:0 A:255}" => "Orange",
                "{R:218 G:112 B:214 A:255}" => "Orchid",
                "{R:160 G:82 B:45 A:255}" => "Sienna",
                "{R:255 G:218 B:185 A:255}" => "PeachPuff",
                "{R:244 G:164 B:96 A:255}" => "SandyBrown",
                "{R:255 G:239 B:213 A:255}" => "PapayaWhip",
                "{R:25 G:25 B:112 A:255}" => "MidnightBlue",
                "{R:176 G:224 B:230 A:255}" => "PowderBlue",
                "{R:248 G:248 B:255 A:255}" => "GhostWhite",
                "{R:255 G:255 B:255 A:0}" => "Transparent",
                "{R:128 G:0 B:128 A:255}" => "Purple",
                "{R:245 G:222 B:179 A:255}" => "Wheat",
                "{R:188 G:143 B:143 A:255}" => "RosyBrown",
                "{R:255 G:240 B:245 A:255}" => "LavenderBlush",
                "{R:255 G:192 B:203 A:255}" => "Pink",
                "{R:32 G:178 B:170 A:255}" => "LightSeaGreen",
                "{R:255 G:255 B:224 A:255}" => "LightYellow",
                "{R:250 G:250 B:210 A:255}" => "LightGoldenrodYellow",
                "{R:144 G:238 B:144 A:255}" => "LightGreen",
                "{R:240 G:128 B:128 A:255}" => "LightCoral",
                "{R:205 G:133 B:63 A:255}" => "Peru",
                "{R:255 G:235 B:205 A:255}" => "BlanchedAlmond",
                "{R:255 G:250 B:205 A:255}" => "LemonChiffon",
                "{R:255 G:182 B:193 A:255}" => "LightPink",
                "{R:211 G:211 B:211 A:255}" => "LightGray",
                "{R:173 G:216 B:230 A:255}" => "LightBlue",
                "{R:224 G:255 B:255 A:255}" => "LightCyan",
                "{R:255 G:160 B:122 A:255}" => "LightSalmon",
                "{R:192 G:192 B:192 A:255}" => "Silver",
                "{R:95 G:158 B:160 A:255}" => "CadetBlue",
                "{R:128 G:128 B:128 A:255}" => "Gray",
                "{R:112 G:128 B:144 A:255}" => "SlateGray",
                "{R:176 G:196 B:222 A:255}" => "LightSteelBlue",
                "{R:0 G:128 B:128 A:255}" => "Teal",
                "{R:138 G:43 B:226 A:255}" => "BlueViolet",
                "{R:0 G:0 B:255 A:255}" => "Blue",
                "{R:240 G:248 B:255 A:255}" => "AliceBlue",
                "{R:70 G:130 B:180 A:255}" => "SteelBlue",
                "{R:221 G:160 B:221 A:255}" => "Plum",
                "{R:255 G:255 B:240 A:255}" => "Ivory",
                "{R:253 G:245 B:230 A:255}" => "OldLace",
                "{R:233 G:150 B:122 A:255}" => "DarkSalmon",
                "{R:143 G:188 B:139 A:255}" => "DarkSeaGreen",
                "{R:153 G:50 B:204 A:255}" => "DarkOrchid",
                "{R:47 G:79 B:79 A:255}" => "DarkSlateGray",
                "{R:0 G:139 B:139 A:255}" => "DarkCyan",
                "{R:0 G:100 B:0 A:255}" => "DarkGreen",
                "{R:139 G:0 B:0 A:255}" => "DarkRed",
                "{R:0 G:206 B:209 A:255}" => "DarkTurquoise",
                "{R:139 G:0 B:139 A:255}" => "DarkMagenta",
                "{R:169 G:169 B:169 A:255}" => "DarkGray",
                "{R:0 G:0 B:139 A:255}" => "DarkBlue",
                "{R:148 G:0 B:211 A:255}" => "DarkViolet",
                "{R:72 G:61 B:139 A:255}" => "DarkSlateBlue",
                "{R:184 G:134 B:11 A:255}" => "DarkGoldenrod",
                "{R:85 G:107 B:47 A:255}" => "DarkOliveGreen",
                "{R:255 G:140 B:0 A:255}" => "DarkOrange",
                "{R:189 G:183 B:107 A:255}" => "DarkKhaki",
                "{R:255 G:99 B:71 A:255}" => "Tomato",
                "{R:220 G:220 B:220 A:255}" => "Gainsboro",
                "{R:255 G:228 B:225 A:255}" => "MistyRose",
                "{R:105 G:105 B:105 A:255}" => "DimGray",
                "{R:102 G:205 B:170 A:255}" => "MediumAquamarine",
                "{R:72 G:209 B:204 A:255}" => "MediumTurquoise",
                "{R:0 G:250 B:154 A:255}" => "MediumSpringGreen",
                "{R:123 G:104 B:238 A:255}" => "MediumSlateBlue",
                "{R:60 G:179 B:113 A:255}" => "MediumSeaGreen",
                "{R:186 G:85 B:211 A:255}" => "MediumOrchid",
                "{R:0 G:0 B:205 A:255}" => "MediumBlue",
                "{R:199 G:21 B:133 A:255}" => "MediumVioletRed",
                "{R:147 G:112 B:219 A:255}" => "MediumPurple",
                "{R:238 G:130 B:238 A:255}" => "Violet",
                "{R:240 G:230 B:140 A:255}" => "Khaki",
                "{R:210 G:180 B:140 A:255}" => "Tan",
                "{R:255 G:250 B:240 A:255}" => "FloralWhite",
                "{R:222 G:184 B:135 A:255}" => "BurlyWood",
                "{R:0 G:0 B:128 A:255}" => "Navy",
                "{R:0 G:0 B:0 A:255}" => "Black",
                "{R:216 G:191 B:216 A:255}" => "Thistle",
                "{R:127 G:255 B:0 A:255}" => "Chartreuse",
                "{R:210 G:105 B:30 A:255}" => "Chocolate",
                "{R:255 G:250 B:250 A:255}" => "Snow",
                "{R:255 G:105 B:180 A:255}" => "HotPink",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("Индиго", "Indigo")]
        public GfColor Indigo
        {
            get { return MakeColor(75, 0, 130, 255); }
        }

        [ContextProperty("ИндийскийКрасный", "IndianRed")]
        public GfColor IndianRed
        {
            get { return MakeColor(205, 92, 92, 255); }
        }

        [ContextProperty("Кирпичный", "Firebrick")]
        public GfColor Firebrick
        {
            get { return MakeColor(178, 34, 34, 255); }
        }

        [ContextProperty("КожаноКоричневый", "SaddleBrown")]
        public GfColor SaddleBrown
        {
            get { return MakeColor(139, 69, 19, 255); }
        }

        [ContextProperty("Коралловый", "Coral")]
        public GfColor Coral
        {
            get { return MakeColor(255, 127, 80, 255); }
        }

        [ContextProperty("КоричневоМалиновый", "Maroon")]
        public GfColor Maroon
        {
            get { return MakeColor(128, 0, 0, 255); }
        }

        [ContextProperty("Коричневый", "Brown")]
        public GfColor Brown
        {
            get { return MakeColor(165, 42, 42, 255); }
        }

        [ContextProperty("КоролевскийСиний", "RoyalBlue")]
        public GfColor RoyalBlue
        {
            get { return MakeColor(65, 105, 225, 255); }
        }

        [ContextProperty("Красный", "Red")]
        public GfColor Red
        {
            get { return MakeColor(255, 0, 0, 255); }
        }

        [ContextProperty("Кровавый", "Crimson")]
        public GfColor Crimson
        {
            get { return MakeColor(220, 20, 60, 255); }
        }

        [ContextProperty("Лаванда", "Lavender")]
        public GfColor Lavender
        {
            get { return MakeColor(230, 230, 250, 255); }
        }

        [ContextProperty("Лазурный", "Azure")]
        public GfColor Azure
        {
            get { return MakeColor(240, 255, 255, 255); }
        }

        [ContextProperty("Лайм", "Lime")]
        public GfColor Lime
        {
            get { return MakeColor(0, 255, 0, 255); }
        }

        [ContextProperty("Лиловый", "PaleVioletRed")]
        public GfColor PaleVioletRed
        {
            get { return MakeColor(219, 112, 147, 255); }
        }

        [ContextProperty("Лососевый", "Salmon")]
        public GfColor Salmon
        {
            get { return MakeColor(250, 128, 114, 255); }
        }

        [ContextProperty("Льняной", "Linen")]
        public GfColor Linen
        {
            get { return MakeColor(250, 240, 230, 255); }
        }

        [ContextProperty("Малиновый", "Magenta")]
        public GfColor Magenta
        {
            get { return MakeColor(255, 0, 255, 255); }
        }

        [ContextProperty("Медовый", "Honeydew")]
        public GfColor Honeydew
        {
            get { return MakeColor(240, 255, 240, 255); }
        }

        [ContextProperty("Мокасиновый", "Moccasin")]
        public GfColor Moccasin
        {
            get { return MakeColor(255, 228, 181, 255); }
        }

        [ContextProperty("МорскаяВолна", "Aqua")]
        public GfColor Aqua
        {
            get { return MakeColor(0, 255, 255, 255); }
        }

        [ContextProperty("МорскаяРакушка", "SeaShell")]
        public GfColor SeaShell
        {
            get { return MakeColor(255, 245, 238, 255); }
        }

        [ContextProperty("МятноКремовый", "MintCream")]
        public GfColor MintCream
        {
            get { return MakeColor(245, 255, 250, 255); }
        }

        [ContextProperty("НебесноГолубой", "SkyBlue")]
        public GfColor SkyBlue
        {
            get { return MakeColor(135, 206, 235, 255); }
        }

        [ContextProperty("НебесноГолубойСветлый", "LightSkyBlue")]
        public GfColor LightSkyBlue
        {
            get { return MakeColor(135, 206, 250, 255); }
        }

        [ContextProperty("НежноОливковый", "OliveDrab")]
        public GfColor OliveDrab
        {
            get { return MakeColor(107, 142, 35, 255); }
        }

        [ContextProperty("Оливковый", "Olive")]
        public GfColor Olive
        {
            get { return MakeColor(128, 128, 0, 255); }
        }

        [ContextProperty("ОранжевоКрасный", "OrangeRed")]
        public GfColor OrangeRed
        {
            get { return MakeColor(255, 69, 0, 255); }
        }

        [ContextProperty("Оранжевый", "Orange")]
        public GfColor Orange
        {
            get { return MakeColor(255, 165, 0, 255); }
        }

        [ContextProperty("Орхидея", "Orchid")]
        public GfColor Orchid
        {
            get { return MakeColor(218, 112, 214, 255); }
        }

        [ContextProperty("Охра", "Sienna")]
        public GfColor Sienna
        {
            get { return MakeColor(160, 82, 45, 255); }
        }

        [ContextProperty("Персиковый", "PeachPuff")]
        public GfColor PeachPuff
        {
            get { return MakeColor(255, 218, 185, 255); }
        }

        [ContextProperty("Песочный", "SandyBrown")]
        public GfColor SandyBrown
        {
            get { return MakeColor(244, 164, 96, 255); }
        }

        [ContextProperty("ПобегПапайи", "PapayaWhip")]
        public GfColor PapayaWhip
        {
            get { return MakeColor(255, 239, 213, 255); }
        }

        [ContextProperty("ПолуночноСиний", "MidnightBlue")]
        public GfColor MidnightBlue
        {
            get { return MakeColor(25, 25, 112, 255); }
        }

        [ContextProperty("ПороховаяСинь", "PowderBlue")]
        public GfColor PowderBlue
        {
            get { return MakeColor(176, 224, 230, 255); }
        }

        [ContextProperty("ПризрачноБелый", "GhostWhite")]
        public GfColor GhostWhite
        {
            get { return MakeColor(248, 248, 255, 255); }
        }

        [ContextProperty("Прозрачный", "Transparent")]
        public GfColor Transparent
        {
            get { return MakeColor(255, 255, 255, 0); }
        }

        [ContextProperty("Пурпурный", "Purple")]
        public GfColor Purple
        {
            get { return MakeColor(128, 0, 128, 255); }
        }

        [ContextProperty("Пшеничный", "Wheat")]
        public GfColor Wheat
        {
            get { return MakeColor(245, 222, 179, 255); }
        }

        [ContextProperty("РозовоКоричневый", "RosyBrown")]
        public GfColor RosyBrown
        {
            get { return MakeColor(188, 143, 143, 255); }
        }

        [ContextProperty("РозовоЛавандовый", "LavenderBlush")]
        public GfColor LavenderBlush
        {
            get { return MakeColor(255, 240, 245, 255); }
        }

        [ContextProperty("Розовый", "Pink")]
        public GfColor Pink
        {
            get { return MakeColor(255, 192, 203, 255); }
        }

        [ContextProperty("СветлаяМорскаяВолна", "LightSeaGreen")]
        public GfColor LightSeaGreen
        {
            get { return MakeColor(32, 178, 170, 255); }
        }

        [ContextProperty("СветлоЖелтый", "LightYellow")]
        public GfColor LightYellow
        {
            get { return MakeColor(255, 255, 224, 255); }
        }

        [ContextProperty("СветлоЖелтыйЗолотистый", "LightGoldenrodYellow")]
        public GfColor LightGoldenrodYellow
        {
            get { return MakeColor(250, 250, 210, 255); }
        }

        [ContextProperty("СветлоЗеленый", "LightGreen")]
        public GfColor LightGreen
        {
            get { return MakeColor(144, 238, 144, 255); }
        }

        [ContextProperty("СветлоКоралловый", "LightCoral")]
        public GfColor LightCoral
        {
            get { return MakeColor(240, 128, 128, 255); }
        }

        [ContextProperty("СветлоКоричневый", "Peru")]
        public GfColor Peru
        {
            get { return MakeColor(205, 133, 63, 255); }
        }

        [ContextProperty("СветлоКремовый", "BlanchedAlmond")]
        public GfColor BlanchedAlmond
        {
            get { return MakeColor(255, 235, 205, 255); }
        }

        [ContextProperty("СветлоЛимонный", "LemonChiffon")]
        public GfColor LemonChiffon
        {
            get { return MakeColor(255, 250, 205, 255); }
        }

        [ContextProperty("СветлоРозовый", "LightPink")]
        public GfColor LightPink
        {
            get { return MakeColor(255, 182, 193, 255); }
        }

        [ContextProperty("СветлоСерый", "LightGray")]
        public GfColor LightGray
        {
            get { return MakeColor(211, 211, 211, 255); }
        }

        [ContextProperty("СветлоСиний", "LightBlue")]
        public GfColor LightBlue
        {
            get { return MakeColor(173, 216, 230, 255); }
        }

        [ContextProperty("СветлыйЗеленоватоГолубой", "LightCyan")]
        public GfColor LightCyan
        {
            get { return MakeColor(224, 255, 255, 255); }
        }

        [ContextProperty("СветлыйЛососевый", "LightSalmon")]
        public GfColor LightSalmon
        {
            get { return MakeColor(255, 160, 122, 255); }
        }

        [ContextProperty("Серебристый", "Silver")]
        public GfColor Silver
        {
            get { return MakeColor(192, 192, 192, 255); }
        }

        [ContextProperty("СероСиний", "CadetBlue")]
        public GfColor CadetBlue
        {
            get { return MakeColor(95, 158, 160, 255); }
        }

        [ContextProperty("Серый", "Gray")]
        public GfColor Gray
        {
            get { return MakeColor(128, 128, 128, 255); }
        }

        [ContextProperty("СерыйШифер", "SlateGray")]
        public GfColor SlateGray
        {
            get { return MakeColor(112, 128, 144, 255); }
        }

        [ContextProperty("СинеГолубойСоСтальнымОттенком", "LightSteelBlue")]
        public GfColor LightSteelBlue
        {
            get { return MakeColor(176, 196, 222, 255); }
        }

        [ContextProperty("СинеЗеленый", "Teal")]
        public GfColor Teal
        {
            get { return MakeColor(0, 128, 128, 255); }
        }

        [ContextProperty("СинеФиолетовый", "BlueViolet")]
        public GfColor BlueViolet
        {
            get { return MakeColor(138, 43, 226, 255); }
        }

        [ContextProperty("Синий", "Blue")]
        public GfColor Blue
        {
            get { return MakeColor(0, 0, 255, 255); }
        }

        [ContextProperty("СинийЭлис", "AliceBlue")]
        public GfColor AliceBlue
        {
            get { return MakeColor(240, 248, 255, 255); }
        }

        [ContextProperty("СиняяСталь", "SteelBlue")]
        public GfColor SteelBlue
        {
            get { return MakeColor(70, 130, 180, 255); }
        }

        [ContextProperty("Сливовый", "Plum")]
        public GfColor Plum
        {
            get { return MakeColor(221, 160, 221, 255); }
        }

        [ContextProperty("СлоноваяКость", "Ivory")]
        public GfColor Ivory
        {
            get { return MakeColor(255, 255, 240, 255); }
        }

        [ContextProperty("СтароеКружево", "OldLace")]
        public GfColor OldLace
        {
            get { return MakeColor(253, 245, 230, 255); }
        }

        [ContextProperty("ТемнаяЛососина", "DarkSalmon")]
        public GfColor DarkSalmon
        {
            get { return MakeColor(233, 150, 122, 255); }
        }

        [ContextProperty("ТемнаяМорскаяВолна", "DarkSeaGreen")]
        public GfColor DarkSeaGreen
        {
            get { return MakeColor(143, 188, 139, 255); }
        }

        [ContextProperty("ТемнаяОрхидея", "DarkOrchid")]
        public GfColor DarkOrchid
        {
            get { return MakeColor(153, 50, 204, 255); }
        }

        [ContextProperty("ТемноАспидныйСерый", "DarkSlateGray")]
        public GfColor DarkSlateGray
        {
            get { return MakeColor(47, 79, 79, 255); }
        }

        [ContextProperty("ТемноГолубой", "DarkCyan")]
        public GfColor DarkCyan
        {
            get { return MakeColor(0, 139, 139, 255); }
        }

        [ContextProperty("ТемноЗеленый", "DarkGreen")]
        public GfColor DarkGreen
        {
            get { return MakeColor(0, 100, 0, 255); }
        }

        [ContextProperty("ТемноКрасный", "DarkRed")]
        public GfColor DarkRed
        {
            get { return MakeColor(139, 0, 0, 255); }
        }

        [ContextProperty("ТемноМандариновый", "DarkTurquoise")]
        public GfColor DarkTurquoise
        {
            get { return MakeColor(0, 206, 209, 255); }
        }

        [ContextProperty("ТемноПурпурный", "DarkMagenta")]
        public GfColor DarkMagenta
        {
            get { return MakeColor(139, 0, 139, 255); }
        }

        [ContextProperty("ТемноСерый", "DarkGray")]
        public GfColor DarkGray
        {
            get { return MakeColor(169, 169, 169, 255); }
        }

        [ContextProperty("ТемноСиний", "DarkBlue")]
        public GfColor DarkBlue
        {
            get { return MakeColor(0, 0, 139, 255); }
        }

        [ContextProperty("ТемноФиолетовый", "DarkViolet")]
        public GfColor DarkViolet
        {
            get { return MakeColor(148, 0, 211, 255); }
        }

        [ContextProperty("ТемныйГрифельноСиний", "DarkSlateBlue")]
        public GfColor DarkSlateBlue
        {
            get { return MakeColor(72, 61, 139, 255); }
        }

        [ContextProperty("ТемныйЗолотой", "DarkGoldenrod")]
        public GfColor DarkGoldenrod
        {
            get { return MakeColor(184, 134, 11, 255); }
        }

        [ContextProperty("ТемныйОливковоЗеленый", "DarkOliveGreen")]
        public GfColor DarkOliveGreen
        {
            get { return MakeColor(85, 107, 47, 255); }
        }

        [ContextProperty("ТемныйОранжевый", "DarkOrange")]
        public GfColor DarkOrange
        {
            get { return MakeColor(255, 140, 0, 255); }
        }

        [ContextProperty("ТемныйХаки", "DarkKhaki")]
        public GfColor DarkKhaki
        {
            get { return MakeColor(189, 183, 107, 255); }
        }

        [ContextProperty("Томатный", "Tomato")]
        public GfColor Tomato
        {
            get { return MakeColor(255, 99, 71, 255); }
        }

        [ContextProperty("ТуманноБелый", "Gainsboro")]
        public GfColor Gainsboro
        {
            get { return MakeColor(220, 220, 220, 255); }
        }

        [ContextProperty("ТусклоРозовый", "MistyRose")]
        public GfColor MistyRose
        {
            get { return MakeColor(255, 228, 225, 255); }
        }

        [ContextProperty("ТусклоСерый", "DimGray")]
        public GfColor DimGray
        {
            get { return MakeColor(105, 105, 105, 255); }
        }

        [ContextProperty("УмеренныйАквамарин", "MediumAquamarine")]
        public GfColor MediumAquamarine
        {
            get { return MakeColor(102, 205, 170, 255); }
        }

        [ContextProperty("УмеренныйБирюзовый", "MediumTurquoise")]
        public GfColor MediumTurquoise
        {
            get { return MakeColor(72, 209, 204, 255); }
        }

        [ContextProperty("УмеренныйВесеннеЗеленый", "MediumSpringGreen")]
        public GfColor MediumSpringGreen
        {
            get { return MakeColor(0, 250, 154, 255); }
        }

        [ContextProperty("УмеренныйГрифельноСиний", "MediumSlateBlue")]
        public GfColor MediumSlateBlue
        {
            get { return MakeColor(123, 104, 238, 255); }
        }

        [ContextProperty("УмеренныйМорскаяВолна", "MediumSeaGreen")]
        public GfColor MediumSeaGreen
        {
            get { return MakeColor(60, 179, 113, 255); }
        }

        [ContextProperty("УмеренныйОрхидея", "MediumOrchid")]
        public GfColor MediumOrchid
        {
            get { return MakeColor(186, 85, 211, 255); }
        }

        [ContextProperty("УмеренныйСиний", "MediumBlue")]
        public GfColor MediumBlue
        {
            get { return MakeColor(0, 0, 205, 255); }
        }

        [ContextProperty("УмеренныйФиолетовоКрасный", "MediumVioletRed")]
        public GfColor MediumVioletRed
        {
            get { return MakeColor(199, 21, 133, 255); }
        }

        [ContextProperty("УмеренныйФиолетовый", "MediumPurple")]
        public GfColor MediumPurple
        {
            get { return MakeColor(147, 112, 219, 255); }
        }

        [ContextProperty("Фиолетовый", "Violet")]
        public GfColor Violet
        {
            get { return MakeColor(238, 130, 238, 255); }
        }

        [ContextProperty("Хаки", "Khaki")]
        public GfColor Khaki
        {
            get { return MakeColor(240, 230, 140, 255); }
        }

        [ContextProperty("ЦветЗагара", "Tan")]
        public GfColor Tan
        {
            get { return MakeColor(210, 180, 140, 255); }
        }

        [ContextProperty("ЦветочноБелый", "FloralWhite")]
        public GfColor FloralWhite
        {
            get { return MakeColor(255, 250, 240, 255); }
        }

        [ContextProperty("ЦветПлотнойДревесины", "BurlyWood")]
        public GfColor BurlyWood
        {
            get { return MakeColor(222, 184, 135, 255); }
        }

        [ContextProperty("ЦветФормыМорскихОфицеров", "Navy")]
        public GfColor Navy
        {
            get { return MakeColor(0, 0, 128, 255); }
        }

        [ContextProperty("Черный", "Black")]
        public GfColor Black
        {
            get { return MakeColor(0, 0, 0, 255); }
        }

        [ContextProperty("Чертополох", "Thistle")]
        public GfColor Thistle
        {
            get { return MakeColor(216, 191, 216, 255); }
        }

        [ContextProperty("Шартрез", "Chartreuse")]
        public GfColor Chartreuse
        {
            get { return MakeColor(127, 255, 0, 255); }
        }

        [ContextProperty("Шоколадный", "Chocolate")]
        public GfColor Chocolate
        {
            get { return MakeColor(210, 105, 30, 255); }
        }

        [ContextProperty("ЯркийБелый", "Snow")]
        public GfColor Snow
        {
            get { return MakeColor(255, 250, 250, 255); }
        }

        [ContextProperty("ЯркоРозовый", "HotPink")]
        public GfColor HotPink
        {
            get { return MakeColor(255, 105, 180, 255); }
        }

        [ContextMethod("ВСтроку", "ToString")]
        public override string ToString()
        {
            return $"{{R:{R} G:{G} B:{B} A:{A}}}";
        }

        [ContextMethod("Получить10", "To10")]
        public uint To10()
        {
            return ((uint)A << 24) | ((uint)R << 16) | ((uint)G << 8) | (uint)B;
        }

        [ContextMethod("Получить16", "To16")]
        public string To16()
        {
            string empty = string.Empty;
            empty += "#";
            empty += OsUtils.ToHex32(R);
            empty += OsUtils.ToHex32(G);
            empty += OsUtils.ToHex32(B);
            empty += OsUtils.ToHex32(A);
            return empty;
        }

        [ContextMethod("ПолучитьИз10", "From10")]
        public GfColor From10(uint p1)
        {
            byte alpha = (byte)((p1 >> 24) & 0xFF);
            byte red = (byte)((p1 >> 16) & 0xFF);
            byte green = (byte)((p1 >> 8) & 0xFF);
            byte blue = (byte)(p1 & 0xFF);
            return MakeColor(red, green, blue, alpha);
        }
    }
}
