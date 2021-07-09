using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace CustomEditor
{
    public class Editor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            // 编辑属性值时，在右侧显示...更多按钮  
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            var edSvc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            if (edSvc != null)
            {
                var popedControl = new EditorControl();
                // 还有ShowDialog这种方式，可以弹出一个窗体来进行编辑  
                edSvc.DropDownControl(popedControl);
                value = popedControl.result;
            }
            return base.EditValue(context, provider, value);
        }
    }
}
