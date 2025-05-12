using ConsoleServiceTool.Console.Sony.Shared;
using ConsoleServiceTool.Utils;

namespace ConsoleServiceTool.Console.Sony.PlayStation5.Views
{
    internal partial class PS5OSFlagsView : UserControl
    {
        private NvsOS? _os;
        public PS5OSFlagsView()
        {
            InitializeComponent();
        }

        private void PS5OSFlagsView_Load(object sender, EventArgs e)
        {
            ResetLabels();
            LoadComboList<InterfaceDemonstrationUnit>(IduList);
            LoadComboList<BiosMemoryTestFlag>(BiosMemoryTestCombo);
            LoadComboList<AblDebugPrintFlag>(DebugPrintCombo);
            LoadComboList<BootMessageModeFlag>(BootMsgModeCombo);
            LoadComboList<ManufacturingFlag>(ManufacturingModeCombo);
            LoadComboList<MpMemoryTestFlag>(MemoryTestCombo);
        }

        private void ResetLabels()
        {
            PanelInfo.Controls.OfType<Label>().ToList().ForEach(label =>
            {
                if (label.Tag is string str && bool.TryParse(str, out var reset) && reset)
                    label.ResetText();
            });
        }

        public void ShowOsValues(NvsOS os)
        {
            ResetLabels();
            _os = os;
            byte[] bytes = BitConverter.GetBytes(_os.FirmwareVersion);
            Array.Reverse(bytes);
            lFrimwareVersion.Text = BitConverter.ToString(bytes).Replace("-", ".");

            lIduMode.Text = _os.InterfaceDemonstrationUnit.ToDescription();
            IduList.SelectedValue = _os.InterfaceDemonstrationUnit;

            BiosMemoryTest.Text = _os.BiosMemoryTestFlag.ToDescription();
            BiosMemoryTestCombo.SelectedValue = _os.BiosMemoryTestFlag;

            DebugPrint.Text = _os.AblDebugPrintFlag.ToDescription();
            DebugPrintCombo.SelectedValue = _os.AblDebugPrintFlag;

            BootMsgMode.Text = _os.BootMessageModeFlag.ToDescription();
            BootMsgModeCombo.SelectedValue = _os.BootMessageModeFlag;

            ManufacturingMode.Text = _os.ManufacturingFlag.ToDescription();
            ManufacturingModeCombo.SelectedValue = _os.ManufacturingFlag;

            MemoryTest.Text = _os.MpMemoryTestFlag.ToDescription();
            MemoryTestCombo.SelectedValue = _os.MpMemoryTestFlag;
        }

        public void UpdateChangedOsValues()
        {
            UpdateChangedOsValue(IduList, () => _os.InterfaceDemonstrationUnit, val => _os.InterfaceDemonstrationUnit = val);
            UpdateChangedOsValue(BiosMemoryTestCombo, () => _os.BiosMemoryTestFlag, val => _os.BiosMemoryTestFlag = val);
            UpdateChangedOsValue(DebugPrintCombo, () => _os.AblDebugPrintFlag, val => _os.AblDebugPrintFlag = val);
            UpdateChangedOsValue(BootMsgModeCombo, () => _os.BootMessageModeFlag, val => _os.BootMessageModeFlag = val);
            UpdateChangedOsValue(ManufacturingModeCombo, () => _os.ManufacturingFlag, val => _os.ManufacturingFlag = val);
            UpdateChangedOsValue(MemoryTestCombo, () => _os.MpMemoryTestFlag, val => _os.MpMemoryTestFlag = val);
        }

        private static void UpdateChangedOsValue<T>(ComboBox cb, Func<T> getter, Action<T> setter)
        {
            if (cb.SelectedValue is T value && !EqualityComparer<T>.Default.Equals(getter(), value))
                setter(value);
        }
        private static void LoadComboList<T>(ComboBox cb)
        {
            cb.EnumForComboBox<T>();
            cb.DisplayMember = "Description";
            cb.ValueMember = "Value";
        }
    }
}
