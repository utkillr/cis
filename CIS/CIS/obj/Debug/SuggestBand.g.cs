﻿#pragma checksum "..\..\SuggestBand.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0FB3AE10EFF5217B514448EFDDD09624"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CIS;
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


namespace CIS {
    
    
    /// <summary>
    /// SuggestBand
    /// </summary>
    public partial class SuggestBand : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BandImage;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BandName;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BandCountry;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AllGenresList;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ChosenGenresList;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BandOffSite;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BandImageURL;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BandFanSite;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BandReview;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SuggestBandBtn;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\SuggestBand.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/CIS;component/suggestband.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SuggestBand.xaml"
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
            this.BandImage = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.BandName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BandCountry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AllGenresList = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\SuggestBand.xaml"
            this.AllGenresList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AllGenres_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ChosenGenresList = ((System.Windows.Controls.ListBox)(target));
            
            #line 29 "..\..\SuggestBand.xaml"
            this.ChosenGenresList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectedGenres_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BandOffSite = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BandImageURL = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\SuggestBand.xaml"
            this.BandImageURL.LostFocus += new System.Windows.RoutedEventHandler(this.ImageURL_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            this.BandFanSite = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.BandReview = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.SuggestBandBtn = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\SuggestBand.xaml"
            this.SuggestBandBtn.Click += new System.Windows.RoutedEventHandler(this.SuggestBandBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\SuggestBand.xaml"
            this.CancelBtn.Click += new System.Windows.RoutedEventHandler(this.CancelBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

