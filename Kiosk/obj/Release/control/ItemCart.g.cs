﻿#pragma checksum "..\..\..\control\ItemCart.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0D190DFF0768786C2647AA8493915124"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CachedImage;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Kiosk.control {
    
    
    /// <summary>
    /// ItemCart
    /// </summary>
    public partial class ItemCart : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\control\ItemCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Mask;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\control\ItemCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal CachedImage.Image img_product;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\control\ItemCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_product;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\control\ItemCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_desserts;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\control\ItemCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_up;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\control\ItemCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_count;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\control\ItemCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_down;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\control\ItemCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_product_price;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\control\ItemCart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_remove;
        
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
            System.Uri resourceLocater = new System.Uri("/Kiosk;component/control/itemcart.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\control\ItemCart.xaml"
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
            
            #line 11 "..\..\..\control\ItemCart.xaml"
            ((Kiosk.control.ItemCart)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Mask = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.img_product = ((CachedImage.Image)(target));
            return;
            case 4:
            this.txt_product = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.lst_desserts = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            this.btn_up = ((System.Windows.Controls.Button)(target));
            
            #line 92 "..\..\..\control\ItemCart.xaml"
            this.btn_up.Click += new System.Windows.RoutedEventHandler(this.btn_up_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txt_count = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.btn_down = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\control\ItemCart.xaml"
            this.btn_down.Click += new System.Windows.RoutedEventHandler(this.btn_down_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.txt_product_price = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.btn_remove = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\control\ItemCart.xaml"
            this.btn_remove.Click += new System.Windows.RoutedEventHandler(this.btn_remove_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

