using System;
using System.Windows.Forms;

namespace Search_Address2_OutlookAddIn
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class MyPropPage1 : UserControl, Microsoft.Office.Interop.Outlook.PropertyPage
    {
        private Microsoft.Office.Interop.Outlook.PropertyPageSite _propertyPageSite;

        public MyPropPage1() {
            InitializeComponent();

            textBoxHost.Text = Properties.Settings.Default.Host;
            textBoxBase.Text = Properties.Settings.Default.Base;
            textBoxPort.Text = Properties.Settings.Default.Port;
            textBoxFilter1.Text = Properties.Settings.Default.Filter1;
            textBoxFilter2.Text = Properties.Settings.Default.Filter2;
            numericUpDownMaxRecords.Value = Properties.Settings.Default.MaxRecords;

            textBoxHost.TextChanged += TextBoxChanged;
            textBoxBase.TextChanged += TextBoxChanged;
            textBoxPort.TextChanged += TextBoxChanged;
            textBoxFilter1.TextChanged += TextBoxChanged;
            textBoxFilter2.TextChanged += TextBoxChanged;
            numericUpDownMaxRecords.ValueChanged += numericUpDownChanged;

            void TextBoxChanged(object sender, EventArgs e) {
                if (_propertyPageSite != null)
                    _propertyPageSite.OnStatusChange();
            }

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
            Properties.Settings.Default.Host = textBoxHost.Text;
            Properties.Settings.Default.Base = textBoxBase.Text;
            Properties.Settings.Default.Port = textBoxPort.Text;
            Properties.Settings.Default.Filter1 = textBoxFilter1.Text;
            Properties.Settings.Default.Filter2 = textBoxFilter2.Text;
            Properties.Settings.Default.MaxRecords = numericUpDownMaxRecords.Value;
            Properties.Settings.Default.Save();
        }

        public bool Dirty {
            get {
                return
                    !textBoxHost.Text.Equals(Properties.Settings.Default.Host) ||
                    !textBoxBase.Text.Equals(Properties.Settings.Default.Base) ||
                    !textBoxPort.Text.Equals(Properties.Settings.Default.Port) ||
                    !textBoxFilter1.Text.Equals(Properties.Settings.Default.Filter1) ||
                    !textBoxFilter2.Text.Equals(Properties.Settings.Default.Filter2) ||
                    !numericUpDownMaxRecords.Value.Equals(Properties.Settings.Default.MaxRecords);
            }
        }

        public void GetPageInfo(ref string HelpFile, ref int HelpContext) {
            // To Specify HelpFile
        }
    }
}