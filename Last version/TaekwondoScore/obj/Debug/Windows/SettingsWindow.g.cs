#pragma checksum "..\..\..\Windows\SettingsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FE881EF03D4E342F2EA2F43AAFA1154E3CAD5E9438D60D2388CFE99FDE4521FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TaekwondoScore.Windows;


namespace TaekwondoScore.Windows {
    
    
    /// <summary>
    /// SettingsWindow
    /// </summary>
    public partial class SettingsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\..\Windows\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox helmetTxb;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Windows\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox protectionTxb;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Windows\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox techniqueTxb;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Windows\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numRoundTxb;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Windows\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox roundDurTxb;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Windows\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox breakDurTxb;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Windows\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox timeOutTxb;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Windows\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pointDifferTxb;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Windows\SettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button settingSaveBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TaekwondoScore;component/windows/settingswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\SettingsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\Windows\SettingsWindow.xaml"
            ((TaekwondoScore.Windows.SettingsWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\Windows\SettingsWindow.xaml"
            ((TaekwondoScore.Windows.SettingsWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.helmetTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.protectionTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.techniqueTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.numRoundTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.roundDurTxb = ((System.Windows.Controls.TextBox)(target));
            
            #line 60 "..\..\..\Windows\SettingsWindow.xaml"
            this.roundDurTxb.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.roundDurTxb_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.breakDurTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.timeOutTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.pointDifferTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.settingSaveBtn = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\..\Windows\SettingsWindow.xaml"
            this.settingSaveBtn.Click += new System.Windows.RoutedEventHandler(this.settingSaveBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

