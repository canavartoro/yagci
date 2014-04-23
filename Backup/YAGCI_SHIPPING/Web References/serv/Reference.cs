﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5420
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.5420.
// 
#pragma warning disable 1591

namespace YAGCI_SHIPPING.serv {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="servSoap", Namespace="http://tempuri.org/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PersistentBase))]
    public partial class serv : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback KayitlariAlOperationCompleted;
        
        private System.Threading.SendOrPostCallback FormlariAlOperationCompleted;
        
        private System.Threading.SendOrPostCallback FormDataAktarOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public serv() {
            this.Url = global::YAGCI_SHIPPING.Properties.Settings.Default.YAGCI_SHIPPING_serv_serv;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event KayitlariAlCompletedEventHandler KayitlariAlCompleted;
        
        /// <remarks/>
        public event FormlariAlCompletedEventHandler FormlariAlCompleted;
        
        /// <remarks/>
        public event FormDataAktarCompletedEventHandler FormDataAktarCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/KayitlariAl", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public FORMGENERIC[] KayitlariAl() {
            object[] results = this.Invoke("KayitlariAl", new object[0]);
            return ((FORMGENERIC[])(results[0]));
        }
        
        /// <remarks/>
        public void KayitlariAlAsync() {
            this.KayitlariAlAsync(null);
        }
        
        /// <remarks/>
        public void KayitlariAlAsync(object userState) {
            if ((this.KayitlariAlOperationCompleted == null)) {
                this.KayitlariAlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnKayitlariAlOperationCompleted);
            }
            this.InvokeAsync("KayitlariAl", new object[0], this.KayitlariAlOperationCompleted, userState);
        }
        
        private void OnKayitlariAlOperationCompleted(object arg) {
            if ((this.KayitlariAlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.KayitlariAlCompleted(this, new KayitlariAlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FormlariAl", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public GENERIC[] FormlariAl() {
            object[] results = this.Invoke("FormlariAl", new object[0]);
            return ((GENERIC[])(results[0]));
        }
        
        /// <remarks/>
        public void FormlariAlAsync() {
            this.FormlariAlAsync(null);
        }
        
        /// <remarks/>
        public void FormlariAlAsync(object userState) {
            if ((this.FormlariAlOperationCompleted == null)) {
                this.FormlariAlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFormlariAlOperationCompleted);
            }
            this.InvokeAsync("FormlariAl", new object[0], this.FormlariAlOperationCompleted, userState);
        }
        
        private void OnFormlariAlOperationCompleted(object arg) {
            if ((this.FormlariAlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FormlariAlCompleted(this, new FormlariAlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FormDataAktar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ServisResult FormDataAktar(FORMGENERIC[] data) {
            object[] results = this.Invoke("FormDataAktar", new object[] {
                        data});
            return ((ServisResult)(results[0]));
        }
        
        /// <remarks/>
        public void FormDataAktarAsync(FORMGENERIC[] data) {
            this.FormDataAktarAsync(data, null);
        }
        
        /// <remarks/>
        public void FormDataAktarAsync(FORMGENERIC[] data, object userState) {
            if ((this.FormDataAktarOperationCompleted == null)) {
                this.FormDataAktarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFormDataAktarOperationCompleted);
            }
            this.InvokeAsync("FormDataAktar", new object[] {
                        data}, this.FormDataAktarOperationCompleted, userState);
        }
        
        private void OnFormDataAktarOperationCompleted(object arg) {
            if ((this.FormDataAktarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FormDataAktarCompleted(this, new FormDataAktarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class FORMGENERIC : XPObject {
        
        private string fORMNAMEField;
        
        private int kULLANICIIDField;
        
        private System.DateTime tARIHField;
        
        private string valuesField;
        
        private int fIRMAIDField;
        
        private int uSTFORMIDField;
        
        private int fORMIDField;
        
        /// <remarks/>
        public string FORMNAME {
            get {
                return this.fORMNAMEField;
            }
            set {
                this.fORMNAMEField = value;
            }
        }
        
        /// <remarks/>
        public int KULLANICIID {
            get {
                return this.kULLANICIIDField;
            }
            set {
                this.kULLANICIIDField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime TARIH {
            get {
                return this.tARIHField;
            }
            set {
                this.tARIHField = value;
            }
        }
        
        /// <remarks/>
        public string Values {
            get {
                return this.valuesField;
            }
            set {
                this.valuesField = value;
            }
        }
        
        /// <remarks/>
        public int FIRMAID {
            get {
                return this.fIRMAIDField;
            }
            set {
                this.fIRMAIDField = value;
            }
        }
        
        /// <remarks/>
        public int USTFORMID {
            get {
                return this.uSTFORMIDField;
            }
            set {
                this.uSTFORMIDField = value;
            }
        }
        
        /// <remarks/>
        public int FORMID {
            get {
                return this.fORMIDField;
            }
            set {
                this.fORMIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GENERIC))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FORMGENERIC))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class XPObject : XPCustomObject {
        
        private int oidField;
        
        /// <remarks/>
        public int Oid {
            get {
                return this.oidField;
            }
            set {
                this.oidField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XPObject))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GENERIC))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FORMGENERIC))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class XPCustomObject : XPBaseObject {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XPCustomObject))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XPObject))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GENERIC))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FORMGENERIC))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class XPBaseObject : PersistentBase {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XPBaseObject))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XPCustomObject))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XPObject))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GENERIC))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FORMGENERIC))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class PersistentBase {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ServisResult {
        
        private bool durumField;
        
        private string sonucField;
        
        /// <remarks/>
        public bool Durum {
            get {
                return this.durumField;
            }
            set {
                this.durumField = value;
            }
        }
        
        /// <remarks/>
        public string Sonuc {
            get {
                return this.sonucField;
            }
            set {
                this.sonucField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class GENERIC : XPObject {
        
        private Control cONTROLYYPEField;
        
        private Sekiller rEPOTYPEField;
        
        private DockStyle dOCKField;
        
        private int xPOSField;
        
        private int yPOSField;
        
        private int hSIZEField;
        
        private int wSIZEField;
        
        private int cOLCOUNTField;
        
        private int rOWCOUNTField;
        
        private string rEPOITEMSField;
        
        private string hEADERField;
        
        private string fORMNAMEField;
        
        private string cAPTIONField;
        
        private string tEXTField;
        
        private int oRDERField;
        
        private int fORMIDField;
        
        private int uSTFORMIDField;
        
        private int hSIZE1Field;
        
        private int wSIZE1Field;
        
        private string nAMEField;
        
        private string sIZESField;
        
        private bool lANDSCAPEField;
        
        private byte[] iCONEFILEField;
        
        /// <remarks/>
        public Control CONTROLYYPE {
            get {
                return this.cONTROLYYPEField;
            }
            set {
                this.cONTROLYYPEField = value;
            }
        }
        
        /// <remarks/>
        public Sekiller REPOTYPE {
            get {
                return this.rEPOTYPEField;
            }
            set {
                this.rEPOTYPEField = value;
            }
        }
        
        /// <remarks/>
        public DockStyle DOCK {
            get {
                return this.dOCKField;
            }
            set {
                this.dOCKField = value;
            }
        }
        
        /// <remarks/>
        public int XPOS {
            get {
                return this.xPOSField;
            }
            set {
                this.xPOSField = value;
            }
        }
        
        /// <remarks/>
        public int YPOS {
            get {
                return this.yPOSField;
            }
            set {
                this.yPOSField = value;
            }
        }
        
        /// <remarks/>
        public int HSIZE {
            get {
                return this.hSIZEField;
            }
            set {
                this.hSIZEField = value;
            }
        }
        
        /// <remarks/>
        public int WSIZE {
            get {
                return this.wSIZEField;
            }
            set {
                this.wSIZEField = value;
            }
        }
        
        /// <remarks/>
        public int COLCOUNT {
            get {
                return this.cOLCOUNTField;
            }
            set {
                this.cOLCOUNTField = value;
            }
        }
        
        /// <remarks/>
        public int ROWCOUNT {
            get {
                return this.rOWCOUNTField;
            }
            set {
                this.rOWCOUNTField = value;
            }
        }
        
        /// <remarks/>
        public string REPOITEMS {
            get {
                return this.rEPOITEMSField;
            }
            set {
                this.rEPOITEMSField = value;
            }
        }
        
        /// <remarks/>
        public string HEADER {
            get {
                return this.hEADERField;
            }
            set {
                this.hEADERField = value;
            }
        }
        
        /// <remarks/>
        public string FORMNAME {
            get {
                return this.fORMNAMEField;
            }
            set {
                this.fORMNAMEField = value;
            }
        }
        
        /// <remarks/>
        public string CAPTION {
            get {
                return this.cAPTIONField;
            }
            set {
                this.cAPTIONField = value;
            }
        }
        
        /// <remarks/>
        public string TEXT {
            get {
                return this.tEXTField;
            }
            set {
                this.tEXTField = value;
            }
        }
        
        /// <remarks/>
        public int ORDER {
            get {
                return this.oRDERField;
            }
            set {
                this.oRDERField = value;
            }
        }
        
        /// <remarks/>
        public int FORMID {
            get {
                return this.fORMIDField;
            }
            set {
                this.fORMIDField = value;
            }
        }
        
        /// <remarks/>
        public int USTFORMID {
            get {
                return this.uSTFORMIDField;
            }
            set {
                this.uSTFORMIDField = value;
            }
        }
        
        /// <remarks/>
        public int HSIZE1 {
            get {
                return this.hSIZE1Field;
            }
            set {
                this.hSIZE1Field = value;
            }
        }
        
        /// <remarks/>
        public int WSIZE1 {
            get {
                return this.wSIZE1Field;
            }
            set {
                this.wSIZE1Field = value;
            }
        }
        
        /// <remarks/>
        public string NAME {
            get {
                return this.nAMEField;
            }
            set {
                this.nAMEField = value;
            }
        }
        
        /// <remarks/>
        public string SIZES {
            get {
                return this.sIZESField;
            }
            set {
                this.sIZESField = value;
            }
        }
        
        /// <remarks/>
        public bool LANDSCAPE {
            get {
                return this.lANDSCAPEField;
            }
            set {
                this.lANDSCAPEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] ICONEFILE {
            get {
                return this.iCONEFILEField;
            }
            set {
                this.iCONEFILEField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum Control {
        
        /// <remarks/>
        UGrid,
        
        /// <remarks/>
        ULabel,
        
        /// <remarks/>
        UMText,
        
        /// <remarks/>
        UText,
        
        /// <remarks/>
        UVGrid,
        
        /// <remarks/>
        ULabels,
        
        /// <remarks/>
        UIcone,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum Sekiller {
        
        /// <remarks/>
        AcilirListe,
        
        /// <remarks/>
        MetinGirisi,
        
        /// <remarks/>
        Tarih,
        
        /// <remarks/>
        EvetHayir,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.5420")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum DockStyle {
        
        /// <remarks/>
        None,
        
        /// <remarks/>
        Top,
        
        /// <remarks/>
        Bottom,
        
        /// <remarks/>
        Left,
        
        /// <remarks/>
        Right,
        
        /// <remarks/>
        Fill,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void KayitlariAlCompletedEventHandler(object sender, KayitlariAlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class KayitlariAlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal KayitlariAlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public FORMGENERIC[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((FORMGENERIC[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void FormlariAlCompletedEventHandler(object sender, FormlariAlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FormlariAlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FormlariAlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public GENERIC[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((GENERIC[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    public delegate void FormDataAktarCompletedEventHandler(object sender, FormDataAktarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.5420")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FormDataAktarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FormDataAktarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ServisResult Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ServisResult)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591