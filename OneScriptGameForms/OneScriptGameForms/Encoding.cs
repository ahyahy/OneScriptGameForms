using OneScript.Contexts;
using OneScript.StandardLibrary.Binary;
using ScriptEngine.Machine.Contexts;

namespace osgf
{
    [ContextClass("ИфКодировка", "GfEncoding")]
    public class GfEncoding : AutoContext<GfEncoding>
    {
        public System.Text.Encoding Base_obj = System.Text.Encoding.Default;

        public GfEncoding()
        {
        }

        public GfEncoding(System.Text.Encoding p1)
        {
            Base_obj = p1;
        }

        [ContextProperty("ASCII", "ASCII")]
        public GfEncoding ASCII
        {
            get { return new GfEncoding(System.Text.Encoding.ASCII); }
        }

        [ContextProperty("UTF8", "UTF8")]
        public GfEncoding UTF8
        {
            get { return new GfEncoding(System.Text.Encoding.UTF8); }
        }

        [ContextProperty("ИмяВеб", "WebName")]
        public string WebName
        {
            get { return Base_obj.WebName; }
        }

        [ContextProperty("ИмяЗаголовка", "HeaderName")]
        public string HeaderName
        {
            get { return Base_obj.HeaderName; }
        }

        [ContextProperty("ИмяКодировки", "EncodingName")]
        public string EncodingName
        {
            get { return Base_obj.EncodingName; }
        }

        [ContextProperty("ИмяТела", "BodyName")]
        public string BodyName
        {
            get { return Base_obj.BodyName; }
        }

        [ContextProperty("КодоваяСтраница", "WindowsCodePage")]
        public int WindowsCodePage
        {
            get { return Base_obj.WindowsCodePage; }
        }

        [ContextProperty("ОбратнаяUTF16", "BigEndianUnicode")]
        public GfEncoding BigEndianUnicode
        {
            get { return new GfEncoding(System.Text.Encoding.BigEndianUnicode); }
        }

        [ContextProperty("ПоУмолчанию", "Default")]
        public GfEncoding Default
        {
            get { return new GfEncoding(System.Text.Encoding.Default); }
        }

        [ContextProperty("Юникод", "Unicode")]
        public GfEncoding Unicode
        {
            get { return new GfEncoding(System.Text.Encoding.Unicode); }
        }

        [ContextMethod("КоличествоБайтов", "GetByteCount")]
        public int GetByteCount(string p1)
        {
            return Base_obj.GetByteCount(p1);
        }

        [ContextMethod("ПолучитьБайты", "GetBytes")]
        public BinaryDataBuffer GetBytes(string p1)
        {
            byte[] buffer = Base_obj.GetBytes(p1);
            BinaryDataBuffer bdb = new BinaryDataBuffer(new byte[0]);
            return bdb.Concat((new BinaryDataBuffer(buffer)).Read(0, buffer.Length));
        }

        [ContextMethod("ПолучитьКодировку", "GetEncoding")]
        public GfEncoding GetEncoding(int p1)
        {
            return new GfEncoding(System.Text.Encoding.GetEncoding(p1));
        }
    }
}
