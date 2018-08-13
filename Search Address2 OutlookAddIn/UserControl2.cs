using System;
using System.Windows.Forms;

namespace Search_Address2_OutlookAddIn
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class MyPropPage2 : UserControl, Microsoft.Office.Interop.Outlook.PropertyPage
    {
        private Microsoft.Office.Interop.Outlook.PropertyPageSite _propertyPageSite;

        public MyPropPage2() {
            InitializeComponent();

            numericUpDownOffsetX.Value = Properties.Settings.Default.Offset_X;
            numericUpDownOffsetY.Value = Properties.Settings.Default.Offset_Y;

            numericUpDownOffsetX.ValueChanged += numericUpDownChanged;
            numericUpDownOffsetY.ValueChanged += numericUpDownChanged;

            void numericUpDownChanged(object sender, EventArgs e) {
                if (_propertyPageSite != null)
                    _propertyPageSite.OnStatusChange();
            }
        }

        protected override void OnLoad(EventArgs e) {
            Type type = typeof(System.Object);
            string assembly = type.Assembly.CodeBase.Replace("mscorlib.dll", "System.Windows.Forms.dll").Replace("file:///", "");
            string assemblyName = System.Reflection.AssemblyName.GetAssemblyName(assembly).FullName;
            Type unsafeNativeMethods = Type.GetType(System.Reflection.Assembly.CreateQualifiedName(assemblyName, "System.Windows.Forms.UnsafeNativeMethods"));
            System.Reflection.MethodInfo methodInfo = unsafeNativeMethods.GetNestedType("IOleObject").GetMethod("GetClientSite");
            _propertyPageSite = methodInfo.Invoke(this, null) as Microsoft.Office.Interop.Outlook.PropertyPageSite;
        }

        public void Apply() {
            Properties.Settings.Default.Offset_X = numericUpDownOffsetX.Value;
            Properties.Settings.Default.Offset_Y = numericUpDownOffsetY.Value;
            Properties.Settings.Default.Save();
        }

        public bool Dirty {
            get {
                return
                    !numericUpDownOffsetX.Value.Equals(Properties.Settings.Default.Offset_X) ||
                    !numericUpDownOffsetY.Value.Equals(Properties.Settings.Default.Offset_Y);
            }
        }

        public void GetPageInfo(ref string HelpFile, ref int HelpContext) {
            // To Specify HelpFile
        }
    }
}