﻿#pragma checksum "..\..\..\StatsPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "732ADFB21B67872C35B3E0FDB1E73DD4CC28B8A0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BaseballCalc;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace BaseballCalc {
    
    
    /// <summary>
    /// StatsPage
    /// </summary>
    public partial class StatsPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\StatsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Titlebar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\StatsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Title;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\StatsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Closebtn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\StatsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MiniMaxibtn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\StatsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Minimizebtn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\StatsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BaseballCalc;component/statspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\StatsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Titlebar = ((System.Windows.Controls.Grid)(target));
            
            #line 18 "..\..\..\StatsPage.xaml"
            this.Titlebar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Titlebar_Drag);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Title = ((System.Windows.Controls.Label)(target));
            
            #line 19 "..\..\..\StatsPage.xaml"
            this.Title.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Homepage_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Closebtn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\StatsPage.xaml"
            this.Closebtn.Click += new System.Windows.RoutedEventHandler(this.Closebtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MiniMaxibtn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\StatsPage.xaml"
            this.MiniMaxibtn.Click += new System.Windows.RoutedEventHandler(this.MiniMaxibtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Minimizebtn = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\StatsPage.xaml"
            this.Minimizebtn.Click += new System.Windows.RoutedEventHandler(this.Minimisebtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\..\StatsPage.xaml"
            this.cb.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Cb_OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\StatsPage.xaml"
            this.cb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

