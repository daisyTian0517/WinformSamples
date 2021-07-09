using System.ComponentModel;

namespace CustomEditor
{
    public class ShowedClass
    {
        [DisplayName("名称")]
        [Editor(typeof(Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Name { get; set; }

        [Editor(typeof(Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Description { get; set; }
    }
}
