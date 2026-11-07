using OneScript.Contexts;
using OneScript.Execution;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Collections;
using System.Reflection;

namespace osgf
{
    [ContextClass("ИфКлавиши", "GfKeys")]
    public class GfKeys : AutoContext<GfKeys>, ICollectionContext<IValue>, IEnumerable<IValue>
    {
        private List<IValue> _list;
        public IEnumerator Enumerator;

        [ContextMethod("Количество", "Count")]
        public int Count(IBslProcess p1 = null)
        {
            return _list.Count;
        }

        [ContextMethod("Получить", "Get")]
        public IValue Get(int index)
        {
            return this._list[index];
        }

        public CollectionEnumerator GetManagedIterator()
        {
            return new CollectionEnumerator(this);
        }

        IEnumerator<IValue> IEnumerable<IValue>.GetEnumerator()
        {
            foreach (var item in _list)
            {
                yield return (item as IValue);
            }
        }

        public IEnumerator GetEnumerator()
        {
            Enumerator = _list.GetEnumerator();
            return (IEnumerator)this;
        }

        public GfKeys()
        {
            _list = new List<IValue>()
            {
                ValueFactory.Create("None"),
                ValueFactory.Create("BraceLeft"),
                ValueFactory.Create("Bar"),
                ValueFactory.Create("BraceRight"),
                ValueFactory.Create("ASCIITilde"),
                ValueFactory.Create("Section"),
                ValueFactory.Create("Space"),
                ValueFactory.Create("Exclam"),
                ValueFactory.Create("Quotedbl"),
                ValueFactory.Create("Numbersign"),
                ValueFactory.Create("Dollar"),
                ValueFactory.Create("Percent"),
                ValueFactory.Create("Ampersand"),
                ValueFactory.Create("Apostrophe"),
                ValueFactory.Create("ParenLeft"),
                ValueFactory.Create("ParenRight"),
                ValueFactory.Create("Special"),
                ValueFactory.Create("Escape"),
                ValueFactory.Create("Tab"),
                ValueFactory.Create("BackTab"),
                ValueFactory.Create("Backspace"),
                ValueFactory.Create("Enter"),
                ValueFactory.Create("NumPadEnter"),
                ValueFactory.Create("Insert"),
                ValueFactory.Create("Delete"),
                ValueFactory.Create("Pause"),
                ValueFactory.Create("Print"),
                ValueFactory.Create("Clear"),
                ValueFactory.Create("Home"),
                ValueFactory.Create("End"),
                ValueFactory.Create("LeftArrow"),
                ValueFactory.Create("UpArrow"),
                ValueFactory.Create("RightArrow"),
                ValueFactory.Create("DownArrow"),
                ValueFactory.Create("PageUp"),
                ValueFactory.Create("PageDown"),
                ValueFactory.Create("Shift"),
                ValueFactory.Create("Ctrl"),
                ValueFactory.Create("Meta"),
                ValueFactory.Create("Alt"),
                ValueFactory.Create("CapsLock"),
                ValueFactory.Create("NumLock"),
                ValueFactory.Create("ScrollLock"),
                ValueFactory.Create("F1"),
                ValueFactory.Create("F2"),
                ValueFactory.Create("F3"),
                ValueFactory.Create("F4"),
                ValueFactory.Create("F5"),
                ValueFactory.Create("F6"),
                ValueFactory.Create("F7"),
                ValueFactory.Create("F8"),
                ValueFactory.Create("F9"),
                ValueFactory.Create("F10"),
                ValueFactory.Create("F11"),
                ValueFactory.Create("F12"),
                ValueFactory.Create("Menu"),
                ValueFactory.Create("Help"),
                ValueFactory.Create("Back"),
                ValueFactory.Create("Forward"),
                ValueFactory.Create("Multiply"),
                ValueFactory.Create("Divide"),
                ValueFactory.Create("NumPadMinus"),
                ValueFactory.Create("NumPadSeparator"),
                ValueFactory.Create("NumPadPlus"),
                ValueFactory.Create("NumPad0"),
                ValueFactory.Create("NumPad1"),
                ValueFactory.Create("NumPad2"),
                ValueFactory.Create("NumPad3"),
                ValueFactory.Create("NumPad4"),
                ValueFactory.Create("NumPad5"),
                ValueFactory.Create("NumPad6"),
                ValueFactory.Create("NumPad7"),
                ValueFactory.Create("NumPad8"),
                ValueFactory.Create("NumPad9"),
                ValueFactory.Create("Asterisk"),
                ValueFactory.Create("Plus"),
                ValueFactory.Create("Comma"),
                ValueFactory.Create("Minus"),
                ValueFactory.Create("Separator"),
                ValueFactory.Create("Slash"),
                ValueFactory.Create("D0"),
                ValueFactory.Create("D1"),
                ValueFactory.Create("D2"),
                ValueFactory.Create("D3"),
                ValueFactory.Create("D4"),
                ValueFactory.Create("D5"),
                ValueFactory.Create("D6"),
                ValueFactory.Create("D7"),
                ValueFactory.Create("D8"),
                ValueFactory.Create("D9"),
                ValueFactory.Create("Colon"),
                ValueFactory.Create("Semicolon"),
                ValueFactory.Create("Less"),
                ValueFactory.Create("Equal"),
                ValueFactory.Create("Greater"),
                ValueFactory.Create("Question"),
                ValueFactory.Create("At"),
                ValueFactory.Create("A"),
                ValueFactory.Create("B"),
                ValueFactory.Create("C"),
                ValueFactory.Create("D"),
                ValueFactory.Create("E"),
                ValueFactory.Create("F"),
                ValueFactory.Create("G"),
                ValueFactory.Create("H"),
                ValueFactory.Create("I"),
                ValueFactory.Create("J"),
                ValueFactory.Create("K"),
                ValueFactory.Create("L"),
                ValueFactory.Create("M"),
                ValueFactory.Create("N"),
                ValueFactory.Create("O"),
                ValueFactory.Create("P"),
                ValueFactory.Create("Q"),
                ValueFactory.Create("R"),
                ValueFactory.Create("S"),
                ValueFactory.Create("Unknown"),
                ValueFactory.Create("T"),
                ValueFactory.Create("U"),
                ValueFactory.Create("V"),
                ValueFactory.Create("W"),
                ValueFactory.Create("X"),
                ValueFactory.Create("Y"),
                ValueFactory.Create("Z"),
                ValueFactory.Create("BracketLeft"),
                ValueFactory.Create("Backslash"),
                ValueFactory.Create("BracketRight"),
                ValueFactory.Create("ASCIICircum"),
                ValueFactory.Create("Underscore"),
                ValueFactory.Create("QuoteLeft")
            };
        }

        public PropertyInfo this[int p1]
        {
            get { return this.GetType().GetProperties()[p1]; }
        }

        public PropertyInfo this[string p1]
        {
            get { return this.GetType().GetProperty(p1); }
        }

        [ContextMethod("Значение", "Value")]
        public int ValueMethod(string p1)
        {
            return OsUtils.ToInt32(this.GetType().GetProperty(p1).GetValue(this));
        }

        [ContextMethod("Имя", "Имя")]
        public string NameRu(int p1)
        {
            return getNameRu(p1);
        }

        public string getNameRu(int p1)
        {
            string result = (int)p1 switch
            {
                0 => "None",
                123 => "BraceLeft",
                124 => "Bar",
                125 => "BraceRight",
                126 => "ASCIITilde",
                167 => "Section",
                32 => "Space",
                33 => "Exclam",
                34 => "Quotedbl",
                35 => "Numbersign",
                36 => "Dollar",
                37 => "Percent",
                38 => "Ampersand",
                39 => "Apostrophe",
                40 => "ParenLeft",
                41 => "ParenRight",
                4194304 => "Special",
                4194305 => "Escape",
                4194306 => "Tab",
                4194307 => "BackTab",
                4194308 => "Backspace",
                4194309 => "Enter",
                4194310 => "NumPadEnter",
                4194311 => "Insert",
                4194312 => "Delete",
                4194313 => "Pause",
                4194314 => "Print",
                4194316 => "Clear",
                4194317 => "Home",
                4194318 => "End",
                4194319 => "LeftArrow",
                4194320 => "UpArrow",
                4194321 => "RightArrow",
                4194322 => "DownArrow",
                4194323 => "PageUp",
                4194324 => "PageDown",
                4194325 => "Shift",
                4194326 => "Ctrl",
                4194327 => "Meta",
                4194328 => "Alt",
                4194329 => "CapsLock",
                4194330 => "NumLock",
                4194331 => "ScrollLock",
                4194332 => "F1",
                4194333 => "F2",
                4194334 => "F3",
                4194335 => "F4",
                4194336 => "F5",
                4194337 => "F6",
                4194338 => "F7",
                4194339 => "F8",
                4194340 => "F9",
                4194341 => "F10",
                4194342 => "F11",
                4194343 => "F12",
                4194370 => "Menu",
                4194373 => "Help",
                4194376 => "Back",
                4194377 => "Forward",
                4194433 => "Multiply",
                4194434 => "Divide",
                4194435 => "NumPadMinus",
                4194436 => "NumPadSeparator",
                4194437 => "NumPadPlus",
                4194438 => "NumPad0",
                4194439 => "NumPad1",
                4194440 => "NumPad2",
                4194441 => "NumPad3",
                4194442 => "NumPad4",
                4194443 => "NumPad5",
                4194444 => "NumPad6",
                4194445 => "NumPad7",
                4194446 => "NumPad8",
                4194447 => "NumPad9",
                42 => "Asterisk",
                43 => "Plus",
                44 => "Comma",
                45 => "Minus",
                46 => "Separator",
                47 => "Slash",
                48 => "D0",
                49 => "D1",
                50 => "D2",
                51 => "D3",
                52 => "D4",
                53 => "D5",
                54 => "D6",
                55 => "D7",
                56 => "D8",
                57 => "D9",
                58 => "Colon",
                59 => "Semicolon",
                60 => "Less",
                61 => "Equal",
                62 => "Greater",
                63 => "Question",
                64 => "At",
                65 => "A",
                66 => "B",
                67 => "C",
                68 => "D",
                69 => "E",
                70 => "F",
                71 => "G",
                72 => "H",
                73 => "I",
                74 => "J",
                75 => "K",
                76 => "L",
                77 => "M",
                78 => "N",
                79 => "O",
                80 => "P",
                81 => "Q",
                82 => "R",
                83 => "S",
                8388607 => "Unknown",
                84 => "T",
                85 => "U",
                86 => "V",
                87 => "W",
                88 => "X",
                89 => "Y",
                90 => "Z",
                91 => "BracketLeft",
                92 => "Backslash",
                93 => "BracketRight",
                94 => "ASCIICircum",
                95 => "Underscore",
                96 => "QuoteLeft",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextMethod("Name", "Name")]
        public string NameEn(int p1)
        {
            return getNameEn(p1);
        }

        public string getNameEn(int p1)
        {
            string result = (int)p1 switch
            {
                0 => "None",
                123 => "BraceLeft",
                124 => "Bar",
                125 => "BraceRight",
                126 => "ASCIITilde",
                167 => "Section",
                32 => "Space",
                33 => "Exclam",
                34 => "Quotedbl",
                35 => "Numbersign",
                36 => "Dollar",
                37 => "Percent",
                38 => "Ampersand",
                39 => "Apostrophe",
                40 => "ParenLeft",
                41 => "ParenRight",
                4194304 => "Special",
                4194305 => "Escape",
                4194306 => "Tab",
                4194307 => "BackTab",
                4194308 => "Backspace",
                4194309 => "Enter",
                4194310 => "NumPadEnter",
                4194311 => "Insert",
                4194312 => "Delete",
                4194313 => "Pause",
                4194314 => "Print",
                4194316 => "Clear",
                4194317 => "Home",
                4194318 => "End",
                4194319 => "LeftArrow",
                4194320 => "UpArrow",
                4194321 => "RightArrow",
                4194322 => "DownArrow",
                4194323 => "PageUp",
                4194324 => "PageDown",
                4194325 => "Shift",
                4194326 => "Ctrl",
                4194327 => "Meta",
                4194328 => "Alt",
                4194329 => "CapsLock",
                4194330 => "NumLock",
                4194331 => "ScrollLock",
                4194332 => "F1",
                4194333 => "F2",
                4194334 => "F3",
                4194335 => "F4",
                4194336 => "F5",
                4194337 => "F6",
                4194338 => "F7",
                4194339 => "F8",
                4194340 => "F9",
                4194341 => "F10",
                4194342 => "F11",
                4194343 => "F12",
                4194370 => "Menu",
                4194373 => "Help",
                4194376 => "Back",
                4194377 => "Forward",
                4194433 => "Multiply",
                4194434 => "Divide",
                4194435 => "NumPadMinus",
                4194436 => "NumPadSeparator",
                4194437 => "NumPadPlus",
                4194438 => "NumPad0",
                4194439 => "NumPad1",
                4194440 => "NumPad2",
                4194441 => "NumPad3",
                4194442 => "NumPad4",
                4194443 => "NumPad5",
                4194444 => "NumPad6",
                4194445 => "NumPad7",
                4194446 => "NumPad8",
                4194447 => "NumPad9",
                42 => "Asterisk",
                43 => "Plus",
                44 => "Comma",
                45 => "Minus",
                46 => "Separator",
                47 => "Slash",
                48 => "D0",
                49 => "D1",
                50 => "D2",
                51 => "D3",
                52 => "D4",
                53 => "D5",
                54 => "D6",
                55 => "D7",
                56 => "D8",
                57 => "D9",
                58 => "Colon",
                59 => "Semicolon",
                60 => "Less",
                61 => "Equal",
                62 => "Greater",
                63 => "Question",
                64 => "At",
                65 => "A",
                66 => "B",
                67 => "C",
                68 => "D",
                69 => "E",
                70 => "F",
                71 => "G",
                72 => "H",
                73 => "I",
                74 => "J",
                75 => "K",
                76 => "L",
                77 => "M",
                78 => "N",
                79 => "O",
                80 => "P",
                81 => "Q",
                82 => "R",
                83 => "S",
                8388607 => "Unknown",
                84 => "T",
                85 => "U",
                86 => "V",
                87 => "W",
                88 => "X",
                89 => "Y",
                90 => "Z",
                91 => "BracketLeft",
                92 => "Backslash",
                93 => "BracketRight",
                94 => "ASCIICircum",
                95 => "Underscore",
                96 => "QuoteLeft",
                _ => "" // аналог default
            };
            return result;
        }

        [ContextProperty("A", "A")]
        public int A
        {
            get { return 65; }
        }

        [ContextProperty("ASCIICircum", "ASCIICircum")]
        public int ASCIICircum
        {
            get { return 94; }
        }

        [ContextProperty("ASCIITilde", "ASCIITilde")]
        public int ASCIITilde
        {
            get { return 126; }
        }

        [ContextProperty("Alt", "Alt")]
        public int Alt
        {
            get { return 4194328; }
        }

        [ContextProperty("Ampersand", "Ampersand")]
        public int Ampersand
        {
            get { return 38; }
        }

        [ContextProperty("Apostrophe", "Apostrophe")]
        public int Apostrophe
        {
            get { return 39; }
        }

        [ContextProperty("Asterisk", "Asterisk")]
        public int Asterisk
        {
            get { return 42; }
        }

        [ContextProperty("At", "At")]
        public int At
        {
            get { return 64; }
        }

        [ContextProperty("B", "B")]
        public int B
        {
            get { return 66; }
        }

        [ContextProperty("Back", "Back")]
        public int Back
        {
            get { return 4194376; }
        }

        [ContextProperty("BackTab", "BackTab")]
        public int BackTab
        {
            get { return 4194307; }
        }

        [ContextProperty("Backslash", "Backslash")]
        public int Backslash
        {
            get { return 92; }
        }

        [ContextProperty("Backspace", "Backspace")]
        public int Backspace
        {
            get { return 4194308; }
        }

        [ContextProperty("Bar", "Bar")]
        public int Bar
        {
            get { return 124; }
        }

        [ContextProperty("BraceLeft", "BraceLeft")]
        public int BraceLeft
        {
            get { return 123; }
        }

        [ContextProperty("BraceRight", "BraceRight")]
        public int BraceRight
        {
            get { return 125; }
        }

        [ContextProperty("BracketLeft", "BracketLeft")]
        public int BracketLeft
        {
            get { return 91; }
        }

        [ContextProperty("BracketRight", "BracketRight")]
        public int BracketRight
        {
            get { return 93; }
        }

        [ContextProperty("C", "C")]
        public int C
        {
            get { return 67; }
        }

        [ContextProperty("CapsLock", "CapsLock")]
        public int CapsLock
        {
            get { return 4194329; }
        }

        [ContextProperty("Clear", "Clear")]
        public int Clear
        {
            get { return 4194316; }
        }

        [ContextProperty("Colon", "Colon")]
        public int Colon
        {
            get { return 58; }
        }

        [ContextProperty("Comma", "Comma")]
        public int Comma
        {
            get { return 44; }
        }

        [ContextProperty("Ctrl", "Ctrl")]
        public int Ctrl
        {
            get { return 4194326; }
        }

        [ContextProperty("D", "D")]
        public int D
        {
            get { return 68; }
        }

        [ContextProperty("D0", "D0")]
        public int D0
        {
            get { return 48; }
        }

        [ContextProperty("D1", "D1")]
        public int D1
        {
            get { return 49; }
        }

        [ContextProperty("D2", "D2")]
        public int D2
        {
            get { return 50; }
        }

        [ContextProperty("D3", "D3")]
        public int D3
        {
            get { return 51; }
        }

        [ContextProperty("D4", "D4")]
        public int D4
        {
            get { return 52; }
        }

        [ContextProperty("D5", "D5")]
        public int D5
        {
            get { return 53; }
        }

        [ContextProperty("D6", "D6")]
        public int D6
        {
            get { return 54; }
        }

        [ContextProperty("D7", "D7")]
        public int D7
        {
            get { return 55; }
        }

        [ContextProperty("D8", "D8")]
        public int D8
        {
            get { return 56; }
        }

        [ContextProperty("D9", "D9")]
        public int D9
        {
            get { return 57; }
        }

        [ContextProperty("Delete", "Delete")]
        public int Delete
        {
            get { return 4194312; }
        }

        [ContextProperty("Divide", "Divide")]
        public int Divide
        {
            get { return 4194434; }
        }

        [ContextProperty("Dollar", "Dollar")]
        public int Dollar
        {
            get { return 36; }
        }

        [ContextProperty("DownArrow", "DownArrow")]
        public int DownArrow
        {
            get { return 4194322; }
        }

        [ContextProperty("E", "E")]
        public int E
        {
            get { return 69; }
        }

        [ContextProperty("End", "End")]
        public int End
        {
            get { return 4194318; }
        }

        [ContextProperty("Enter", "Enter")]
        public int Enter
        {
            get { return 4194309; }
        }

        [ContextProperty("Equal", "Equal")]
        public int Equal
        {
            get { return 61; }
        }

        [ContextProperty("Escape", "Escape")]
        public int Escape
        {
            get { return 4194305; }
        }

        [ContextProperty("Exclam", "Exclam")]
        public int Exclam
        {
            get { return 33; }
        }

        [ContextProperty("F", "F")]
        public int F
        {
            get { return 70; }
        }

        [ContextProperty("F1", "F1")]
        public int F1
        {
            get { return 4194332; }
        }

        [ContextProperty("F10", "F10")]
        public int F10
        {
            get { return 4194341; }
        }

        [ContextProperty("F11", "F11")]
        public int F11
        {
            get { return 4194342; }
        }

        [ContextProperty("F12", "F12")]
        public int F12
        {
            get { return 4194343; }
        }

        [ContextProperty("F2", "F2")]
        public int F2
        {
            get { return 4194333; }
        }

        [ContextProperty("F3", "F3")]
        public int F3
        {
            get { return 4194334; }
        }

        [ContextProperty("F4", "F4")]
        public int F4
        {
            get { return 4194335; }
        }

        [ContextProperty("F5", "F5")]
        public int F5
        {
            get { return 4194336; }
        }

        [ContextProperty("F6", "F6")]
        public int F6
        {
            get { return 4194337; }
        }

        [ContextProperty("F7", "F7")]
        public int F7
        {
            get { return 4194338; }
        }

        [ContextProperty("F8", "F8")]
        public int F8
        {
            get { return 4194339; }
        }

        [ContextProperty("F9", "F9")]
        public int F9
        {
            get { return 4194340; }
        }

        [ContextProperty("Forward", "Forward")]
        public int Forward
        {
            get { return 4194377; }
        }

        [ContextProperty("G", "G")]
        public int G
        {
            get { return 71; }
        }

        [ContextProperty("Greater", "Greater")]
        public int Greater
        {
            get { return 62; }
        }

        [ContextProperty("H", "H")]
        public int H
        {
            get { return 72; }
        }

        [ContextProperty("Help", "Help")]
        public int Help
        {
            get { return 4194373; }
        }

        [ContextProperty("Home", "Home")]
        public int Home
        {
            get { return 4194317; }
        }

        [ContextProperty("I", "I")]
        public int I
        {
            get { return 73; }
        }

        [ContextProperty("Insert", "Insert")]
        public int Insert
        {
            get { return 4194311; }
        }

        [ContextProperty("J", "J")]
        public int J
        {
            get { return 74; }
        }

        [ContextProperty("K", "K")]
        public int K
        {
            get { return 75; }
        }

        [ContextProperty("L", "L")]
        public int L
        {
            get { return 76; }
        }

        [ContextProperty("LeftArrow", "LeftArrow")]
        public int LeftArrow
        {
            get { return 4194319; }
        }

        [ContextProperty("Less", "Less")]
        public int Less
        {
            get { return 60; }
        }

        [ContextProperty("M", "M")]
        public int M
        {
            get { return 77; }
        }

        [ContextProperty("Menu", "Menu")]
        public int Menu
        {
            get { return 4194370; }
        }

        [ContextProperty("Meta", "Meta")]
        public int Meta
        {
            get { return 4194327; }
        }

        [ContextProperty("Minus", "Minus")]
        public int Minus
        {
            get { return 45; }
        }

        [ContextProperty("Multiply", "Multiply")]
        public int Multiply
        {
            get { return 4194433; }
        }

        [ContextProperty("N", "N")]
        public int N
        {
            get { return 78; }
        }

        [ContextProperty("None", "None")]
        public int None
        {
            get { return 0; }
        }

        [ContextProperty("NumLock", "NumLock")]
        public int NumLock
        {
            get { return 4194330; }
        }

        [ContextProperty("NumPad0", "NumPad0")]
        public int NumPad0
        {
            get { return 4194438; }
        }

        [ContextProperty("NumPad1", "NumPad1")]
        public int NumPad1
        {
            get { return 4194439; }
        }

        [ContextProperty("NumPad2", "NumPad2")]
        public int NumPad2
        {
            get { return 4194440; }
        }

        [ContextProperty("NumPad3", "NumPad3")]
        public int NumPad3
        {
            get { return 4194441; }
        }

        [ContextProperty("NumPad4", "NumPad4")]
        public int NumPad4
        {
            get { return 4194442; }
        }

        [ContextProperty("NumPad5", "NumPad5")]
        public int NumPad5
        {
            get { return 4194443; }
        }

        [ContextProperty("NumPad6", "NumPad6")]
        public int NumPad6
        {
            get { return 4194444; }
        }

        [ContextProperty("NumPad7", "NumPad7")]
        public int NumPad7
        {
            get { return 4194445; }
        }

        [ContextProperty("NumPad8", "NumPad8")]
        public int NumPad8
        {
            get { return 4194446; }
        }

        [ContextProperty("NumPad9", "NumPad9")]
        public int NumPad9
        {
            get { return 4194447; }
        }

        [ContextProperty("NumPadEnter", "NumPadEnter")]
        public int NumPadEnter
        {
            get { return 4194310; }
        }

        [ContextProperty("NumPadMinus", "NumPadMinus")]
        public int NumPadMinus
        {
            get { return 4194435; }
        }

        [ContextProperty("NumPadPlus", "NumPadPlus")]
        public int NumPadPlus
        {
            get { return 4194437; }
        }

        [ContextProperty("NumPadSeparator", "NumPadSeparator")]
        public int NumPadSeparator
        {
            get { return 4194436; }
        }

        [ContextProperty("Numbersign", "Numbersign")]
        public int Numbersign
        {
            get { return 35; }
        }

        [ContextProperty("O", "O")]
        public int O
        {
            get { return 79; }
        }

        [ContextProperty("P", "P")]
        public int P
        {
            get { return 80; }
        }

        [ContextProperty("PageDown", "PageDown")]
        public int PageDown
        {
            get { return 4194324; }
        }

        [ContextProperty("PageUp", "PageUp")]
        public int PageUp
        {
            get { return 4194323; }
        }

        [ContextProperty("ParenLeft", "ParenLeft")]
        public int ParenLeft
        {
            get { return 40; }
        }

        [ContextProperty("ParenRight", "ParenRight")]
        public int ParenRight
        {
            get { return 41; }
        }

        [ContextProperty("Pause", "Pause")]
        public int Pause
        {
            get { return 4194313; }
        }

        [ContextProperty("Percent", "Percent")]
        public int Percent
        {
            get { return 37; }
        }

        [ContextProperty("Plus", "Plus")]
        public int Plus
        {
            get { return 43; }
        }

        [ContextProperty("Print", "Print")]
        public int Print
        {
            get { return 4194314; }
        }

        [ContextProperty("Q", "Q")]
        public int Q
        {
            get { return 81; }
        }

        [ContextProperty("Question", "Question")]
        public int Question
        {
            get { return 63; }
        }

        [ContextProperty("QuoteLeft", "QuoteLeft")]
        public int QuoteLeft
        {
            get { return 96; }
        }

        [ContextProperty("Quotedbl", "Quotedbl")]
        public int Quotedbl
        {
            get { return 34; }
        }

        [ContextProperty("R", "R")]
        public int R
        {
            get { return 82; }
        }

        [ContextProperty("RightArrow", "RightArrow")]
        public int RightArrow
        {
            get { return 4194321; }
        }

        [ContextProperty("S", "S")]
        public int S
        {
            get { return 83; }
        }

        [ContextProperty("ScrollLock", "ScrollLock")]
        public int ScrollLock
        {
            get { return 4194331; }
        }

        [ContextProperty("Section", "Section")]
        public int Section
        {
            get { return 167; }
        }

        [ContextProperty("Semicolon", "Semicolon")]
        public int Semicolon
        {
            get { return 59; }
        }

        [ContextProperty("Separator", "Separator")]
        public int Separator
        {
            get { return 46; }
        }

        [ContextProperty("Shift", "Shift")]
        public int Shift
        {
            get { return 4194325; }
        }

        [ContextProperty("Slash", "Slash")]
        public int Slash
        {
            get { return 47; }
        }

        [ContextProperty("Space", "Space")]
        public int Space
        {
            get { return 32; }
        }

        [ContextProperty("Special", "Special")]
        public int Special
        {
            get { return 4194304; }
        }

        [ContextProperty("T", "T")]
        public int T
        {
            get { return 84; }
        }

        [ContextProperty("Tab", "Tab")]
        public int Tab
        {
            get { return 4194306; }
        }

        [ContextProperty("U", "U")]
        public int U
        {
            get { return 85; }
        }

        [ContextProperty("Underscore", "Underscore")]
        public int Underscore
        {
            get { return 95; }
        }

        [ContextProperty("Unknown", "Unknown")]
        public int Unknown
        {
            get { return 8388607; }
        }

        [ContextProperty("UpArrow", "UpArrow")]
        public int UpArrow
        {
            get { return 4194320; }
        }

        [ContextProperty("V", "V")]
        public int V
        {
            get { return 86; }
        }

        [ContextProperty("W", "W")]
        public int W
        {
            get { return 87; }
        }

        [ContextProperty("X", "X")]
        public int X
        {
            get { return 88; }
        }

        [ContextProperty("Y", "Y")]
        public int Y
        {
            get { return 89; }
        }

        [ContextProperty("Z", "Z")]
        public int Z
        {
            get { return 90; }
        }
    }
}
