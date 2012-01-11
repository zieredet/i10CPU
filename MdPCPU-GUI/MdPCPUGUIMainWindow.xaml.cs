using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;
using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU;
using System.Diagnostics;
using System.Windows.Threading;


namespace MdPCPUGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        DispatcherTimer T = new DispatcherTimer();
        DispatcherTimer S = new DispatcherTimer();
        private ICPU cpu;
        


        public MainWindow()
        {
            InitializeComponent();
          
            T.Interval = TimeSpan.FromSeconds(1);
            T.Tick += new EventHandler(T_Tick);

            S.Interval = TimeSpan.FromMilliseconds(10);
            S.Tick += new EventHandler(S_Tick);
            
            cpu = CPUFactory.GetCPU(CPUFactory.CPU_EASY);
            
           memoryGrid.ItemsSource = cpu.Memory;
        }

        private void memoryGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }


        private void StepForward_Click(object sender, RoutedEventArgs e)
        {
            

            cpu.RunStep(0);


            if (memoryGrid.SelectedIndex < 14)
            {
                memoryGrid.ScrollIntoView(memoryGrid.SelectedItem);
            }
            else
            {


                if (memoryGrid.Items.Count > 0)
                {
                    Decorator border = (Decorator)VisualTreeHelper.GetChild(memoryGrid, 0);
                    if (border != null)
                    {
                        ScrollViewer scroll = (ScrollViewer)border.Child;
                        if (scroll != null)
                        {


                            scroll.ScrollToTop();
                            memoryGrid.ScrollIntoView(memoryGrid.SelectedItem);

                            for (int i = 0; i < 15; i++)
                            {

                                scroll.LineDown();
                            }
                        }
                    }
                }
            }

            
            
        }

        private void ClearMemory_Click(object sender, RoutedEventArgs e)
        {
            // TO-DO: Implement Ram Reset
        }

        private void StartAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cpu != null) 
            {
                // TO-DO: Impelement Start Address Change
            }

        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void LoadMul_Click(object sender, RoutedEventArgs e)
        {          

                       

        }

               
        private void LoadPgm_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.CheckPathExists = true;
            dlg.CheckFileExists = true;
            dlg.Multiselect = false;
            dlg.InitialDirectory = @"C:\FachHochSchule\Informatik\3S\CPU\Mini-Power-PC\SampleCodes";
            dlg.FileName = "MyCode"; // Default file name
            dlg.DefaultExt = ".mpcb"; // Default file extension
            dlg.Filter = "Pgmcode Binary (*.mpcb)|*.mpcb|Pgmcode Hex (*.mpch)|*.mpch)|Pgmcode Decimal (*.mpcd)|*.mpcd|All files (*.*)|*.*"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            if (!result.HasValue || !result.Value) return;

            string filename = dlg.FileName;
            FileInfo file = new FileInfo(filename);
            if (!file.Exists) return;

            ePgmCodeType pgmCodeType = ePgmCodeType.init;
            if (filename.ToLower().EndsWith(".mpcb")) pgmCodeType = ePgmCodeType.bin;
            else if (filename.ToLower().EndsWith(".mpcd")) pgmCodeType = ePgmCodeType.dec;
            else if (filename.ToLower().EndsWith(".mpch")) pgmCodeType = ePgmCodeType.hex;
            else return;

            //TODO: implement Hex and Dec
      

        }

        private enum ePgmCodeType { init, bin, dec, hex };

        private void JumpToAddress_Click(object sender, RoutedEventArgs e)
        {
            if (cpu != null)
            {
                //TODO: Not implemented in cpu
                
            }
        }

        private void ClearRegisters_Click(object sender, RoutedEventArgs e)
        {
                //TODO: Not implemented in cpu
        }


        private void Reset_Click(object sender, RoutedEventArgs e)
        {

            //TODO: Not implemented in cpu

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            T.Start();
            
        }

        private void T_Tick(object sender, EventArgs e)
        {

            //TODO: Not implemented in cpu
          
        }

        private void S_Tick(object sender, EventArgs e)
        {

            //TODO: Not implemented in cpu
        }
       
        private void Execute_Click(object sender, RoutedEventArgs e)
        {

            S.Start();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            S.Stop();
            T.Stop();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("i10bCPU 1.0 (SchwIntel-Inside)", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

     

    }

   

}
